using Gamemodes;

var playerInput = "";

while (playerInput != "4")
{
    Console.WriteLine("Welcome to Spock, Paper, Lizards! Please choose your gamemode!");
    Console.WriteLine("1. Classic 1 versus 1.");
    Console.WriteLine("2. Tournament 1 versus 3.");
    Console.WriteLine("3. Custom Game");
    Console.WriteLine("4. Quit Game.");
    playerInput = Console.ReadLine();

    switch (playerInput)
    {
        case "1":
            {
                var game = new GameMode();
                game.ClassicMode();
                break;
            }

        case "2":
            {
                var game = new GameMode();
                game.TournamentMode();
                break;
            }

        case "3":
            {
                var game = new GameMode();
                game.CustomMode();
                break;
            }

        case "4":
            {
                return;
            }
    }
}