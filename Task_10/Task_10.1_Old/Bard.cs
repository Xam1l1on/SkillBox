using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;

namespace Task_10._1
{
    public interface IConsultant
    {
        void ChangePhoneNumber(string phoneNumber);
    }

    public interface IManager : IConsultant
    {
        void AddNewClientData(string lastName, string name, string middleName, string phoneNumber, string passportSeries, string passportNumber);
        void ChangeSurname(string surname);
        void ChangeName(string name);
        void ChangeMiddleName(string middleName);
        void ChangePassportSeries(string passportSeries);
        void ChangePassportNumber(string passportNumber);
    }

    public abstract class Person
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
    }

    public abstract class Document
    {
        public string PassportSeries { get; set; }
        public string PassportNumber { get; set; }
    }

    public class Client : Person, Document
    {
        public string PhoneNumber { get; set; }
        public DateTime DateModified { get; set; }
        public string DataChanged { get; set; }
        public string TypeOfChange { get; set; }
        public string WhoChangedData { get; set; }

        public Client(string surname, string name, string middleName, string phoneNumber, string passportSeries, string passportNumber)
        {
            Surname = surname;
            Name = name;
            MiddleName = middleName;
            PhoneNumber = phoneNumber;
            PassportSeries = passportSeries;
            PassportNumber = passportNumber;
            DateModified = DateTime.Now;
            DataChanged = "";
            TypeOfChange = "";
            WhoChangedData = "";
        }

        public void ChangePhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            DateModified = DateTime.Now;
            DataChanged = "Phone Number";
            TypeOfChange = "Change";
            WhoChangedData = "Consultant";
        }

    }

    public class Manager : Client, IManager
    {
        public Manager(string surname, string name, string middleName, string phoneNumber, string passportSeries, string passportNumber) : base(surname, name, middleName, phoneNumber, passportSeries, passportNumber)
        {

        }

        public void AddNewClientData(string lastName, string name, string middleName, string phoneNumber, string passportSeries, string passportNumber)
        {
            Surname = lastName;
            Name = name;
            MiddleName = middleName;
            PhoneNumber = phoneNumber;
            PassportSeries = passportSeries;
            PassportNumber = passportNumber;
            DateModified = DateTime.Now;
            DataChanged = "All";
            TypeOfChange = "Add";
            WhoChangedData = "Manager";
        }

        public void ChangeSurname(string surname)
        {
            Surname = surname;
            DateModified = DateTime.Now;
            DataChanged = "Surname";
            TypeOfChange = "Change";
            WhoChangedData = "Manager";
        }

        public void ChangeName(string name)
        {
            Name = name;
            DateModified = DateTime.Now;
            DataChanged = "Name";
            TypeOfChange = "Change";
            WhoChangedData = "Manager";
        }

        public void ChangeMiddleName(string middleName)
        {
            MiddleName = middleName;
            DateModified = DateTime.Now;
            DataChanged = "Middle Name";
            TypeOfChange = "Change";
            WhoChangedData = "Manager";
        }

        public void ChangePassportSeries(string passportSeries)
        {
            PassportSeries = passportSeries;
            DateModified = DateTime.Now;
            DataChanged = "Passport Series";
            TypeOfChange = "Change";
            WhoChangedData = "Manager";
        }

        public void ChangePassportNumber(string passportNumber)
        {
            PassportNumber = passportNumber;
            DateModified = DateTime.Now;
            DataChanged = "Passport Number";
            TypeOfChange = "Change";
            WhoChangedData = "Manager";
        }
    }
    public class Person : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class PersonViewModel : INotifyPropertyChanged
    {
        private Person _person;

        public PersonViewModel()
        {
            _person = new Person();
            _person.FirstName = "John";
            _person.LastName = "Doe";
        }

        public string FirstName
        {
            get { return _person.FirstName; }
            set
            {
                if (_person.FirstName != value)
                {
                    _person.FirstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get { return _person.LastName; }
            set
            {
                if (_person.LastName != value)
                {
                    _person.LastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new PersonViewModel();
        }
    }


}
