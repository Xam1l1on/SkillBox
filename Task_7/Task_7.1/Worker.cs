using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7._1
{
    internal struct Worker
    {
        #region Fields
        /// <summary>
        /// Private Fields
        /// </summary>
        private int _id;
        private DateTime _dateCreate;
        private string _FIO;
        private int _age;
        private double _height;
        private DateOnly _birthday;
        private string _birthplace;
        #endregion

        #region Properties
        /// <summary>
        /// Properties 
        /// </summary>
        public int ID { get => _id; set => _id = value; }
        /// <summary>
        /// Дата создания сотрудника
        /// </summary>
        public DateTime dateCreate { get => _dateCreate; set => _dateCreate = value; }
        /// <summary>
        /// Фамилия имя отчество сотрудника
        /// </summary>
        public string FIO { get => _FIO; set => _FIO = value; }
        public int Age { get => _age; set => _age = value; }
        public double Height { get => _height; set => _height = value; }
        public DateOnly Birthday { get => _birthday; set => _birthday = value; }
        public string Birthplace { get => _birthplace; set => _birthplace = value; }
        #endregion

        #region Constrictors
        public Worker(int id, DateTime dateCreate, string fio, int age, double heigth, DateOnly birthday, string birthplace)
        {
            _id = id;
            _dateCreate = dateCreate;
            _FIO = fio;
            _age = age;
            _height = heigth;
            _birthday = birthday;
            _birthplace = birthplace;
        }
        #endregion

        public string PrintEmp()
        {
            return $"{this.ID} {this.dateCreate} {this.FIO} {this.Age} {this.Height} {this.Birthday} {this.Birthplace}";
        }
    }

}
