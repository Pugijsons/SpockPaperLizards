namespace SpockPaperLizards;

public class PlayerGenerator
{
    private Random rand = new Random();

    private string[] firstWordParts = {
        "Bouncy", "Silly", "Cheerful", "Giggly", "Whimsy",
        "Zany", "Jolly", "Wacky", "Chubby", "Snazzy",
        "Dizzy", "Bubbly", "Jubilant", "Mirthful", "Quirky",
        "Jovial", "Frolic", "Chuckle", "Perky", "Zesty",
        "Witty", "Daffy", "Blissful", "Zippy", "Goofy",
        "Jittery", "Sprightly", "Zingy", "Peppy", "Hilarious"
    };

    private string[] secondWordParts = {
        "Banana", "Doodle", "Squiggle", "Bumble", "Noodle",
        "Pickle", "Wombat", "Muffin", "Scooter", "Gizmo",
        "Boomer", "Snicker", "Turtle", "Biscuit", "Jelly",
        "Nugget", "Schnitzel", "Dumpling", "Gadget", "Bamboo",
        "Penguin", "Noodle", "Pickle", "Muffin", "Scooter",
        "Gizmo", "Squid", "Bumble", "Zebra", "Wombat"
    };

    public string GenerateName()
    {
        int firstNumber = rand.Next(0, firstWordParts.Length);
        int secondNumber = rand.Next(0, secondWordParts.Length);
        return firstWordParts[firstNumber] + secondWordParts[secondNumber];
    }
}