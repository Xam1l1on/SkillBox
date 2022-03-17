class SeparateMain
{
    public static void Main(string[] args)
    {
        string str = Console.ReadLine();
        SeparateWordsForString(str);
        Print(SeparateWordsForString(str));
        Console.ReadLine();
    }
    public static string[] SeparateWordsForString(string text)
    {
        string[] words = text.Split(new char[] {' '});
        return words;
    }
    public static void Print(string[] str)
    {
        foreach (var item in str)
        {
            Console.WriteLine($"{item}");
        }
    }
}

