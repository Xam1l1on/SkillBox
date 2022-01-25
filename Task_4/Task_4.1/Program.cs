// See https://aka.ms/new-console-template for more information
Console.WriteLine("Введите количество строк в матрице");
int row = int.Parse(Console.ReadLine());
Console.WriteLine("Введите количество столбцов в матрице");
int column = int.Parse(Console.ReadLine());
int[,] arr = new int[row, column];
Random rand = new Random();
int sum = 0;
for (int i = 0; i < row; i++)
{
    for(int j = 0; j < column; j++)
    {
        arr[i, j] = rand.Next(1, 100);
        Console.Write($"{arr[i, j], 3} ");
        sum += arr[i, j];
    }
    Console.WriteLine();
}
Console.WriteLine($"\nСумма элементов матрицы = {sum}");
Console.ReadLine();