namespace FestivalManager.Core.Controllers
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text;
	using Contracts;
	using Entities.Contracts;
	using Entities.Factories;
	using Entities.Factories.Contracts;

	public class FestivalController : IFestivalController
	{
		private const string TimeFormat = "mm\\:ss";
		private const string TimeFormatLong = "{0:2D}:{1:2D}";

		private readonly IStage stage;

		private readonly ISetFactory setFactory;
		private readonly IInstrumentFactory instrumentFactory;
		private readonly IPerformerFactory performerFactory;
		private readonly ISongFactory songFactory;

		public FestivalController(IStage stage)
		{
			this.stage = stage;

			this.setFactory = new SetFactory();
			this.instrumentFactory = new InstrumentFactory();
			this.performerFactory = new PerformerFactory();
			this.songFactory = new SongFactory();
		}

		public string ProduceReport()
		{
			var sb = new StringBuilder();

			var totalFestivalLength = new TimeSpan(this.stage.Sets.Sum(s => s.ActualDuration.Ticks));

			sb.AppendLine($"Festival length: {FormatTimeSpan(totalFestivalLength)}");

			foreach (var set in this.stage.Sets)
			{
				sb.AppendLine($"--{set.Name} ({FormatTimeSpan(set.ActualDuration)}):");

				var performersOrderedDescendingByAge = set.Performers.OrderByDescending(p => p.Age);
				foreach (var performer in performersOrderedDescendingByAge)
				{
					var instruments = string.Join(", ", performer.Instruments
						.OrderByDescending(i => i.Wear));

					sb.AppendLine($"---{performer.Name} ({instruments})");
				}

				if (!set.Songs.Any())
				{
					sb.AppendLine("--No songs played");
				}
				else
				{
					sb.AppendLine("--Songs played:");
					foreach (var song in set.Songs)
					{
						sb.AppendLine($"----{song.Name} ({song.Duration.ToString(TimeFormat)})");
					}
				}
			}

			return sb.ToString().TrimEnd('\r', '\n');
		}

		private static string FormatTimeSpan(TimeSpan timeSpan)
		{
			var formatted = string.Format("{0:D2}:{1:D2}", (int)timeSpan.TotalMinutes, timeSpan.Seconds);
			return formatted;
		}

		public string RegisterSet(string[] args)
		{
			var name = args[0];
			var type = args[1];

			var set = this.setFactory.CreateSet(name, type);

			this.stage.AddSet(set);

			return $"Registered {type} set";
		}

		public string SignUpPerformer(string[] args)
		{
			var name = args[0];
			var age = int.Parse(args[1]);

			var instrumentNames = args.Skip(2).ToArray();

			var instruments = instrumentNames
				.Select(i => this.instrumentFactory.CreateInstrument(i))
				.ToArray();

			var performer = this.performerFactory.CreatePerformer(name, age);

			foreach (var instrument in instruments)
			{
				performer.AddInstrument(instrument);
			}

			this.stage.AddPerformer(performer);

			return $"Registered performer {performer.Name}";
		}

		public string RegisterSong(string[] args)
		{
			var name = args[0];
			var durationStr = args[1];
			var duration = TimeSpan.ParseExact(durationStr, TimeFormat, CultureInfo.InvariantCulture);

			var song = this.songFactory.CreateSong(name, duration);
			this.stage.AddSong(song);

			return $"Registered song {song}";
		}

		public string AddSongToSet(string[] args)
		{
			var songName = args[0];
			var setName = args[1];

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			if (!this.stage.HasSong(songName))
			{
				throw new InvalidOperationException("Invalid song provided");
			}

			var set = this.stage.GetSet(setName);
			var song = this.stage.GetSong(songName);

			set.AddSong(song);

			return $"Added {song} to {set.Name}";
		}

		public string AddPerformerToSet(string[] args)
		{
			var performerName = args[0];
			var setName = args[1];

			if (!this.stage.HasPerformer(performerName))
			{
				throw new InvalidOperationException("Invalid performer provided");
			}

			if (!this.stage.HasSet(setName))
			{
				throw new InvalidOperationException("Invalid set provided");
			}

			var performer = this.stage.GetPerformer(performerName);
			var set = this.stage.GetSet(setName);

			set.AddPerformer(performer);

			return $"Added {performer.Name} to {set.Name}";
		}

		public string RepairInstruments(string[] args)
		{
			var instrumentsToRepair = this.stage.Performers
				.SelectMany(p => p.Instruments)
				.Where(i => i.Wear < 100)
				.ToArray();

			foreach (var instrument in instrumentsToRepair)
			{
				instrument.Repair();
			}

			return $"Repaired {instrumentsToRepair.Length} instruments";
		}
	}
}