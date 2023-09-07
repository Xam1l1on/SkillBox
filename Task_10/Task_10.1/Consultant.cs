using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10._1
{
    class Consultant
    {
        Customer customer = new Customer();
        private bool _access;
        #region Properties
        public bool Access { get { return _access; } set { _access = value; } }
        #endregion
        #region Constructor
        public Consultant() { }
        public Consultant(bool access)
        {
            _access = access;
        }
        #endregion
        #region Metods
        public void ChangeDataCustomer()
        {

        }
        public void VisibleDataCustomer()
        {

        } 
        #endregion
    }
}
