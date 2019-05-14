using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace ControlTest2
{
    class Task1
    { // предположим, что файлы отсортированы в алфавитном порядке
        public void Check(string root)
        {
            var studResults = new Dictionary<string, int>(); // таблица с фамилиями и баллами
            var students = Directory.GetDirectories(root);
            foreach (var s in students)
            {
                FileInfo file = new FileInfo(s);
                studResults.Add(file.Name.Remove(file.Name.Length - 4, 4), 0);
            }
            var answersPath = Directory.GetFiles(root);
            var answers = new List<Answer>();

            //считывание правильных ответов из корневой папки
            foreach (var path in answersPath)
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    var temp = sr.ReadToEnd().Split(';');
                    var par = new List<string>();
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

            // проверка вычислений студентов
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
                        var par = new List<string>();
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
            PrintAnswer(studResults);
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
        public List<string> parameters;
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
