using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Task_8._4
{
    public class UsersXML
    {
        Users anyUsers;
        public UsersXML()
        {
            anyUsers= new Users();
        }
        public UsersXML(string fio, string street, int houseNumber, int flatNumber, string mobilePhone, string flatPhone)
        {
            anyUsers = new Users(fio,street,houseNumber,flatNumber,mobilePhone,flatPhone);
        }
        public void CreateUsersXML(string path)
        {
            using (Stream fStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                XElement person = new XElement("Person",
                    new XElement("Adress",
                        new XElement("Street", anyUsers.Street),
                        new XElement("HouseNumber",anyUsers.HouseNumber),
                        new XElement("FlatNumber"),anyUsers.FlatNumber),
                    new XElement("Phones",
                        new XElement("MobilePhone",anyUsers.MobilePhone),
                        new XElement("FlatPhone",anyUsers.FlatPhone)));
                XAttribute FIO = new XAttribute("name", anyUsers.FIO);
                person.Add(FIO);
                person.Save(fStream);
            }
        }
    }
}
