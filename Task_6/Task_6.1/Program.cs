// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Threading.Channels;

class Employees
{
    public static void Main(string[] args)
    {
        string pathEmp = @"E:\SkillBox\FilesforTasks\Task_6.1\Employees.txt";
        Console.WriteLine("Показать сотрудников - нажмите 1 \nВвести нового сотрудника - нажмите 2");
        ChoiceInput();
        int IDEmp;
        DateTime dateInput;
        string nameEmp;
        string patronymicEmp;
        string lastnameEmp;
        int ageEmp;
        double heightEmp;
        DateOnly birthday;
        string birthplaceEmp;
        Console.ReadLine();
        void Writer()
        {
            if (File.Exists(pathEmp) == false)
            {
                File.Create(pathEmp).Close();
                Writer();
                
            }
            else
            {
                IDEmp = File.ReadAllLines(pathEmp).Count();
                using (StreamWriter strWriter = new StreamWriter(pathEmp, false))
                {
                    IDEmp += 1;
                    dateInput = DateTime.Now;
                    //string nameEmp = string.Empty;
                    Console.WriteLine("Фамилия");
                    lastnameEmp = Console.ReadLine();
                    Console.WriteLine("Имя сотрудника");
                    nameEmp = Console.ReadLine();
                    Console.WriteLine("Отчество");
                    patronymicEmp = Console.ReadLine();
                    Console.WriteLine("Возраст");
                    ageEmp = int.Parse(Console.ReadLine());
                    Console.WriteLine("Рост");
                    heightEmp = double.Parse(Console.ReadLine());
                    Console.WriteLine("Дата рождения");
                    birthday = DateOnly.Parse(Console.ReadLine());
                    Console.WriteLine("Место рождения");
                    birthplaceEmp = Console.ReadLine();
                    strWriter.WriteLine($"{IDEmp}#{dateInput}#{lastnameEmp} {nameEmp} {patronymicEmp}#{ageEmp}#{heightEmp}#{birthday}#{birthplaceEmp}");
                    //strWriter.WriteLine(nameEmp);
                }
                Console.WriteLine("Продолжить заполнять? Нажмите 2 \nЗавершить заполнение - нажмите 3");
                ChoiceInput();
            }
        }
        static void Reader(string pathEmp)
        {
            if (File.Exists(pathEmp) == false)
            {
                Console.WriteLine("Файл не существует");
            }
            else
            {
                using (StreamReader strReader = new StreamReader(pathEmp))
                {
                    string line;
                    while ((line = strReader.ReadLine()) != null)
                    {
                        Console.WriteLine(line.Replace('#', ' '));
                    }
                }
            }
        }
        void ChoiceInput()
        {
            int choiceInput = int.Parse(Console.ReadLine());
            switch (choiceInput)
            {
                default:
                    Console.WriteLine("Введите то, что вас просят!!!");
                    break;
                case 1: Reader(pathEmp);
                    break;
                case 2: Writer();
                    break;
                case 3: Console.WriteLine("До свидания!");
                    break;
            }
        }
    }
}
