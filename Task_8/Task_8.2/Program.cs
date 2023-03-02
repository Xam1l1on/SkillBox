using System.Runtime.CompilerServices;

namespace Task_8._2
{
    internal class Program
    {
        Users user;
        Dictionary<ulong, Users> dicUser = new Dictionary<ulong, Users>();
        static void Main(string[] args)
        {
            Program pr = new Program();
            Console.WriteLine($"Добавьте пользователя");
            ulong nubPhoneUser;
            pr.AddUser();
            Console.WriteLine("Найдите нужного пользователя,\n введя номер телефона");
            nubPhoneUser = ulong.Parse(Console.ReadLine());
            pr.GetUser(nubPhoneUser);
            Console.ReadLine();
        }
        void AddUser()
        {
            ulong numPhone;
            string lastnameUser;
            string nameUser;
            string surnameUser;
            string checkInputUser = Console.ReadLine();
            while (!string.IsNullOrEmpty(checkInputUser))
            {
                Console.WriteLine($"Введите номер телефона");
                numPhone = ulong.Parse(Console.ReadLine());
                Console.WriteLine($"Введите фамилию");
                lastnameUser = Console.ReadLine();
                Console.WriteLine($"Введите Имя");
                nameUser = Console.ReadLine();
                Console.WriteLine($"Введите Отчество");
                surnameUser = Console.ReadLine();
                user = new Users(nameUser, surnameUser, lastnameUser);
                dicUser.Add(numPhone, user);
                Console.WriteLine("Продолжить? введите 'да'");
                checkInputUser = Console.ReadLine();
            }
        }
        void GetUser(ulong id)
        {
            foreach (var itemUser in dicUser)
            {
                if (dicUser.ContainsKey(id))
                {
                    Console.WriteLine($"{itemUser.Key} {itemUser.Value.Lastname} {itemUser.Value.Name} {itemUser.Value.Surname}");
                }
                else
                {
                    Console.WriteLine("Такого пользователя нет");
                }
            }
        }
    }
}