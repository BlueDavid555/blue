using ConsoleApp1;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullFileName = Utils.FilePath.GetFullPath("fluvaccine.csv");

            var csvServise = new ConsoleApp1.Services.ImportCsvService();
            var csvDatas = csvServise.LoadFormFile(fullFileName);

            Console.WriteLine(string.Format("分析完成，共有{0}筆資料", csvDatas.Count));
            var groupDatas = csvDatas.GroupBy(x => x.行政區, y => y).ToList();

            groupDatas.ForEach(x =>
            {
                var items = x.ToList();
                Console.WriteLine($"行政區:{x.Key}數量:{x.ToList().Count}");
                items.ForEach(x =>
                {
                    Console.WriteLine($"行政區:{x.行政區} 醫院名稱:{x.醫院名稱} 連絡電話:{x.連絡電話}");
                });
            });

            Console.ReadKey();
        }
    }
}
