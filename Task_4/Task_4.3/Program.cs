// See https://aka.ms/new-console-template for more information
Console.WriteLine("Введите максимальное целое число");
int maxNumber = int.Parse(Console.ReadLine());
Random random = new Random();
string numUser;
int searchNum = random.Next(0, maxNumber);
Console.WriteLine(searchNum);
do
{
    Console.WriteLine("Угадай число!");
    numUser = Console.ReadLine();
    if(numUser == " ")
    {
        Console.WriteLine($"Жаль, что ты не хочешь играть\nПравильный ответ {searchNum}");
        break;
    }
    else
    {
        if(searchNum > int.Parse(numUser))
        {
            Console.WriteLine("Загаданное число больше");
        }
        else if (searchNum < int.Parse(numUser))
        {
            Console.WriteLine("Загаданное число меньше");
        }
        else Console.WriteLine($"Правильно \nЗагаданное число = {searchNum}");
    }
} while (searchNum != int.Parse(numUser));
Console.ReadLine();
