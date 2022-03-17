class SeparateMain
{
    public static void Main(string[] args)
    {
        
        string str = Console.ReadLine();
        ReversePhrase(str);
        Console.ReadLine();
    }
    /// <summary>
    /// Разделение введенного пользователем предложения
    /// </summary>
    /// <param name="text"></param>
    /// <returns>Возвращает массив строк.</returns>
    public static string[] SplitString(string inputString)
    {
        string[] words = inputString.Split(new char[] { ' ' });
        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine(words[i]);
        }
        Console.WriteLine();
        return words;
    }
    public static string[] ReversePhrase(string inputString)
    {
        string[] resultString = SplitString(inputString);
        foreach (var item in resultString)
        {
            Array.Reverse(resultString);
        }
        foreach (var item in resultString)
        {
            Console.WriteLine(item);
        }
        
        return resultString;
    }
}
