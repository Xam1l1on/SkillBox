// See https://aka.ms/new-console-template for more information
Console.WriteLine("Введите целое число");
int number = int.Parse(Console.ReadLine());
int i = 2;
bool simpleNumber = true;
while (i <= number / 2)
{
    if (number % i == 0)
    {
        simpleNumber = false;
        break;
    }
    i++;
}
if (simpleNumber)
{
    Console.WriteLine($"{number} - простое число");
}
else
{
    Console.WriteLine($"{number} - не простое число");
}
Console.ReadLine();
