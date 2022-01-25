// See https://aka.ms/new-console-template for more information
Console.WriteLine("Введите длину последовательности!");
int lengthSequence = int.Parse(Console.ReadLine());
int [] arr = new int[lengthSequence];
int minElement = int.MaxValue;
for(int i = 0; i < lengthSequence; i++)
{
    Console.WriteLine($"Введите элемент {i}");
    arr[i] = int.Parse(Console.ReadLine());
}
for(int i = 0; i < arr.Length; i++)
{
    if(arr[i] < minElement)
    {
        minElement = arr[i];
    }
    Console.Write($"{arr[i]}, ");
}
Console.WriteLine($"\n\nНаименьшее число в последовательности = {minElement}");
Console.ReadLine();
