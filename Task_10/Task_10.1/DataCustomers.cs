using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Windows.Shapes;
using System.Xml;
using System.Data;
using System.Collections.ObjectModel;

namespace Task_10._1
{
    internal class DataCustomers
    {
        Customer customer;
        private readonly string _pathToFileCustomers = "";
        ObservableCollection<Customer> customers;
        private string _nameFileCustomers = "customers.xml";
        public string NameFileCustomers { get { return _nameFileCustomers;}  set { _nameFileCustomers = value; } }
        private string _nameFileCustomers2 = "customers2.xml";
        public string NameFileCustomers2 { get { return _nameFileCustomers2; } set { _nameFileCustomers2 = value; } }
        public DataCustomers() 
        {
            customers = new ObservableCollection<Customer>();
        }
        public string ShowCustomer() 
        { 
            return customer.Name;
        }

        public bool isXmlFileExist()
        {
            bool existFile = false;
            if(File.Exists(NameFileCustomers))
            {
                existFile = true;
            }
            return existFile;
        }
        public void LoadCustomer()
        {
            XmlReader xmlReader = XmlReader.Create(NameFileCustomers);
            while(xmlReader.Read())
            {
                customer = new Customer();
                if(xmlReader.IsStartElement())
                {
                    xmlReader.ReadToFollowing("Name");
                    customer.Name = xmlReader.ReadElementContentAsString();
                    xmlReader.ReadToFollowing("Middlename");
                    customer.Middlename = xmlReader.ReadElementContentAsString();
                    xmlReader.ReadToFollowing("LastName");
                    customer = new Customer(xmlReader.ReadToFollowing("Name"), xmlReader.ReadToFollowing("Middlename"));
                }
            }
            XmlDocument readDoc = new XmlDocument();
            readDoc.Load("customers.xml");

            foreach (XmlNode node in readDoc.DocumentElement.ChildNodes)
            {
                string id = node.Attributes["ID"].Value;
                Console.WriteLine("Customer ID: " + id);

                XmlNode fullNameNode = node.SelectSingleNode("FullName");
                string name = fullNameNode.SelectSingleNode("Name").InnerText;
                string middle = fullNameNode.SelectSingleNode("MiddleName").InnerText;
                string last = fullNameNode.SelectSingleNode("LastName").InnerText;
                Console.WriteLine("Name: " + name + " " + middle + " " + last);

                XmlNode dataNode = node.SelectSingleNode("Data");
                string phone = dataNode.SelectSingleNode("PhoneNumber").InnerText;
                string passportNumber = dataNode.SelectSingleNode("Passport").InnerText;
                Console.WriteLine("Phone Number: " + phone);
                Console.WriteLine("Passport Number: " + passportNumber);
            }
        }
        public void AddCustomer(string name, string midname, string lastname, int phone, int passport)
        {
            customer = new Customer();
            customer.Name = name;
            customer.Middlename = midname;
            customer.Lastname = lastname;
            customer.PhoneNumber = phone;
            customer.Passport = passport;
            customers.Add(customer);
        }
        public void SaveCustomer()
        {
            customer = new Customer();
            XmlDocument doc = new XmlDocument();
            XmlDeclaration declaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(declaration);
            //Create Root baranch cutomers
            XmlNode customers = doc.CreateElement("Customer");
            doc.AppendChild(customers);
            XmlAttribute customersAtt = doc.CreateAttribute("ID");
            customers.Attributes?.Append(customersAtt);
            XmlNode customerFIO = doc.CreateElement("FullName");
            customers.AppendChild(customerFIO);
            XmlAttribute customerName = doc.CreateAttribute("Name");
            XmlAttribute customerMidname = doc.CreateAttribute("Middlename");
            XmlAttribute customerLastname = doc.CreateAttribute("Lastname");
            customerFIO.Attributes?.Append(customerName);
            customerName.Value = customer.Name;
            customerFIO.Attributes?.Append(customerMidname);
            customerMidname.Value = customer.Middlename;
            customerFIO.Attributes?.Append(customerLastname);
            customerLastname.Value = customer.Lastname;
            /*XmlElement customerName = doc.CreateElement("Name");
            customerFIO.AppendChild(customerName);
            XmlElement customerMidname = doc.CreateElement("Middlename");
            customerFIO.AppendChild(customerMidname);
            XmlElement customerLastname = doc.CreateElement("Lastname");
            customerFIO.AppendChild(customerLastname);*/
            XmlNode customerData = doc.CreateElement("Data");
            customers.AppendChild(customerData);
            XmlElement customerPhone = doc.CreateElement("PhoneNumber");
            customerData.AppendChild(customerPhone);
            customerPhone.Value = customer.PhoneNumber.ToString();
            XmlElement customerPassport = doc.CreateElement("Passport");
            customerData.AppendChild(customerPassport);
            customerPassport.Value = customer.Passport.ToString();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter xmlWriter = XmlWriter.Create(NameFileCustomers, settings);
            doc.Save(xmlWriter);
            xmlWriter.Close();

        }
    }
}
