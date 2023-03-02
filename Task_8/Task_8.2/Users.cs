using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8._2
{
    internal struct Users
    {

        /// <summary>
        /// Fields
        /// </summary>
        #region Fields
        private string _name;
        private string _surname;
        private string _lastname;
        #endregion
        /// <summary>
        /// Properties
        /// </summary>
        #region Properties
        public string Name { get { return _name; } set { _name = value; } }
        public string Surname { get { return _surname; } set { _surname = value; } }
        public string Lastname { get { return _lastname; } set { _lastname = value; } }
        #endregion
        /// <summary>
        /// Constructs
        /// </summary>
        /// <param name="name"></param>
        /// <param name="surname"></param>
        /// <param name="lastname"></param>
        #region Constructs
        public Users(string name, string surname, string lastname)
        {
            _name= name;
            _surname = surname;
            _lastname = lastname;
        }
        #endregion
        public string PrintUser()
        {
            return $"{this.Name} {this.Surname} {this.Lastname}";
        }
    }
}
