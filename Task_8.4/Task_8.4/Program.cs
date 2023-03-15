
using System.Xml;

namespace Task_8._4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathFileUser = "Users.xml";
            Console.WriteLine("ВВедите фамилию имя отчесво пользователя");
            string FIOUser = Console.ReadLine();
            Console.WriteLine("ВВедите улицу пользователя");
            string streetUser = Console.ReadLine();
            Console.WriteLine("ВВедите номер дома");
            int houseUser = int.Parse(Console.ReadLine());
            Console.WriteLine("ВВедите этаж дома");
            int flatUser = int.Parse(Console.ReadLine());
            Console.WriteLine("ВВедите мобильный номер пользователя");
            string mobileUser = Console.ReadLine();
            Console.WriteLine("ВВедите домашний телефон пользователя");
            string flatNumberUser = Console.ReadLine();
            UsersXML userXML = new UsersXML(FIOUser, streetUser, houseUser, flatUser, mobileUser, flatNumberUser);
            //userXML.SerializeFileUser(pathFileUser);

            userXML.CreateUsersXML(pathFileUser);
            Console.ReadLine();
        }
    }
}