﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10._1
{
    class Consultant : IEmployee
    {
        #region Реализация интерфейса IEmployee
        public string Name { get; set; }
        public bool isEmployeeAccess() => false;
        #endregion

    }
}
