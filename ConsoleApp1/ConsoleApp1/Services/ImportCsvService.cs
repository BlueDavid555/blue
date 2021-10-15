using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class ImportCsvService
    {
        public List<Hospital> LoadFormFile(string filePath)
        {
            List<Hospital> result = new List<Hospital>();

            string[] line = System.IO.File.ReadAllLines(filePath);

            result = line.ToList().Skip(1).Select(x =>
            {
                var columns = x.Split(',');
                var item = new Hospital()
                {
                    十碼章 = columns[0],
                    醫院名稱 = columns[1],
                    行政區 = columns[2],
                    地址 = columns[3],
                    連絡電話 = columns[4],
                    座標緯度 = columns[5],
                    座標經度 = columns[6]
                };
                return item;
            }).ToList();

            return result;
        }
        
    }
}
