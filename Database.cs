using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace DBProductS
{
    class Database
    {
        readonly SQLiteConnection _database;
        public static string NAME;
        public static string DATE;



        public Database(string dbPath)
        {
            _database = new SQLiteConnection(dbPath);
            _database.CreateTable<DBFish>();
        }

        public void EDIT_DATA(string name, double weight, double price, DateTime dateTime)
        {
            var stock = new DBFish()
            {
                Name = name,
                Weight = weight,
                Price = price,
                Date = dateTime
            };
            _database.Insert(stock);

        }

        public void UPDATE_DATA(string name, double weight, double price, DateTime dateTime)
        {


        }

        public List<string> GET_DATA()
        {
            List<string> list = new List<string>();
            foreach (var stocks in _database.Table<DBFish>())
            {
                switch (NAME)
                {
                    case "ВСЯ РЫБА":
                        switch (DATE)
                        {
                            case "ЗА СУТКИ":
                                if ("" + stocks.Date.ToString("d") == "" + DateTime.Now.ToString("d"))
                                    list.Add(stocks.Name + "\n" + "ВЕС: " + stocks.Weight + "\n" + "ЦЕНА: " + stocks.Price + "\n" + stocks.Date.ToString("d"));
                                break;
                            case "ЗА МЕСЯЦ":
                                if (stocks.Date >= DateTime.Now.AddDays(-DateTime.Now.Day + 1))
                                    list.Add(stocks.Name + "\n" + "ВЕС: " + stocks.Weight + "\n" + "ЦЕНА: " + stocks.Price + "\n" + stocks.Date.ToString("d"));
                                break;
                            case "ЗА КВАРТАЛ":
                                if (stocks.Date >= DateTime.Now.AddMonths(-3).AddDays(-DateTime.Now.Day + 1))
                                    list.Add(stocks.Name + "\n" + "ВЕС: " + stocks.Weight + "\n" + "ЦЕНА: " + stocks.Price + "\n" + stocks.Date.ToString("d"));
                                break;
                            case "ЗА ГОД":
                                if (stocks.Date >= DateTime.Now.AddYears(-1))
                                    list.Add(stocks.Name + "\n" + "ВЕС: " + stocks.Weight + "\n" + "ЦЕНА: " + stocks.Price + "\n" + stocks.Date.ToString("d"));
                                break;
                            case "ЗА ВСЕ ВРЕМЯ":
                                list.Add(stocks.Name + "\n"+ "ВЕС: " + stocks.Weight + "\n" + "ЦЕНА: " + stocks.Price + "\n" + stocks.Date.ToString("d"));
                                break;
                        }
                        break;
                    default:
                        if (stocks.Name == NAME)
                        {
                            switch (DATE)
                            {
                                case "ЗА СУТКИ":
                                    if ("" + stocks.Date.ToString("d") == "" + DateTime.Now.ToString("d"))
                                        list.Add(stocks.Name + "\n" + "ВЕС: " + stocks.Weight + "\n" + "ЦЕНА: " + stocks.Price + "\n" + stocks.Date.ToString("d"));
                                    break;
                                case "ЗА МЕСЯЦ":
                                    if (stocks.Date >= DateTime.Now.AddDays(-DateTime.Now.Day + 1))
                                        list.Add(stocks.Name + "\n" + "ВЕС: " + stocks.Weight + "\n" + "ЦЕНА: " + stocks.Price + "\n" + stocks.Date.ToString("d"));
                                    break;
                                case "ЗА КВАРТАЛ":
                                    if (stocks.Date >= DateTime.Now.AddMonths(-3).AddDays(-DateTime.Now.Day + 1))
                                        list.Add(stocks.Name + "\n" + "ВЕС: " + stocks.Weight + "\n" + "ЦЕНА: " + stocks.Price + "\n" + stocks.Date.ToString("d"));
                                    break;
                                case "ЗА ГОД":
                                    if (stocks.Date >= DateTime.Now.AddYears(-1))
                                        list.Add(stocks.Name + "\n" + "ВЕС: " + stocks.Weight + "\n" + "ЦЕНА: " + stocks.Price + "\n" + stocks.Date.ToString("d"));
                                    break;
                                case "ЗА ВСЕ ВРЕМЯ":
                                    list.Add(stocks.Name + "\n" + "ВЕС: " + stocks.Weight + "\n" + "ЦЕНА: " + stocks.Price + "\n" + stocks.Date.ToString("d"));
                                    break;
                            }
                            break;
                        }
                        break;
                }   
            }
            return list;
        }

        public double GET_SUM()
        {
            double sum = 0;
            foreach (var stocks in _database.Table<DBFish>())
            {
                switch (NAME)
                {
                    case "ВСЯ РЫБА":
                        switch (DATE)
                        {
                            case "ЗА СУТКИ":
                                if ("" + stocks.Date.ToString("d") == "" + DateTime.Now.ToString("d"))
                                    sum += (stocks.Price * stocks.Weight);
                                break;
                            case "ЗА МЕСЯЦ":
                                if (stocks.Date >= DateTime.Now.AddDays(-DateTime.Now.Day + 1))
                                    sum += (stocks.Price * stocks.Weight);
                                break;
                            case "ЗА КВАРТАЛ":
                                if (stocks.Date >= DateTime.Now.AddMonths(-3).AddDays(-DateTime.Now.Day + 1))
                                    sum += (stocks.Price * stocks.Weight);
                                break;
                            case "ЗА ГОД":
                                if (stocks.Date >= DateTime.Now.AddYears(-1))
                                    sum += (stocks.Price * stocks.Weight);
                                break;
                            case "ЗА ВСЕ ВРЕМЯ":
                                sum = _database.Table<DBFish>().AsEnumerable().Sum(o => (o.Price * o.Weight));
                                break;
                        }
                        break;
                    default:
                        if (stocks.Name == NAME)
                        {
                            switch (DATE)
                            {
                                case "ЗА СУТКИ":
                                    if ("" + stocks.Date.ToString("d") == "" + DateTime.Now.ToString("d"))
                                        sum += (stocks.Price * stocks.Weight);
                                    break;
                                case "ЗА МЕСЯЦ":
                                    if (stocks.Date >= DateTime.Now.AddDays(-DateTime.Now.Day + 1))
                                        sum += (stocks.Price * stocks.Weight);
                                    break;
                                case "ЗА КВАРТАЛ":
                                    if (stocks.Date >= DateTime.Now.AddMonths(-3).AddDays(-DateTime.Now.Day + 1))
                                        sum += (stocks.Price * stocks.Weight);
                                    break;
                                case "ЗА ГОД":
                                    if (stocks.Date >= DateTime.Now.AddYears(-1))
                                        sum += (stocks.Price * stocks.Weight);
                                    break;
                                case "ЗА ВСЕ ВРЕМЯ":
                                    sum += (stocks.Price * stocks.Weight);
                                    break;
                            }
                            break;
                        }
                        break;
                }
            }
            return sum;
        }
    }
}