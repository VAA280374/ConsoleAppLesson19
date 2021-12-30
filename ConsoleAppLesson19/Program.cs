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

            Console.ReadKey();
        }
    }
}
