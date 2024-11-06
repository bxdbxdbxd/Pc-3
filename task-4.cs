using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp6
{
    public class Time
    {
        public int day;
        public int month;
        public int year;

        // Свойства для доступа к полям
        public int Year
        {
            get
            {
                return year;
            }

            set
            {
                // Проверка на кратность 10
                if (value % 1 == 0)
                {
                    year = value;
                }
                else
                {
                    year = 0;
                }
            }
        }

        public int Month
        {
            get
            {
                return month;
            }

            set
            {
                // Проверка на допустимые значения месяца
                if (value >= 1 && value <= 12)
                {
                    month = value;
                }
                else
                {
                    month = 0;
                }
            }
        }

        public int Day
        {
            get
            {
                return day;
            }

            set
            {
                // Проверка на допустимые значения дня
                if (value >= 1 && value <= 31)
                {
                    day = value;
                }
                else
                {
                    day = 0;
                }
            }
        }

        // Конструктор класса
        public Time(int day, int month, int years)
        {
            // Присваивание значений полям через свойства
            this.Day = day;
            this.Month = month;
            this.Year = years;
        }

        // Метод для вывода информации о времени
        public void PrintTime()
        {
            Console.WriteLine($"Дата: {Day}.{Month}.{Year}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание коллекции List<Time>
            List<Time> dates = new List<Time>()
            {
                new Time(20, 10, 2020),
                new Time(15, 12, 2022),
                new Time(5, 5, 2023),
                new Time(25, 10, 2020),
                new Time(10, 10, 2020),
                new Time(1, 1, 2023)
            };

            // Запросы с помощью LINQ
            // 1. Список дат для заданного года
            int заданныйГод = 2020;
            var datesInYear = dates.Where(d => d.Year == заданныйГод);
            Console.WriteLine($"Даты в {заданныйГод} году:");
            foreach (var date in datesInYear)
            {
                date.PrintTime();
            }

            // 2. Список дат в заданном месяце
            int заданныйМесяц = 10;
            var datesInMonth = dates.Where(d => d.Month == заданныйМесяц);
            Console.WriteLine($"\nДаты в {заданныйМесяц} месяце:");
            foreach (var date in datesInMonth)
            {
                date.PrintTime();
            }

            // 3. Количество дат в определённом диапазоне
            DateTime start = new DateTime(2020, 10, 1);
            DateTime end = new DateTime(2022, 12, 31);
            var countDates = dates.Count(d => d.Year >= start.Year && d.Year <= end.Year &&
                                            d.Month >= start.Month && d.Month <= end.Month &&
                                            d.Day >= start.Day && d.Day <= end.Day);
            Console.WriteLine($"\nКоличество дат в диапазоне {start.ToShortDateString()} - {end.ToShortDateString()}: {countDates}");

            // 4. Максимальную дату
            var maxDate = dates.Max(d => new DateTime(d.Year, d.Month, d.Day));
            Console.WriteLine($"\nМаксимальная дата: {maxDate.ToShortDateString()}");

            // 5. Первую дату для заданного дня
            int dateCho = 20;
            var firstDateInDay = dates.Where(d => d.Day == dateCho).OrderBy(d => new DateTime(d.Year, d.Month, d.Day)).FirstOrDefault();

            if (firstDateInDay != null)
            {
                Console.WriteLine($"\nПервая дата для {dateCho} дня: {firstDateInDay.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine($"\nПервая дата для {dateCho} дня: Не найдено");
            }

            // 6. Упорядоченный список дат (хронологически)
            var sortedDates = dates.OrderBy(d => new DateTime(d.Year, d.Month, d.Day));
            Console.WriteLine("\nУпорядоченный список дат:");
            foreach (var date in sortedDates)
            {
                date.PrintTime();
            }

            Console.ReadKey();
        }
    }
}
