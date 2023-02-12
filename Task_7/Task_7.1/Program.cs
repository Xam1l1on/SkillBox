using System.ComponentModel.Design;
using System.Runtime.CompilerServices;

namespace Task_7._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathToFile = "Emploees.txt";
            Repository repository = new Repository(pathToFile);
            Console.WriteLine("Нажмите 1 чтобы увидеть всех пользователей\nНажмите 2 чтобы добавить сотрудника\nнажмите 3 чтобы удалить пользователя" +
                "\nНажмите 4 чтобы найти пользователя по номеру\nНажмите 5, чтобы найти пользователей по дате создания");
            switch (int.Parse(Console.ReadLine()))
            {
                default:
                    break;
                case 1:
                    repository.PrintDbToConsole();
                    Console.ReadLine();
                    break;
                case 2:
                    char keyContinue;
                    do
                    {
                        Console.WriteLine("Введите Фамилию Имя Отчество работника");
                        string fioEmp = Console.ReadLine();
                        Console.WriteLine("Возраст");
                        int ageEmp = int.Parse(Console.ReadLine());
                        Console.WriteLine("Рост");
                        double heigthEmp = double.Parse(Console.ReadLine());
                        Console.WriteLine("Дата рождения");
                        DateOnly birhtdayEmp = DateOnly.Parse(Console.ReadLine());
                        Console.WriteLine("Место рождения");
                        string birhplaceEmp = Console.ReadLine();
                        repository.AddWorker(new Worker(repository.Count, DateTime.Now, fioEmp, ageEmp, heigthEmp, birhtdayEmp, birhplaceEmp));
                        Console.Write($"Продолжить заполнять? Нажмите 'д'\n");
                        keyContinue = Console.ReadKey().KeyChar;
                        repository.SaveEmp();
                    } while (keyContinue == 'д');

                    break;
                 case 3:
                    Console.WriteLine("Введите номер сотрудника");
                    int IDEmp = int.Parse(Console.ReadLine());
                    repository.DeleteWorker(IDEmp);
                    break;
                case 4:
                    Console.WriteLine("Введите номер сотрудника");
                    int IDEmp2 = int.Parse(Console.ReadLine());
                    repository.GetWorkerById(IDEmp2);
                    Console.ReadLine();
                    break;
                case 5:
                    Console.WriteLine($"Введите две даты от: и до:");
                    DateTime datefrom = DateTime.Parse(Console.ReadLine());
                    DateTime dateto = DateTime.Parse(Console.ReadLine());
                    repository.GetWorkersBetweenTwoDates(datefrom, dateto);
                    Console.ReadLine();
                    break;
            }
        }
        public void MenuMain()
        {
            Console.WriteLine("Нажмите 1 чтобы увидеть всех пользователей\nНажмите 2 чтобы добавить сотрудника");
        }
    }
}