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

namespace Anver
{
    class Parser
    {

        public static string parse(string source, string param)
        {
            /*  string src = source.Substring(source.IndexOf(param));
              string s = "";

              while (src.Contains(param)) {

                  s += src.Substring(src.IndexOf(param), src.Length - src.IndexOf("</tr>"));

                  Log.Wtf("Parser", "src.Length: " + src.Length + " | | src.IndexOf(/tr): " + src.IndexOf("</tr>"));

                  src = src.Substring(src.IndexOf(param));
                  src = src.Substring(src.IndexOf("</tr>") + 6);
              }
              s = s.Replace("<td class=\"list\" align=\"center\">", "");
              s = s.Replace("</td>", ", ");

              return s;*/

            string[] entrys = source.Split(new string[] { "<tr class='list" }, StringSplitOptions.None);

            List<string> relevantEntrys = new List<string>();

            foreach (string s in entrys)
            {
                if (s.Contains(param))
                {
                    string ss = s.Replace("<td class=\"list\" align=\"center\">", "");

                    /*   while (ss.Contains(" style=\"background-color: #"))
                       {
                           ss.Remove(ss.IndexOf(" style=\"background-color: #"), 36);
                       }
                       while (ss.Contains("<span style=\"color: #"))
                       {
                           ss.Remove(ss.IndexOf("<span style=\"color: #"), 29);
                       }
                       */

                    ss = ss.Replace("</td>", ", ");
                    ss = ss.Replace("<tr class='list even'>", "");
                    ss = ss.Replace("<tr class='list odd'>", "");
                    ss = ss.Replace("even'>", "");
                    ss = ss.Replace("odd'>", "");
                    ss = ss.Replace("even'>", "");
                    ss = ss.Replace("</tr>", "");
                    ss = ss.Replace("<td class=\"list\" align=\"center\" style=\"background-color: #FF8080\" >", "");
                    ss = ss.Replace("<td class=\"list\" align=\"center\" style=\"background-color: #FFFFFF\" >", "");
                    ss = ss.Replace("<span style=\"color: #400040\">", "");
                    ss = ss.Replace("</span>", "");
                    ss = ss.Replace("&nbsp;", "  ");
                    ss = ss.Replace("</tr>", "");
                    ss = ss.Replace("</tr>", "");

                    relevantEntrys.Add(ss);
                }
            }

            return String.Join("\r\n", relevantEntrys.ToArray());
        }

    }
}