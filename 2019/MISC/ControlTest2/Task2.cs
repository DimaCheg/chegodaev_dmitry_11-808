using System;
using System.IO;
using Newtonsoft.Json;

namespace ControlTest2
{
    class Task2
    {
        public void GetAnswer(string path)
        {
            string json;
            using (StreamReader sr = new StreamReader(path))
            {
                json = sr.ReadToEnd();
            }
            Letter[] let = JsonConvert.DeserializeObject<Letter[]>(json);
            for (int i=0; i< let.Length; i += 2)
            {
                Console.WriteLine($"комментарий {i}: " + let[i].body.Length + "символов");
            }
        }        
    }

    class Letter
    {
        public int postId;
        public int id;
        public string email;
        public string body;
    }
}
