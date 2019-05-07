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
                if (html.Contains("anilibria.tv"))
                {
                    HtmlWeb web = new HtmlWeb();
                    var html_doc = web.Load(html);
                    HtmlNode name = html_doc.DocumentNode.SelectSingleNode("//body//h1");
                    HtmlNode ep = html_doc.DocumentNode.SelectSingleNode("//text()[contains(., 'Серия 1-')]");
                    string ep_str = ep.InnerText.ToString();
                    int aa = ep_str.IndexOf('-');
                    int bb = ep_str.IndexOf('[');
                    string temp = ep_str.Substring(aa - 1);
                    int cc = temp.IndexOf(' ');
                    temp = temp.Remove(cc);
                    string serial_last = temp.Substring(2);
                    int ep_last = Convert.ToUInt16(serial_last);
                    HtmlNode episodes_total = html_doc.DocumentNode.SelectSingleNode("//text()[contains(., 'ТВ')]");
                    if (episodes_total == null)
                    {
                        episodes_total = html_doc.DocumentNode.SelectSingleNode("//text()[contains(., 'фильм')]");
                        if (episodes_total == null)
                        {
                            episodes_total = html_doc.DocumentNode.SelectSingleNode("//text()[contains(., 'OVA')]");
                        }
                    }
                    string episodes_total_str = episodes_total.InnerText;
                    int aaa = episodes_total_str.IndexOf("(");
                    int bbb = episodes_total_str.IndexOf(")");
                    episodes_total_str = episodes_total_str.Substring(aaa+1, bbb - aaa - 1);
                    int ccc = episodes_total_str.IndexOf(" ");
                    episodes_total_str = episodes_total_str.Remove(ccc);
                    int eps_total = Convert.ToUInt16(episodes_total_str);
                    if (ep_last != eps_total)
                    {

                    }
                    Console.WriteLine(eps_total);
                    Console.ReadKey();
                }
                //    string path_result = "result.txt";
                //    FileInfo file = new FileInfo(path_result);
                //    if (file.Exists)
                //    {
                //        using (StreamReader reader = new StreamReader(path_result, Encoding.UTF8))
                //        {
                //            string line_result;
                //            while ((line_result = reader.ReadLine()) != null)
                //            {
                //                string result_past = line_result;
                //                if (result_past == Convert.ToString(serial))
                //                {

                //                }
                //                else
                //                {
                //                    string name_str = name.InnerHtml.Trim();
                //                    int a = name_str.IndexOf("<");
                //                    int b = name_str.LastIndexOf(">");
                //                    name_str = name_str.Insert(a, "/");
                //                    name_str = name_str.Remove(a + 1, 4);
                //                    Console.WriteLine(name_str);
                //                    Console.ReadKey();
                //                }
                //            }
                //        }
                //    }
                //    else
                //    {
                //        file.Create();
                //        i = 0;
                //    }
                //}
                else if (html.Contains("sovetromantica.com"))
                {

                }
            }
        }
    }
}
