namespace _10_TheHeiganDance
{
    using System;
    using System.Linq;

    public class TheHeiganDance
    {
        public static void Main()
        {
            var playerRow = 7;
            var playerCol = 7;

            var playerHp = 18500;
            var heiganHp = 3000000d;

            var playerDamage = double.Parse(Console.ReadLine());
            var lastSpell = "";

            while (true)
            {
                if (playerHp >= 0) heiganHp -= playerDamage;
                     
                if (lastSpell.Equals("Cloud")) playerHp -= 3500;

                if (heiganHp <= 0 || playerHp <= 0) break;

                var input = Console.ReadLine().Split().ToArray();
                var currentSpell = input[0];
                var targetRow = int.Parse(input[1]);
                var targetCol = int.Parse(input[2]);

                if (IsInDamageArea(targetRow, targetCol, playerRow, playerCol))
                {
                    if (!IsInDamageArea(targetRow, targetCol, playerRow - 1, playerCol) && !IsWall(playerRow - 1))
                    {
                        playerRow--;
                        lastSpell = "";
                    }
                    else if (!IsInDamageArea(targetRow, targetCol, playerRow, playerCol + 1) && !IsWall(playerCol + 1))
                    {
                        playerCol++;
                        lastSpell = "";
                    }
                    else if (!IsInDamageArea(targetRow, targetCol, playerRow + 1, playerCol) && !IsWall(playerRow + 1))
                    {
                        playerRow++;
                        lastSpell = "";
                    }
                    else if (!IsInDamageArea(targetRow, targetCol, playerRow, playerCol - 1) && !IsWall(playerCol - 1))
                    {
                        playerCol--;
                        lastSpell = "";
                    }
                    else
                    {
                        if (currentSpell.Equals("Cloud"))
                        {
                            playerHp -= 3500;
                            lastSpell = "Cloud";
                        }
                        else if (currentSpell.Equals("Eruption"))
                        {
                            playerHp -= 6000;
                            lastSpell = "Eruption";
                        }
                    }
                }
            }

            lastSpell = lastSpell.Equals("Cloud") ? "Plague Cloud" : "Eruption";

            var heiganState = "";
            heiganState = heiganHp <= 0 ? "Heigan: Defeated!" : $"Heigan: {heiganHp:f2}";

            var playerState = "";
            playerState = playerHp <= 0 ? $"Player: Killed by {lastSpell}" : $"Player: {playerHp}";
            
            var playerEndCoordinates = $"Final position: {playerRow}, {playerCol}";

            Console.WriteLine(heiganState);
            Console.WriteLine(playerState);
            Console.WriteLine(playerEndCoordinates);
        }

        private static bool IsWall(int moveCell)
        {
            return moveCell < 0 || moveCell >= 15;
        }

        private static bool IsInDamageArea(int targetRow, int targetCol, int moveRow, int moveCol)
        {
            return ((targetRow - 1 <= moveRow && moveRow <= targetRow + 1)
                    && (targetCol - 1 <= moveCol && moveCol <= targetCol + 1));
        }
    }
}
