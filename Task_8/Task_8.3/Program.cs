namespace Task_8._3
{
    internal class Program
    {
        HashSet<int> numberHS = new HashSet<int>();
        static void Main(string[] args)
        {
            Program pr = new Program();
            Console.WriteLine("Введите число");
            string numUser;
            while ((numUser = Console.ReadLine()) != null)
            {
                int i;
                int.TryParse(numUser, out i);
                if(i != 0)
                {
                    pr.AddNumber(i);
                }
                else
                {
                    Console.WriteLine("Введите число больше '0'");
                }
            }
            Console.ReadLine();
        }
        void AddNumber(int numberUser)
        {
            if (!numberHS.Contains(numberUser))
            {
                numberHS.Add(numberUser);
                Console.WriteLine($"Число успешно сохранено");
            }
            else 
            {
                Console.WriteLine($"Число {numberUser} присутствует в списке");
            }
        }
    }
}