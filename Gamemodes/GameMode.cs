using System.Runtime.CompilerServices;
using Gamemodes.Models;
using SpockPaperLizards;

namespace Gamemodes
{
    public class GameMode
    {
        private int roundCount;
        private bool hasLost = false;
        private GameLogic _logic = new GameLogic();
        private int playerCount;
        private List<Player> playerList = new List<Player>();
        private PlayerGenerator _playerGenerator = new PlayerGenerator();

        public void ClassicMode()
        {
            var opponent = _playerGenerator.GenerateName();
            Console.WriteLine("Welcome to the classic mode! Take your pick!");
            var result = _logic.Game(opponent);
            if (result == "Victory")
            {
                hasLost = false;
            }

            else
            {
                hasLost = true;
            }

            if (hasLost)
            {
                Console.WriteLine("You lost, too bad. Try again!");
            }

            else
            {
                Console.WriteLine("You are victorious! Congratulations!");
            }
        }

        public void TournamentMode()
        {
            Console.WriteLine("Welcome to the tournament! You must defeat three opponents to be victorious!");
            while (roundCount < 3 && hasLost != true)
            {
                var opponent = _playerGenerator.GenerateName();
                var result = _logic.Game(opponent);

                if (result == "Victory")
                {
                    hasLost = false;
                }

                else
                {
                    hasLost = true;
                }

                roundCount++;
                if (hasLost)
                {
                    Console.WriteLine("You lost, and must forfeit the tournament! Try again another time!");
                }

                else if (!hasLost)
                {
                    Console.WriteLine("You are victorious! Congratulations!");
                }
            }

            if (roundCount == 3 && !hasLost)
            {
                Console.WriteLine("You have won the tournament, congratulations!");
            }
        }

        public void CustomMode()
        {
            int playerWins = 0;
            int playerLosses = 0;
            Console.WriteLine("Welcome to custom mode, please enter the number of players. Number must be 1 to 9.");
            var playerEntry = Console.ReadLine();
            while (true)
            {
                if (Int32.TryParse(playerEntry, out playerCount))
                {
                    if (playerCount < 1 || playerCount > 9)
                    {
                        Console.WriteLine("Invalid player amount!");
                        continue;
                    }
                }
                break;
            }

            while (true)
            {
                Console.WriteLine("Enter the amount of rounds'. Number must be 1 to 5.");
                playerEntry = Console.ReadLine();
                if (Int32.TryParse(playerEntry, out roundCount))
                {
                    if (roundCount < 1 || roundCount > 5)
                    {
                        Console.WriteLine("Invalid amount of rounds!");
                        continue;
                    }
                    break;
                }
            }

            for (int i = 1; i <= playerCount; i++)
            {
                var opponent = _playerGenerator.GenerateName();
                var Player = new Player();
                Player.Name = opponent;
                playerList.Add(Player);
            }

            foreach (var opponent in playerList)
            {
                var result = _logic.Game(opponent.Name, roundCount);
                if (result == "Victory")
                {
                    playerWins++;
                    opponent.Losses++;
                }

                else if (result == "Tie")
                {
                    playerLosses++;
                    opponent.Losses++;
                }

                else
                {
                    playerLosses++;
                    opponent.Victories++;
                }
            }

            for (int i = 0; i < playerList.Count - 1; i++)
            {
                var opponent = playerList[i];

                for (int j = i + 1; j < playerList.Count; j++)
                {
                    var defendant = playerList[j];

                    var result = _logic.ComputerGame(opponent.Name, defendant.Name, roundCount);

                    if (result == "Victory")
                    {
                        opponent.Victories++;
                        defendant.Losses++;
                    }
                    else if (result == "Tie")
                    {
                        opponent.Losses++;
                        defendant.Losses++;
                    }
                    else
                    {
                        opponent.Losses++;
                        defendant.Victories++;
                    }
                }
            }

            var player = new Player();
            player.Name = "Player";
            player.Victories = playerWins;
            player.Losses = playerLosses;
            playerList.Add(player);
            var sortedPlayerList = playerList.OrderByDescending(x => x.Victories).ToList();
            foreach (var x in sortedPlayerList)
            {
                Console.WriteLine(x.Name + " Wins:" + x.Victories + " Losses: " + x.Losses);
            }
        }
    }
}