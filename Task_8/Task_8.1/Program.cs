using System.Collections.Generic;

namespace Task_8._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> naturalNumber = new List<int>();
            Random randomNumber = new Random();
            Program prg= new Program();
            prg.FillList(naturalNumber, randomNumber);
            prg.ShowList(naturalNumber);
            prg.DeleteList(naturalNumber);
            prg.ShowList(naturalNumber);
        }
        public void FillList(List<int> ints, Random randInts) 
        {
            for (int i = 0; i < 100; i++)
            {
                ints.Add(randInts.Next(0,100));
            }
        }
        public void ShowList(List<int> ints) 
        {
            int i = 0;
            foreach (var item in ints)
            {
                Console.WriteLine($"Число {i} = {ints[i]}");
                i++;
            }
            Console.ReadLine();
        }
        public void DeleteList(List<int> ints) 
        {
            for (int item = ints.Count - 1; item >= 0; item--)
            {
                if (ints[item] >= 25 && ints[item] <= 50)
                {
                    ints.RemoveAt(item);
                }
            }
        }
    }
}