using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Threading;

namespace ControlTest2
{
    class Task2
    {
        public string Path { get; private set; } 
        public void GetAnswer(string path)
        {
            Path = path;
            Thread thread = new Thread(new ThreadStart(Read));
            thread.Start();
        }

        private void Read()
        {
            string json;
            using (StreamReader sr = new StreamReader(Path))
            {
                json = sr.ReadToEnd();
            }
            Letter[] let = JsonConvert.DeserializeObject<Letter[]>(json);
            for (int i = 1; i < let.Length; i += 2)
            {
                var count = let[i].body.Where(c => char.IsLetter(c)).Count();
                Console.WriteLine($"комментарий {i + 1}: " + count + " букв");
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
