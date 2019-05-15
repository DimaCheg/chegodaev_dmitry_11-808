using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ControlTest2
{
    class Task1
    { 
        public string Root { get; set; }
        public void Check(string root)
        {
            Root = root;
            Thread thread = new Thread(new ThreadStart(Checker));
            thread.Start();
        }

        // предположим, что файлы отсортированы в алфавитном порядке
        private void Checker()
        {
            var studResults = new Dictionary<string, int>(); // таблица с фамилиями и баллами
            var students = Directory.GetDirectories(Root); // папки студентов
            foreach (var s in students)
            {
                FileInfo file = new FileInfo(s);
                studResults.Add(file.Name.Remove(file.Name.Length - 4, 4), 0);
            }
            var answersPath = Directory.GetFiles(Root); // файлы в корневой папке (ответы)
            var answers = new List<Answer>();

            //считывание правильных ответов из корневой папки
            answers = GetAnswers(answersPath, answers);

            // проверка вычислений студентов
            studResults = GetResults(students, answers, studResults);
            PrintAnswer(studResults);
        }

        private List<Answer> GetAnswers(string[] answPaths, List<Answer> answers)
        {
            foreach (var path in answPaths)
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    var temp = sr.ReadToEnd().Split(';');
                    var par = new HashSet<string>();
                    for (int i = 2; i < temp.Length - 1; i++)
                    {
                        par.Add(temp[i]);
                    }
                    answers.Add(new Answer
                    {
                        ClassName = temp[0],
                        MethodName = temp[1],
                        parameters = par,
                        returnValue = temp[temp.Length - 1]
                    });
                }
            }
            return answers;
        }

        private Dictionary<string, int> GetResults(string[] students, List<Answer> answers,
            Dictionary<string, int> studResults)
        {
            foreach (var path in students)
            {
                FileInfo fileinfo = new FileInfo(path);
                var name = fileinfo.Name.Remove(fileinfo.Name.Length - 4, 4);
                studResults.Add(name, 0);

                var studFiles = Directory.GetFiles(path);
                var number = 0; //номер проверяемого файла
                foreach (var file in studFiles)
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        var temp = sr.ReadToEnd().Split(';');
                        var par = new HashSet<string>();
                        for (int i = 2; i < temp.Length - 1; i++)
                        {
                            par.Add(temp[i]);
                        }
                        var studAnswer = new Answer
                        {
                            ClassName = temp[0],
                            MethodName = temp[1],
                            parameters = par,
                            returnValue = temp[temp.Length - 1]
                        };
                        var curAnsw = answers[number];
                        if (curAnsw.IsEqual(studAnswer))
                            studResults[name]++;
                    }
                }
            }
            return studResults;
        }

        private void PrintAnswer(Dictionary<string, int> result)
        {
            foreach (var pair in result)
            {
                Console.WriteLine(pair.Key +"\t" + pair.Value);
            }
        }
    }

    class Answer
    {
        public string ClassName;
        public string MethodName;
        public HashSet<string> parameters;
        public string returnValue;

        public bool IsEqual(Answer other)
        {
            if (ClassName == other.ClassName &&
                MethodName == other.MethodName &&
                returnValue == other.returnValue &&
                parameters == other.parameters)
            {
                return true;
            }
            return false;
        }
    }
}
