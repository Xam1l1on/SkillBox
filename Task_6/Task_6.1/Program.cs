// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Threading.Channels;
using System.Xml.Linq;

class Employees
{
    public static void Main(string[] args)
    {
        Employees employees = new Employees();
        string pathEmp = "Employees.txt";
        Console.WriteLine("Показать сотрудников - нажмите 1 \nВвести нового сотрудника - нажмите 2");
        employees.ChoiceInput(int.Parse(Console.ReadLine()),pathEmp);
        //employees.Writer(pathEmp);
        //employees.Reader(pathEmp);
        Console.ReadLine();
    }
    /// <summary>
    /// Запись сотрудника
    /// </summary>
    void Writer(string strPath)
    {
        char numContinue;
        if (File.Exists(strPath) == false)
        {
            File.Create(strPath).Close();
            Writer(strPath);
        }
        else
        {
            do
            {
                int IDEmp = File.ReadAllLines(strPath).Count();
                using (StreamWriter strWriter = new StreamWriter(strPath, true))
                {
                    IDEmp += 1;
                    DateTime dateInput = DateTime.Now;
                    //string nameEmp = string.Empty;
                    Console.WriteLine("\nФамилия");
                    string lastname = Console.ReadLine();
                    Console.WriteLine("Имя сотрудника");
                    string patronymic = Console.ReadLine();
                    Console.WriteLine("Отчество");
                    string name = Console.ReadLine();
                    Console.WriteLine("Возраст");
                    int age = int.Parse(Console.ReadLine());
                    Console.WriteLine("Рост");
                    double height = double.Parse(Console.ReadLine());
                    Console.WriteLine("Дата рождения");
                    DateOnly birthday = DateOnly.Parse(Console.ReadLine());
                    Console.WriteLine("Место рождения");
                    string birthplace = Console.ReadLine();
                    strWriter.WriteLine($"{IDEmp}#{dateInput}#{lastname} {patronymic} {name}#{age}#{height}#{birthday}#{birthplace}");
                    //strWriter.WriteLine(nameEmp);
                }
                Console.WriteLine("Продолжить заполнять? Нажмите 2 \nЗавершить заполнение - нажмите 3");
                numContinue = Console.ReadKey().KeyChar;

            } while (numContinue == '2');
        }
    }
    void Reader(string strPath)
    {
        if (File.Exists(strPath) == false)
        {
            Console.WriteLine("Файл не существует");
        }
        else
        {
            using (StreamReader strReader = new StreamReader(strPath, false))
            {
                string line;
                while ((line = strReader.ReadLine()) != null)
                {
                    Console.WriteLine(line.Replace('#', ' '));
                }
            }
        }
    }
    void ChoiceInput(int chooseNum, string strPath)
    {
        //int num = int.Parse(Console.ReadLine());
        switch (chooseNum)
        {
            default:
                Console.WriteLine("Введите то, что вас просят!!!");
                break;
            case 1:
                Reader(strPath);
                break;
            case 2:
                Writer(strPath);
                break;
            case 3:
                Console.WriteLine("До свидания!");
                break;
        }
    }
}
