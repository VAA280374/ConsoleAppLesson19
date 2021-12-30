using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppLesson19
{
    class Computer
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Processor { get; set; }
        public int FrecProcMGz { get; set; }
        public int RamGb { get; set; }
        public int HddGb { get; set; }
        public int VideoRamGb { get; set; }
        public decimal PriceUE { get; set; }
        public int NamberOfItems { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComputers = new List<Computer>()
            {
                new Computer() {Id = 1, Model = "Комп-1", Processor = "Intel Core i5", FrecProcMGz = 3500, RamGb = 16, HddGb = 1000, VideoRamGb = 4, PriceUE = 80000, NamberOfItems = 3},
                new Computer() {Id = 2, Model = "Комп-2", Processor = "Intel Core i3", FrecProcMGz = 2500, RamGb = 4, HddGb = 1000, VideoRamGb = 2, PriceUE = 40000, NamberOfItems = 8},
                new Computer() {Id = 3, Model = "Комп-3", Processor = "Intel Core i3", FrecProcMGz = 1500, RamGb = 2, HddGb = 1000, VideoRamGb = 0, PriceUE = 25000, NamberOfItems = 13},
                new Computer() {Id = 4, Model = "Комп-4", Processor = "Intel Core i3", FrecProcMGz = 3200, RamGb = 4, HddGb = 1000, VideoRamGb = 2, PriceUE = 60000, NamberOfItems = 6},
                new Computer() {Id = 5, Model = "Комп-5", Processor = "Intel Core i5", FrecProcMGz = 3700, RamGb = 8, HddGb = 1000, VideoRamGb = 4, PriceUE = 82000, NamberOfItems = 7},
                new Computer() {Id = 6, Model = "Комп-6", Processor = "Intel Core i7", FrecProcMGz = 3500, RamGb = 16, HddGb = 2000, VideoRamGb = 4, PriceUE = 102000, NamberOfItems = 1}

            };

            bool _true = true;
            int i = 1;

            List<string> processors = new List<string>(); // Формируем список возможных вариантов процессора
            processors.Add(null);
            foreach (Computer c in listComputers)
            {
                foreach (string p in processors)
                {
                    if (p == c.Processor)
                    { 
                        _true = false;
                        break;
                    }
                }
                if (_true) processors.Add(c.Processor);
                _true = true;
            }
            processors.RemoveAt(0);

            // Формируем выборку по типу процессора.
            Console.WriteLine("Выберите тип процессора из списка :"); 
            foreach (string p in processors)
            {
                Console.WriteLine("СТРОКА НОМЕР : {0}  ПРОЦЕССОР ТИПА : {1} ", i, p);
                i ++;
            }
            Console.Write(" ВВЕДИТЕ НОМЕР СТРОКИ : ");
            i = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.WriteLine();
            Console.WriteLine("С процессором {0} в наличии : ", processors[i]);
            List<Computer> listComputersP = listComputers
                .Where(c => c.Processor == processors[i])
                .ToList();
            foreach (Computer c in listComputersP)
            {
                Console.WriteLine("Артикул : {0}, Модель : {1}, Чатота процессора {2}МГц, Объем RAM={3}Гб, Объем HDD={4}Мб, Объем VideoRAM={5}Гб, Стоимость={6}У.Е., В наличии : {7}шт.", c.Id, c.Model,c.FrecProcMGz, c.RamGb, c.HddGb, c.VideoRamGb, c.PriceUE, c.NamberOfItems);
            }
            Console.WriteLine();

            // Формируем выборку по Объему памяти.
            Console.Write("Введите требуемый минимальный целый объем оперативный памяти в Гб : ");
            int vRAM = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine("С объемом оперативной памяти не менее {0}Гб в наличии : ", vRAM);
            List<Computer> listComputersRAM = listComputers
                .Where(c => c.RamGb >= vRAM)
                .ToList();
            foreach (Computer c in listComputersRAM)
            {
                Console.WriteLine("Артикул : {0}, Модель : {1}, Тип процессора : {8}, Чатота процессора {2}МГц, Объем RAM={3}Гб, Объем HDD={4}Мб, Объем VideoRAM={5}Гб, Стоимость={6}У.Е., В наличии : {7}шт.", c.Id, c.Model, c.FrecProcMGz, c.RamGb, c.HddGb, c.VideoRamGb, c.PriceUE, c.NamberOfItems, c.Processor);
            }
            Console.WriteLine();

            // Сортируем по увеличению стоимости.
            decimal priceMax = 0;
            List<Computer> listComputersPriceAp = new List<Computer>();
            foreach (Computer c in listComputers)
            {
                if (c.PriceUE >= priceMax)
                {
                    listComputersPriceAp.Add(c);
                    priceMax = c.PriceUE;
                }
                else
                {
                    i = 0;
                    foreach (Computer cp in listComputersPriceAp)
                    {
                        if (c.PriceUE < cp.PriceUE) break;
                        i++;
                    }
                    listComputersPriceAp.Insert(i, c);
                }
            }
            Console.WriteLine("Представляем список кимпьютепров в наличии по возрастанию стоимости : ");
            foreach (Computer c in listComputersPriceAp)
            {
                Console.WriteLine("Артикул : {0}, Модель : {1}, Тип процессора : {8}, Чатота процессора {2}МГц, Объем RAM={3}Гб, Объем HDD={4}Мб, Объем VideoRAM={5}Гб, Стоимость={6}У.Е., В наличии : {7}шт.", c.Id, c.Model, c.FrecProcMGz, c.RamGb, c.HddGb, c.VideoRamGb, c.PriceUE, c.NamberOfItems, c.Processor);
            }
            Console.WriteLine();

            // Группируем по типу процессора.
            foreach (string pr in processors)
            {
                Console.WriteLine("С процессором типа : {0} в наличии следующие модели : ", pr);
                foreach (Computer c in listComputersPriceAp)
                {
                    if (c.Processor == pr) Console.WriteLine("Артикул : {0}, Модель : {1}, Тип процессора : {8}, Чатота процессора {2}МГц, Объем RAM={3}Гб, Объем HDD={4}Мб, Объем VideoRAM={5}Гб, Стоимость={6}У.Е., В наличии : {7}шт.", c.Id, c.Model, c.FrecProcMGz, c.RamGb, c.HddGb, c.VideoRamGb, c.PriceUE, c.NamberOfItems, c.Processor);
                }
            }
            Console.WriteLine();

            // Самые : дорогой и бюджетный.
            i = listComputersPriceAp.Count - 1;
            Console.WriteLine("Самым дорогим из компьютеров в наличии является : ");
            Console.WriteLine("Артикул : {0}, Модель : {1}, Тип процессора : {8}, Чатота процессора {2}МГц, Объем RAM={3}Гб, Объем HDD={4}Мб, Объем VideoRAM={5}Гб, Стоимость={6}У.Е., В наличии : {7}шт.", listComputersPriceAp[i].Id, listComputersPriceAp[i].Model, listComputersPriceAp[i].FrecProcMGz, listComputersPriceAp[i].RamGb, listComputersPriceAp[i].HddGb, listComputersPriceAp[i].VideoRamGb, listComputersPriceAp[i].PriceUE, listComputersPriceAp[i].NamberOfItems, listComputersPriceAp[i].Processor);
            i = 0;
            Console.WriteLine("Самым буджетным из компьютеров в наличии является : ");
            Console.WriteLine("Артикул : {0}, Модель : {1}, Тип процессора : {8}, Чатота процессора {2}МГц, Объем RAM={3}Гб, Объем HDD={4}Мб, Объем VideoRAM={5}Гб, Стоимость={6}У.Е., В наличии : {7}шт.", listComputersPriceAp[i].Id, listComputersPriceAp[i].Model, listComputersPriceAp[i].FrecProcMGz, listComputersPriceAp[i].RamGb, listComputersPriceAp[i].HddGb, listComputersPriceAp[i].VideoRamGb, listComputersPriceAp[i].PriceUE, listComputersPriceAp[i].NamberOfItems, listComputersPriceAp[i].Processor);
            Console.WriteLine();

            // Формируем выборку позиций с наличием более указанного.
            i = 30;
            List<Computer> listComputersShit = listComputers
                .Where(c => c.NamberOfItems > i)
                .ToList();
            Console.WriteLine("Залежавшимися позициями (в наличии более {0}), являются : ", i);
            if (listComputersShit.Count > 0)
            {
                foreach (Computer c in listComputersShit)
                {
                    Console.WriteLine("Артикул : {0}, Модель : {1}, Тип процессора : {8}, Чатота процессора {2}МГц, Объем RAM={3}Гб, Объем HDD={4}Мб, Объем VideoRAM={5}Гб, Стоимость={6}У.Е., В наличии : {7}шт.", c.Id, c.Model, c.FrecProcMGz, c.RamGb, c.HddGb, c.VideoRamGb, c.PriceUE, c.NamberOfItems, c.Processor);
                }
            }
            else Console.WriteLine(" ЭЭЭ... СЛЮШАЙ ! НЭТУ, ДА !!!   :-) ");
            Console.WriteLine();


            Console.ReadKey();
        }
    }
}
