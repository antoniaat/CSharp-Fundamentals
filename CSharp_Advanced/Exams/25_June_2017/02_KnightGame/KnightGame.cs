namespace _02_KnightGame
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class KnightGame
    {
        public static void Main()
        {
            var firstPlayerCards = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            var secondPlayerCards = Console.ReadLine()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            var turnCounter = 0;
            while (turnCounter < 1000000 && firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0)
            {

                var firstPlayerCardNumber = int.Parse(Regex.Match(firstPlayerCards.Last(), @"\d+").ToString());
                var secondPlayerCardNumber = int.Parse(Regex.Match(secondPlayerCards.Last(), @"\d+").ToString());

                if (firstPlayerCardNumber > secondPlayerCardNumber)
                {
                    FirstPlayerWins(firstPlayerCards, secondPlayerCards, firstPlayerCardNumber, secondPlayerCardNumber);
                }

                else if (firstPlayerCardNumber < secondPlayerCardNumber)
                {
                    SecondPlayerWins(firstPlayerCards, secondPlayerCards, firstPlayerCardNumber, secondPlayerCardNumber);
                }

                else if (firstPlayerCardNumber == secondPlayerCardNumber)
                {
                    PlayersWar(firstPlayerCards, secondPlayerCards, firstPlayerCardNumber, secondPlayerCardNumber);
                }
            }
        }

        public static void PlayersWar(List<string> firstPlayerCards, List<string> secondPlayerCards, int firstPlayerCardNumber, int secondPlayerCardNumber)
        {
            var firstPlayerSum = CountLetter(firstPlayerCards[firstPlayerCards.Count - 1]) + CountLetter(firstPlayerCards[firstPlayerCards.Count() - 2]) + CountLetter(firstPlayerCards[firstPlayerCards.Count - 3]);
            var secondPlayerSum = CountLetter(secondPlayerCards[secondPlayerCards.Count - 1]) + CountLetter(secondPlayerCards[secondPlayerCards.Count() - 2]) + CountLetter(secondPlayerCards[secondPlayerCards.Count - 3]);

            if (firstPlayerSum > secondPlayerSum)
            {
                secondPlayerCards.Insert(0, secondPlayerCards.Last());
                secondPlayerCards.Insert(0, firstPlayerCards.Last());
            }

            else if (firstPlayerSum < secondPlayerSum)
            {

            }

            secondPlayerCards.RemoveAt(secondPlayerCards.Count - 1);
            firstPlayerCards.RemoveAt(firstPlayerCards.Count - 1);
        }

        private static int CountLetter(string card)
        {
            var sum = 0;
            var alphabet = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (char)i).ToArray();

            for (var i = 1; i <= 26; i++)
            {
                if (card.Last() == alphabet[i])
                {
                    sum += i;
                }
            }

            return sum;
        }

        public static void SecondPlayerWins(List<string> firstPlayerCards, List<string> secondPlayerCards, int firstPlayerCardNumber, int secondPlayerCardNumber)
        {
            var biggerCard = Math.Max(firstPlayerCardNumber, secondPlayerCardNumber);

            if (firstPlayerCards.Last().StartsWith(biggerCard.ToString()))
            {
                secondPlayerCards.Insert(0, firstPlayerCards.Last());
                secondPlayerCards.Insert(0, secondPlayerCards.Last());
            }
            else
            {
                secondPlayerCards.Insert(0, secondPlayerCards.Last());
                secondPlayerCards.Insert(0, firstPlayerCards.Last());
            }

            secondPlayerCards.RemoveAt(secondPlayerCards.Count - 1);
            firstPlayerCards.RemoveAt(firstPlayerCards.Count - 1);
        }

        public static void FirstPlayerWins(List<string> firstPlayerCards, List<string> secondPlayerCards, int firstPlayerCardNumber, int secondPlayerCardNumber)
        {
            var biggerCard = Math.Max(firstPlayerCardNumber, secondPlayerCardNumber);

            if (firstPlayerCards.Last().StartsWith(biggerCard.ToString()))
            {
                secondPlayerCards.Insert(0, firstPlayerCards.Last());
                secondPlayerCards.Insert(0, secondPlayerCards.Last());
            }
            else
            {
                secondPlayerCards.Insert(0, secondPlayerCards.Last());
                secondPlayerCards.Insert(0, firstPlayerCards.Last());
            }

            secondPlayerCards.RemoveAt(secondPlayerCards.Count - 1);
            firstPlayerCards.RemoveAt(firstPlayerCards.Count - 1);
        }
    }
}
