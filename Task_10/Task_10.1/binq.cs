using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Task_10._1
{
    internal class binq
    {
    }

public class ClientData
    {
        private string surname;
        private string name;
        private string patronymic;
        private string phoneNumber;
        private string passportSeries;
        private string passportNumber;

        public ClientData(string surname, string name, string patronymic, string phoneNumber, string passportSeries, string passportNumber)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.phoneNumber = phoneNumber;
            this.passportSeries = passportSeries;
            this.passportNumber = passportNumber;
        }

        public string Surname
        {
            get { return surname; }
            private set { surname = value; }
        }

        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public string Patronymic
        {
            get { return patronymic; }
            private set { patronymic = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                phoneNumber = value;
            }
        }

        public string PassportSeries
        {
            get
            {
                if (this.IsReadOnly)
                {
                    return "******************";
                }
                return passportSeries;
            }
            private set { passportSeries = value; }
        }

        public string PassportNumber
        {
            get
            {
                if (this.IsReadOnly)
                {
                    return "******************";
                }
                return passportNumber;
            }
            private set { passportNumber = value; }
        }

        public bool IsReadOnly
        {
            get { return phoneNumber == null; }
        }
    }
    public class Manager : Consultant
    {
        public Manager(string surname, string name, string patronymic, string phoneNumber, string passportSeries, string passportNumber)
            : base(surname, name, patronymic, phoneNumber, passportSeries, passportNumber)
        {
        }

        public void AddClientData(string surname, string name, string patronymic, string phoneNumber, string passportSeries, string passportNumber)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.phoneNumber = phoneNumber;
            this.passportSeries = passportSeries;
            this.passportNumber = passportNumber;
        }
    }
   
public interface IClientData
    {
        string Surname { get; set; }
        string Name { get; set; }
        string Patronymic { get; set; }
        string PhoneNumber { get; set; }
        string PassportSeries { get; set; }
        string PassportNumber { get; set; }
        DateTime ModifiedDate { get; set; }
        string ChangedData { get; set; }
        string TypeOfChange { get; set; }
        string ChangedBy { get; set; }
    }

    public interface IClientDataChanger
    {
        void ChangeClientData(IClientData clientData);
    }

    public class Consultant : IClientDataChanger
    {
        public Consultant(IClientData clientData)
        {
            this.Surname = clientData.Surname;
            this.Name = clientData.Name;
            this.Patronymic = clientData.Patronymic;
            this.PhoneNumber = clientData.PhoneNumber;
            this.PassportSeries = clientData.PassportSeries;
            this.PassportNumber = clientData.PassportNumber;
        }

        public void ChangeClientData(IClientData clientData)
        {
            if (clientData.PhoneNumber != null)
            {
                this.PhoneNumber = clientData.PhoneNumber;
            }
        }
    }

    public class Manager : IClientDataChanger
    {
        public Manager(IClientData clientData)
            : base(clientData)
        {
        }

        public void ChangeClientData(IClientData clientData)
        {
            this.Surname = clientData.Surname;
            this.Name = clientData.Name;
            this.Patronymic = clientData.Patronymic;
            this.PhoneNumber = clientData.PhoneNumber;
            this.PassportSeries = clientData.PassportSeries;
            this.PassportNumber = clientData.PassportNumber;
        }

        public void AddClientData(IClientData clientData)
        {
            this.Surname = clientData.Surname;
            this.Name = clientData.Name;
            this.Patronymic = clientData.Patronymic;
            this.PhoneNumber = clientData.PhoneNumber;
            this.PassportSeries = clientData.PassportSeries;
            this.PassportNumber = clientData.PassportNumber;
        }
    }
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ClientDataViewModel _viewModel;

        public MainWindow()
        {
            _viewModel = new ClientDataViewModel();
            DataContext = _viewModel;

            Loaded += (o, args) =>
            {
                _viewModel.LoadData();
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ClientDataViewModel : INotifyPropertyChanged
    {
        private List<ClientData> _clients;

        public ClientDataViewModel()
        {
            _clients = new List<ClientData>();
        }

        public List<ClientData> Clients
        {
            get { return _clients; }
            set
            {
                if (_clients == value)
                {
                    return;
                }

                _clients = value;
                OnPropertyChanged();
            }
        }

        public void LoadData()
        {
            // TODO: Load data from a database or other data source.

            Clients.Add(new ClientData
            {
                Surname = "Smith",
                Name = "John",
                Patronymic = "Doe",
                PhoneNumber = "123-456-7890",
                PassportSeries = "AA",
                PassportNumber = "123456"
            });

            Clients.Add(new ClientData
            {
                Surname = "Jones",
                Name = "Jane",
                Patronymic = "Doe",
                PhoneNumber = "555-555-5555",
                PassportSeries = "BB",
                PassportNumber = "678901"
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
