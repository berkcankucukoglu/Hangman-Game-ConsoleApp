internal class Program
{
    private static void Main(string[] args)
    {
        var selectedWord = RandomStringSelector(_randomStrings);
        var controlString = string.Empty;
        var lives = 10;
        var timesPlayed = 0;
        Console.WriteLine($"Please guess the word that has {selectedWord.Length} characters!");
        for (int i = 0; i < selectedWord.Length; i++)
        {
            controlString += '*';
            Console.Write('*');
        }
        var liveTestString = controlString;
        Console.WriteLine();
        Console.WriteLine($"You have {lives} guesses. Please make a guess: \n");
        while (lives > 0)
        {
            var key = Console.ReadKey(true);

            for (int j = 0; j < selectedWord.Length; j++)
            {
                if (selectedWord[j] == key.KeyChar)
                {
                    controlString = controlString.Remove(j, 1);
                    controlString = string.Concat(controlString.Substring(0, j), key.KeyChar, controlString.Substring(j));
                }
            }
            if (controlString == liveTestString && !controlString.Contains(key.KeyChar))
            {
                lives--;
                liveTestString = controlString;
                Console.WriteLine($"You made a wrong guess! The letter \"{key.KeyChar}\" is not found in the word!");
                if (lives != 0)
                {
                    Console.Write($"Now you have {lives} tries. Please make another guess:\n");
                }
            }
            if (controlString != liveTestString)
            {
                liveTestString = controlString;
                Console.WriteLine($"Bravo! \"{key.KeyChar}\" is in the word!");
            }
            timesPlayed++;
            Console.WriteLine(controlString);
            if (!controlString.Contains('*'))
            {
                Console.WriteLine($"You made {timesPlayed} guesses in total!");
                Console.WriteLine("Victory! You found the right word!");
                break;
            }
        }
        if (lives == 0)
        {
            Console.WriteLine($"GGs! the right word was:\n{selectedWord}");
        }
    }

    private static List<string> _randomStrings = new List<string>()
    {
        "tsubasaozora",
        "kajirohyuga",
        "taromisaki",
        "kenwakashimazu",
        "takeshisawada",
        "hiroshijito",
        "berkcankucukoglu"
    };
    private static string RandomStringSelector(List<string> list)
    {
        Random randomNumber = new Random();
        var pick = randomNumber.Next(0,list.Count);
        return list[pick];
    }
}