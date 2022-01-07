// See https://aka.ms/new-console-template for more information
Console.WriteLine("Привет, игрок!!!\n Сколько карт в твоей руке?!");
int countCards = int.Parse(Console.ReadLine());
int pointsONHands = 0;
for (int i = 1; i <= countCards; i++)
{
    Console.WriteLine($"Каким номиналом {i} -я карта?");
    string card = Console.ReadLine();
    switch (card)
    {
        case "J":
        case "Q":
        case "K":
        case "T":
            pointsONHands += 10;
            break;
        default:
            pointsONHands += int.Parse(card);
            break;
    }
}
Console.WriteLine($"\nКоличество карт на руке {countCards} \nСумма очков {pointsONHands}");
Console.ReadLine();
