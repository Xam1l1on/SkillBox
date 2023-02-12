using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_7._1
{
    internal class Repository
    {
        private Worker[] workers;
        private string pathEmp;
        private int index;
        
        public Repository(string PathEmp) 
        {
            this.pathEmp = PathEmp;
            this.index = 0;
            this.workers = new Worker[1];
            CheckFile();
            GetAllWorkers();
        }
        /*public void EmpMenu(string strPath, int ID)
        {
            Console.WriteLine("показать всех сотрудников - нажмите 1");
            switch (int.Parse(Console.ReadLine()))
            {
                default:
                    Console.WriteLine("Введите из предложенного");
                    break;
                case 1:
                    GetAllWorkers(strPath);
                        break;
                case 2:
                    GetWorkerById(strPath, ID);
                    break;
            }
        }*/
        public Worker[] GetAllWorkers()
        {
            using (StreamReader strReader = new StreamReader(pathEmp, false))
            {
                while (!strReader.EndOfStream)
                {
                    string[] line = strReader.ReadLine().Split('#');
                    AddWorker(new Worker(int.Parse(line[0]), DateTime.Parse(line[1]), line[2], int.Parse(line[3]), double.Parse(line[4]),
                        DateOnly.Parse(line[5]), line[6]));
                }
            }
        return workers;
        }
        public Worker GetWorkerById(int id)
        {
            int i;
            for(i = 0; i <= id;i++)
            {
                if(workers[i].ID == id)
                {
                    Console.WriteLine(this.workers[i].PrintEmp());
                }
                
            }
            return workers[i];
        }
        public void DeleteWorker(int id)
        {
            File.Delete(pathEmp);
            for (int i = 0; i < this.index; i++)
            {
                if(i != id)
                {
                    string temp = String.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}",
                        this.workers[i].ID,
                        this.workers[i].dateCreate,
                        this.workers[i].FIO,
                        this.workers[i].Age,
                        this.workers[i].Height,
                        this.workers[i].Birthday,
                        this.workers[i].Birthplace);
                    File.AppendAllText(pathEmp, $"{temp}\n");
                }
            }
        }
        public void AddWorker(Worker worker)
        {
                Resize(index >= this.workers.Length);
                workers[index] = worker;
                index++;
        }
        public Worker[] GetWorkersBetweenTwoDates(DateTime datefrom, DateTime dateto)
        {
            var sortDate = workers.OrderBy(workers=>workers.dateCreate);
            foreach (var i in sortDate)
            {
                if (i.dateCreate >= datefrom & i.dateCreate <= dateto)
                {
                    Console.WriteLine(i.PrintEmp());
                }
                
            }
            /*for(int i = 0; i < sortDate.Length; i++)
            {
                Console.WriteLine(this.workers[i].PrintEmp());
            }*/
            /*for (int i = 0; i < index; i++)
            {
                if (workers[i].dateCreate >= dateFrom & workers[i].dateCreate <= dateTo)
                {
                    
                }
                Console.WriteLine(this.workers[i].PrintEmp());
            } */
            return workers;
        }
        /// <summary>
        /// Проверяет наличие файла. при отсутствии файла создает его.
        /// </summary>
        /*private void LoadEmp()
        {
            using (StreamReader sr = new StreamReader(this.pathEmp))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');
                    AddWorker(new Worker(int.Parse(args[0]), DateTime.Parse(args[1]), args[2], int.Parse(args[3]), double.Parse(args[4]), 
                        DateOnly.Parse(args[5]), args[6]));
                }
            }
        }*/
        private void CheckFile()
        {
            if (File.Exists(pathEmp) == false)
            {
                File.Create(pathEmp).Close();
            }
        }
        /// Метод увеличения текущего хранилища
        /// </summary>
        /// <param name="Flag">Условие увеличения</param>
        public void SaveEmp()
        {
            File.Delete(pathEmp);
            for (int i = 0; i < this.index; i++)
            {
                string temp = String.Format("{0}#{1}#{2}#{3}#{4}#{5}#{6}",
                                        this.workers[i].ID,
                                        this.workers[i].dateCreate,
                                        this.workers[i].FIO,
                                        this.workers[i].Age,
                                        this.workers[i].Height,
                                        this.workers[i].Birthday,
                                        this.workers[i].Birthplace);
                File.AppendAllText(pathEmp, $"{temp}\n");
            }
        }
        private void Resize(bool Flag)
        {
            if (Flag)
            {
                Array.Resize(ref this.workers, this.workers.Length * 2);
            }
        }
        public void PrintDbToConsole()
        {
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(this.workers[i].PrintEmp());
            }
        }
        public int Count { get { return this.index; } }
    }
}
