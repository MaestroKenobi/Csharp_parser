// @nuget: HtmlAgilityPack

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace ConsoleVer
{
    class Program
    {
        static void Main()
        {
            List<string> links = new List<string>();
            string path = "links.txt";
            FileInfo fileInfo = new FileInfo(path);
            if (fileInfo.Exists)
            {

                using (StreamReader sr = new StreamReader(path, System.Text.Encoding.UTF8))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        links.Add(line);
                    }
                }
            }
            else
            {
                fileInfo.Create();
            }
            for (int i = 0; i < links.Count; i++)
            {
                var html = links[i];
                HtmlWeb wep = new HtmlWeb();
                var html_dog = wep.Load(html);
                var nod = html_dog.DocumentNode.SelectSingleNode("//head/title");
                Console.WriteLine(nod.Name + "\n" + nod.InnerText);
                Console.ReadKey();
            }
        }
    }
}
