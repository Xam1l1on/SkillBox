using System;
using System.Collections.Generic;
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
            this.CheckFile();
            this.LoadEmp();
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
                    this.Resize(index >= this.workers.Length);
                    string[] line = strReader.ReadLine().Split('#');
                    workers[index] = new Worker(int.Parse(line[0]), Convert.ToDateTime(line[1]), line[2], int.Parse(line[3]), 
                        double.Parse(line[4]), DateOnly.Parse(line[5]), line[6]);
                }
            }
        return workers;
        }
        public Worker GetWorkerById(int id)
        {
            int i = 0;
            while (workers[i].ID == id)
            {
                i++;
                id = i;
            }
            return workers[id];
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
                //strWriter.WriteLine($"{worker.ID}#{worker.dateCreate}#{worker.FIO}#{worker.Age}#{worker.Height}#{worker.Birthday}#{worker.Birthplace}");
                index++;
        }
        /*Worker[] GetWorkersBetweenTwoDates(DateTime dateFrom, DateTime dateTo)
        {
             // здесь происходит чтение из файла
             // фильтрация нужных записей
             // и возврат массива считанных экземпляров
        }*/
        /// <summary>
        /// Проверяет наличие файла. при отсутствии файла создает его.
        /// </summary>
        private void LoadEmp()
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
        }
        void CheckFile()
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
