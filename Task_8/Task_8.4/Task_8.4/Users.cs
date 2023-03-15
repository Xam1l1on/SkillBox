using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8._4
{
    public class Users
    {
        #region Fields
        private string _FIO;
        private string _street;
        private int _houseNumber;
        private int _flatNumber;
        private string _mobilePhone;
        private string _flatPhone;
        #endregion
        /// <summary>
        /// Properties 
        /// </summary>
        #region Properties
        public string FIO { get => _FIO; set => _FIO = value; }
        public string Street { get => _street; set => _street = value; }
        public int HouseNumber { get => _houseNumber; set => _houseNumber = value; }
        public int FlatNumber { get => _flatNumber; set => _flatNumber = value; }
        public string MobilePhone { get => _mobilePhone; set => _mobilePhone = value; }
        public string FlatPhone { get => _flatPhone; set => _flatPhone = value; }
        #endregion

        #region Constrictors
        public Users() { }
        public Users(string fio, string street, int houseNumber, int flatNumber, string mobilePhone, string flatPhone)
        {
            FIO = fio;
            Street = street;
            HouseNumber = houseNumber;
            FlatNumber = flatNumber;
            MobilePhone = mobilePhone;
            FlatPhone = flatPhone;
        }
        #endregion

        public string PrintEmp()
        {
            return $"{this.FIO} {this.Street} {this.HouseNumber} {this.FlatNumber} {this.MobilePhone} {this.FlatNumber}";
        }
    }
}
