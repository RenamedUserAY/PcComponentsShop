using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileParserForPcComponentsShop
{
    class Program
    {
        //static void FirstPartParser(StreamReader sr, Action<string,string,string,string,string,string> Write)
        //{
        //    string line;
        //    while (!sr.EndOfStream)
        //    {
        //        line = sr.ReadLine();
        //        int pos = 0;
        //        if (line.Contains("name: "))
        //        {
        //            string name = line.Substring(line.IndexOf(':')+2, line.IndexOf(',')-line.IndexOf(':')-2);
        //            pos = "name: ".Length + name.Length;
        //            string id = line.Substring(line.IndexOf(':', pos) + 2, line.IndexOf(',', pos+1) - line.IndexOf(':',pos) - 2);
        //            pos += "id: ".Length + id.Length + 2;
        //            string price = line.Substring(line.IndexOf(':', pos) + 2, line.IndexOf(',', pos+1) - line.IndexOf(':', pos) - 2);
        //            pos += "price: ".Length + price.Length + 2;
        //            string brand = line.Substring(line.IndexOf(':', pos) + 2, line.IndexOf(',', pos + 1) - line.IndexOf(':', pos) - 2);
        //            pos += "brand: ".Length + brand.Length + 2;
        //            string category = line.Substring(line.IndexOf(':', pos) + 2, line.IndexOf(',', pos + 1) - line.IndexOf(':', pos) - 2);
        //            pos += "category: ".Length + category.Length + 3;
        //            string imgSrc = line.Substring(pos + " imgSrc: ".Length, line.Length - pos - " imgSrc: ".Length -1);
        //            Write(name, id, price, brand, category, imgSrc);
        //            //Console.WriteLine(name);
        //            //Console.WriteLine(id);
        //            //Console.WriteLine(price);
        //            //Console.WriteLine(brand);
        //            //Console.WriteLine(category);
        //            //Console.WriteLine(imgSrc);
        //        }
        //    }
        //}
        //static void ComputerCaseParser(string path)
        //{
        //    StreamReader sr = new StreamReader(path, Encoding.Default);
        //    while (!sr.EndOfStream)
        //    {
        //        string line = sr.ReadLine();
        //        string fitem = "Тип корпуса: ";
        //        if(line.Contains(fitem))
        //            Console.WriteLine(line.Substring(fitem.Length, line.Length - fitem.Length));
        //        fitem = "Форм-фактор: ";
        //        if (line.Contains(fitem))
        //            Console.WriteLine(line.Substring(fitem.Length, line.Length - fitem.Length));
        //        fitem = "Блок питания: ";
        //        if (line.Contains(fitem))
        //            Console.WriteLine(line.Substring(fitem.Length, line.Length - fitem.Length));
        //        fitem = "Особенности: ";
        //        if (line.Contains(fitem))
        //            Console.WriteLine(line.Substring(fitem.Length, line.Length - fitem.Length));
        //        fitem = "Макс. высота кулера CPU: ";
        //        if (line.Contains(fitem))
        //            Console.WriteLine(line.Substring(fitem.Length, line.Length - fitem.Length));
        //        fitem = "Макс. длина видеокарты: ";
        //        if (line.Contains(fitem))
        //            Console.WriteLine(line.Substring(fitem.Length, line.Length - fitem.Length));
        //    }
        //    sr.Close();
        //}
        static void Main(string[] args)
        {
            
            Console.ReadLine();
        }
        class A
        {
            public virtual void Hello()
            {
                Console.WriteLine("A hello");
            }
        }
        class B : A
        {
            public override void Hello()
            {
                Console.WriteLine("B hello");
            }
        }
    }
}
