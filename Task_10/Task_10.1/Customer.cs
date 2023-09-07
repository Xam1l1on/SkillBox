using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10._1
{
    internal class Customer
    {
        private int? _id;
        private string? _name;
        private string? _middlename;
        private string? _lastname;
        private string? _phone;
        private string? _passport;
        #region Properties
        public int? ID { get; set; }
        public string? Name { get; set; }
        public string? Middlename { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Passport { get; set; }
        #endregion
        public Customer() { }
        public Customer(int id)
        {
            ID = id;
        }
        public Customer(int id, string name, string middlename, string lastname,string phone, string passport)
        {
            ID = id;
            Name = name;
            Middlename = middlename;
            LastName = lastname;
            Phone = phone;
            Passport = passport;
        }
    }
}
