namespace SpockPaperLizards;

public class GameLogic
{
    private string playerWins = "Player Wins!";
    private string computerWins = "Computer Wins!";
    private string tie = "Tie!";
    public Random choicePicker;
    private int playerCounter;
    private int computerCounter;

    public GameLogic()
    {
        choicePicker = new Random();
    }

    public string DetermineChoice(string choice)
    {
        switch (choice)
        {
            case "1":
                return "Rock";
            case "2":
                return "Paper";
            case "3":
                return "Scissors";
            case "4":
                return "Lizard";
            case "5":
                return "Spock";
        }
        return "";
    }

    public string Game(string opponent, int rounds = 3)
    {
        Console.WriteLine("Your opponent today will be " + opponent + "!");
        while (playerCounter < rounds && computerCounter < rounds)
        {
            Console.WriteLine("1. Rock");
            Console.WriteLine("2. Paper");
            Console.WriteLine("3. Scissors");
            Console.WriteLine("4. Lizard");
            Console.WriteLine("5. Spock");
            var playerChoice = DetermineChoice(Console.ReadLine());
            if (playerChoice == string.Empty)
            {
                Console.WriteLine("Invalid choice, try again!");
                continue;
            }

            var computerChoice = DetermineChoice(choicePicker.NextInt64(1, 5).ToString());
            Console.WriteLine(opponent + " chooses " + computerChoice + ".");
            var result = DetermineWinner(playerChoice, computerChoice);
            if (result == "Player Wins!")

            {
                playerCounter++;
                Console.WriteLine("Player wins!, current score Player: " + playerCounter + " " + opponent + ": " +
                                  computerCounter + ".");
            }

            else if (result == "Computer Wins!")

            {
                computerCounter++;
                Console.WriteLine("Computer wins!, current score Player: " + playerCounter + " " + opponent + ": " +
                                  computerCounter + ".");
            }

            else
            {
                Console.WriteLine("Tie!");
            }
        }

        if (playerCounter > computerCounter)
        {
            playerCounter = 0;
            computerCounter = 0;
            return "Victory";
        }

        if (playerCounter == computerCounter)
        {
            playerCounter = 0;
            computerCounter = 0;
            return "Tie";
        }

        else
        {
            playerCounter = 0;
            computerCounter = 0;
            return "Loss";
        }
    }

    public string ComputerGame(string opponent, string defendant, int rounds = 3)
    {
        Console.WriteLine("Current match is: " + opponent + " versus " + defendant + ".");
        while (playerCounter < rounds && computerCounter < rounds)
        {
            var opponentChoice = DetermineChoice(choicePicker.NextInt64(1, 5).ToString());
            var defendantChoice = DetermineChoice(choicePicker.NextInt64(1, 5).ToString());
            Console.WriteLine(opponent + " chooses " + opponentChoice + ".");
            Console.WriteLine(defendantChoice + " chooses " + defendantChoice + ".");
            var result = DetermineWinner(opponentChoice, defendantChoice);
            if (result == "Player Wins!")

            {
                playerCounter++;
                Console.WriteLine(opponent + " wins!, current score Player: " + playerCounter + " " + defendant + ": " +
                                  computerCounter + ".");
            }

            else if (result == "Computer Wins!")

            {
                computerCounter++;
                Console.WriteLine(opponent + " wins!, current score Player: " + playerCounter + " " + opponent + ": " +
                                  computerCounter + ".");
            }

            else
            {
                Console.WriteLine("Tie!");
            }
        }
        if (playerCounter > computerCounter)
        {
            playerCounter = 0;
            computerCounter = 0;
            return "Victory";
        }

        if (playerCounter == computerCounter)
        {
            playerCounter = 0;
            computerCounter = 0;
            return "Tie";
        }

        else
        {
            playerCounter = 0;
            computerCounter = 0;
            return "Loss";
        }
    }

    public string DetermineWinner(string playerChoice, string computerChoice)
    {
        switch (playerChoice)
        {
            case "Rock":
                {
                    switch (computerChoice)
                    {
                        case "Rock":
                            return tie;
                        case "Scissors":
                            return playerWins;
                        case "Lizard":
                            return playerWins;
                        case "Paper":
                            return computerWins;
                        case "Spock":
                            return computerWins;
                    }
                    break;
                }

            case "Paper":
                {
                    switch (computerChoice)
                    {
                        case "Rock":
                            return playerWins;
                        case "Scissors":
                            return computerWins;
                        case "Lizard":
                            return computerWins;
                        case "Paper":
                            return tie;
                        case "Spock":
                            return playerWins;
                    }
                    break;
                }

            case "Scissors":
                {
                    switch (computerChoice)
                    {
                        case "Rock":
                            return computerWins;
                        case "Scissors":
                            return tie;
                        case "Lizard":
                            return playerWins;
                        case "Paper":
                            return playerWins;
                        case "Spock":
                            return computerWins;
                    }
                    break;
                }

            case "Lizard":
                {
                    switch (computerChoice)
                    {
                        case "Rock":
                            return computerWins;
                        case "Scissors":
                            return playerWins;
                        case "Lizard":
                            return tie;
                        case "Paper":
                            return computerWins;
                        case "Spock":
                            return playerWins;
                    }
                    break;
                }

            case "Spock":
                {
                    switch (computerChoice)
                    {
                        case "Rock":
                            return playerWins;
                        case "Scissors":
                            return playerWins;
                        case "Lizard":
                            return computerWins;
                        case "Paper":
                            return computerWins;
                        case "Spock":
                            return tie;
                    }
                    break;
                }
        }
        return "Error, this is not supposed to happen!";
    }
}