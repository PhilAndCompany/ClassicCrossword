using ClassicCrossword.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicCrossword.Controller
{
    public class DictController
    {
        public Dictionary<string, string> ParseDict(String filename)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string[] words = File.ReadAllLines(filename, Encoding.GetEncoding("utf-8")).Take(500).ToArray();
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                string question = words[i].Substring(words[i].IndexOf(words[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]));
                dict.Add(word, question);
            }
            return dict;
        }

        public bool SaveDict(String text, String filename)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.UTF8))
                {
                    sw.Write(text);
                    return true;
                }
            }
            catch { return false; }
        }
    }
}
