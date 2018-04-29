// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)

using FestivalManager.Core.Controllers;
using FestivalManager.Core.Controllers.Contracts;
using FestivalManager.Entities;
using FestivalManager.Entities.Instruments;
using FestivalManager.Entities.Sets;

namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Text;

    public class SetControllerTests
    {
        [Test]
        public void CorrectLength()
        {
            var stage = new Stage();
            var set = new Long("Long");
            var song = new Song("Song", new TimeSpan(0, 1, 0));
            var performer = new Performer("Gosho", 21);

            stage.AddPerformer(performer);
            stage.AddSet(set);
            stage.AddSong(song);

            var setController = new SetController(stage);

            Assert.That(setController.PerformSets().Length, Is.EqualTo(28));
        }

        [Test]
        public void CheckIfSetCanPerform()
        {
            var stage = new Stage();
            var guitar = new Guitar();
            var set = new Long("Long");
            var song = new Song("Song", new TimeSpan(0, 1, 0));
            var performer = new Performer("Gosho", 21);

            stage.AddPerformer(performer);
            performer.AddInstrument(guitar);
            stage.AddSet(set);
            stage.AddSong(song);

            SetController setController = new SetController(stage);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1. Long:");
            sb.AppendLine("-- Did not perform");

            Assert.That(setController.PerformSets(), Is.EqualTo(sb.ToString().Trim()));
        }

        [Test]
        public void SecondTest()
        {
            var stage = new Stage();
            var guitar = new Guitar();
            var set = new Long("Long");
            var song = new Song("Song", new TimeSpan(0, 1, 0));
            var performer = new Performer("Gosho", 21);

            stage.AddSet(set);
            set.AddPerformer(performer);
            set.AddSong(song);
            stage.AddPerformer(performer);
            stage.AddSong(song);
            performer.AddInstrument(guitar);

            var setController = new SetController(stage);
            var sb = new StringBuilder();
            sb.AppendLine("1. Long:");
            sb.AppendLine("-- 1. Song (01:00)");
            sb.AppendLine("-- Set Successful");

            Assert.That(setController.PerformSets(), Is.EqualTo(sb.ToString().Trim()));
        }

        [Test]
        public void PerformSetsCanPerformInstrumentWearsDown()
        {
            var stage = new Stage();
            var set = new Long("short");
            set.AddSong(new Song("s2", new TimeSpan(0, 1, 0)));
            var performer = new Performer("pesho", 100);
            var instrument = new Drums();

            performer.AddInstrument(instrument);
            set.AddPerformer(performer);
            stage.AddSet(set);

            ISetController setController = new SetController(stage);

            setController.PerformSets();

            var actualResult = instrument.Wear;
            var expectedResult = 80;

            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }
    }
}