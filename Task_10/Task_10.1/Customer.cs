using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10._1
{
    struct Customer
    {
        #region Fields
        string? _lastname, _name, _middlename;
        int _phoneNumber, _passport;
        #endregion
        #region Properties
        public string Lastname { get { return _lastname; } set { _lastname = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Middlename { get { return _middlename; } set { _middlename = value; } }
        public int PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }
        public int Passport { get { return _passport; } set { _passport = value; } }
        #endregion
        #region Constructor
        public Customer() : this ("","","",0) { }
        public Customer(string lastname,string name, string middlename, int phoneNumber) 
            : this (lastname, name,middlename, phoneNumber,0)
        {
            _lastname = lastname;
            _name = name;
            _middlename = middlename;
            _phoneNumber = phoneNumber;
        }
        public Customer(string lastname, string name, string middlename, int phoneNumber, int passport)
        {
            _lastname = lastname;
            _name = name;
            _middlename = middlename;
            _phoneNumber = phoneNumber;
            _passport = passport;
        }
        #endregion
        #region Methods
        internal string MaskedPassport()
        {
            string maskedPassport = string.Empty;
            if (this.Passport != null)
            {
                string stringPassport = Convert.ToString(this.Passport);
                maskedPassport = new string('*', stringPassport.Length - 1); 
            }
            return maskedPassport;
        }
        #endregion
    }
}
