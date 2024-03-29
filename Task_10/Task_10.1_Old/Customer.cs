﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10._1
{
    internal class Customer
    {
        #region Fields
        private string _lastname, _name, _middlename; //Фамимлия имя Отчество клиента
        private ulong _phoneNumber;  //Номер телефона. Номер паспорта клиента
        private int _passport;
        #endregion
        #region Properties
        public int ID { get; set; }
        public string Lastname { get { return _lastname; } set { _lastname = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public string Middlename { get { return _middlename; } set { _middlename = value; } }
        public ulong? PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value ?? throw new ArgumentNullException(nameof(value)); }
        }
        public int Passport
        {
            get { return isEmployeeAccess() ? _passport : 0; }
            set { if (isEmployeeAccess()) { _passport = value; } }
        }
        #endregion
        #region Constructor
        public Customer() { }
        public Customer(string name, string middlename, string lastname, ulong phoneNumber, int passport)
        {
            _lastname = lastname;
            _name = name;
            _middlename = middlename;
            _phoneNumber = phoneNumber;
            _passport = passport;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Метод преобразующий номер телефона клиента в набор символов '************'
        /// </summary>
        /// <returns></returns>
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
        public bool isEmployeeAccess() => false;
        #endregion
    }
}
