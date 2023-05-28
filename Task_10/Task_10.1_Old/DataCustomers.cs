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
using System.Reflection.PortableExecutable;

namespace Task_10._1
{
    internal class DataCustomers
    {
        Customer customer;
        ObservableCollection<Customer> customers;
        private string _nameFileCustomers = "customers.xml";
        public string NameFileCustomers { get { return _nameFileCustomers;}  set { _nameFileCustomers = value; } }
        public DataCustomers() 
        {
            LoadCustomer();
            customers = new ObservableCollection<Customer>();
        }
        public string ShowCustomerName() 
        { 
            return customer.Name;
        }
        public int CustID { get { return customer.ID; } }
        public string CustName { get {  return customer.Name; } }
        public string CustMidname { get { return customer.Middlename; } }
        public string CustLastname { get { return customer.Lastname; } }

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
            using (XmlReader xmlReader = XmlReader.Create(NameFileCustomers))
            {
                while (xmlReader.Read())
                {
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "Customer")
                    {
                        // Create a new Customer object.
                        customer = new Customer();

                        // Get the ID attribute value and assign it to the Customer object.
                        if (xmlReader.HasAttributes)
                        {
                            while (xmlReader.MoveToNextAttribute())
                            {
                                if (xmlReader.Name == "ID")
                                {
                                    customer.ID = int.Parse(xmlReader.Value);
                                }
                            }
                        }
                    }
                    // Check if the current node is a Name, Middlename, or Lastname element inside the FullName element.
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "Name" && xmlReader.Read())
                    {
                        customer.Name = xmlReader.Value;
                    }
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "Middlename" && xmlReader.Read())
                    {
                        customer.Middlename = xmlReader.Value;
                    }
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "Lastname" && xmlReader.Read())
                    {
                        customer.Lastname = xmlReader.Value;
                    }
                    // Check if the current node is a PhoneNumber or Passport element inside the Data element.
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "PhoneNumber" && xmlReader.Read())
                    {
                        customer.PhoneNumber = ulong.Parse(xmlReader.Value);
                    }
                    if (xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "Passport" && xmlReader.Read())
                    {
                        customer.Passport = int.Parse(xmlReader.Value);
                    }
                    // Check if the current node is an end element for a Customer element.
                    if (xmlReader.NodeType == XmlNodeType.EndElement && xmlReader.Name == "Customer")
                    {
                        // Add the Customer object to the list of customers.
                        customers.Add(customer);
                    }
                }
            }
        }
        //Add customer to List
        public void AddCustomer(string name, string midname, string lastname, uint phone, int passport)
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
            XmlNode customers = doc.CreateElement("Customers");
            doc.AppendChild(customers);
            XmlNode cust = doc.CreateElement("Customer");
            customers.AppendChild(cust);
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
