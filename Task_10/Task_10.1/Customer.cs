using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10._1
{
    class Customer
    {
        private string _id;
        private string _name;
        private string _middlename;
        private string _lastname;
        private string _phone;
        private string _passport;
        #region Properties
        public string ID { get; set; }
        public string Name { get; set; }
        public string Middlename { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        #endregion
    }
}
