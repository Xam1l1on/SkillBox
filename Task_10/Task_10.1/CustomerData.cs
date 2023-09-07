using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Diagnostics;
using System.Windows.Controls;
using System.Collections.ObjectModel;
//using System.Xml;

namespace Task_10._1
{
    class CustomerData
    {
        Customer? customer;
        ObservableCollection<Customer> custList = new ObservableCollection<Customer>();
        public void isFileCustomersExists(string fileName)
        {
            // check if the file exists
            if (!File.Exists(fileName))
            {
                // create a new XML file
                XDocument? doc = new XDocument(new XElement("Customers"));
                doc.Save(fileName);
            }
        }
        public void CreateXMLFileCustomers(string fileName)
        {

        }
        public void AddXMLFileCustomers(string fileName)
        {
            customer = new Customer();
            XDocument? root = XDocument.Load(fileName);
            XElement? customersXML = root.Element("Customers");
            customersXML?.Add(new XElement("Customer",new XAttribute("ID", customer.ID),
                new XElement("FullName",
                    new XElement("Name", customer.Name),
                    new XElement("Middlename", customer.Middlename),
                    new XElement("Lastname", customer.LastName)),
                new XElement("Data",
                    new XElement("PhoneNumber", customer.Phone),
                    new XElement("Passport", customer.Passport))
                ));

            root.Save(fileName);
        }
        public void LoadCustomersFromXML(string fileName)
        {
            isFileCustomersExists(fileName);
            XDocument? root = XDocument.Load(fileName);
            XElement? customers = root.Element("Customer");
            while (customers != null)
            {
                custList.Add(new Customer(Convert.ToInt32(customers.Attribute("Customer").Value)));
            }
        }
        public ObservableCollection<Customer> ChangeCustomer(string fileName, int id)
        {
            isFileCustomersExists(fileName);
            customer.ID = id;
            customer.Name = customer.ID.ToString();
            return custList;
        }
     }
}
