using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7
{
    class Line
    {
        public string Name;
        public int? Ozone;
        public int? SolarR;
        public double? Wind;
        public int? Temp;
        public int? Month;
        public int? Day;
    }

    class Program
    {
        //Task 1
        static IEnumerable<string[]> ReadCSV(string fileName)
        {
            using (var stream = new StreamReader(fileName))
            {
                while(true)
                {
                    var line = stream.ReadLine();

                    if (line == null)
                    {
                        stream.Close();
                        yield break;
                    }

                    var result = line.Split(',');

                    for (int i = 0; i < result.Length; i++)
                    {
                        if (result[i] == "NA")
                            result[i] = null;
                        else
                            result[i] = result[i].Trim('\"');
                    }

                    yield return result;
                }
            }
        }

        //Task 2
        static IEnumerable<T> ReadCSV<T>(string fileName) where T : new()
        {
            using (var stream = new StreamReader(fileName))
            {
                var line = stream.ReadLine();

                if (line == null)
                {
                    stream.Close();
                    yield break;
                }

                string[] colums = line.Split(',');

                for (int i = 0; i < colums.Length; i++)
                {
                    string value = colums[i];

                    if (value.Contains("."))
                        colums[i] = value.Replace(".", "").Trim('\"');
                    else
                        colums[i] = value.Trim('\"');
                }

                while (true)
                {
                    line = stream.ReadLine();

                    if (line == null)
                    {
                        stream.Close();
                        yield break;
                    }

                    T result = new T();
                    var values = line.Split(',');

                    for (int i = 0; i < values.Length; i++)
                    {
                        string value = values[i].Trim('\"');
                        var field = result.GetType().GetField(colums[i]);

                        if (value == "NA")
                        {
                            var type = field.FieldType;

                            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
                                field.SetValue(result, null);
                            else
                                throw new Exception("Not null type!");
                        }
                        else
                            field.SetValue(result, TypeDescriptor.GetConverter(field.FieldType).ConvertFrom(null, CultureInfo.InvariantCulture, value));
                    }

                    yield return result;
                }
            }
        }

        //Task 3
        static IEnumerable<Dictionary<string, object>> ReadCsv3(string fileName)
        {
            using (var stream = new StreamReader(fileName))
            {
                var line = stream.ReadLine();

                if (line == null)
                {
                    stream.Close();
                    yield break;
                }

                string[] colums = line.Split(',');

                for (int i = 0; i < colums.Length; i++)
                {
                    string value = colums[i];

                    if (value.Contains("."))
                        colums[i] = value.Replace(".", "").Trim('\"');
                    else
                        colums[i] = value.Trim('\"');
                }

                while (true)
                {
                    line = stream.ReadLine();

                    if (line == null)
                    {
                        stream.Close();
                        yield break;
                    }

                    Dictionary<string, object> result = new Dictionary<string, object>();
                    var values = line.Split(',');

                    for (int i = 0; i < values.Length; i++)
                    {
                        string value = values[i].Trim('\"');

                        if (value == "NA")
                        {
                            result.Add(colums[i], null);
                        }
                        else
                        {
                            double dValue;
                            int iValue;

                            if (double.TryParse(value, out dValue))
                                result.Add(colums[i], dValue);
                            else if (int.TryParse(value, out iValue))
                                result.Add(colums[i], iValue);
                            else
                                result.Add(colums[i], value);
                        }
                    }

                    yield return result;
                }
            }
        }


        //Task 4
        static IEnumerable<dynamic> ReadCsv4(string fileName)
        {
            using (var stream = new StreamReader(fileName))
            {
                var line = stream.ReadLine();

                if (line == null)
                {
                    stream.Close();
                    yield break;
                }

                string[] colums = line.Split(',');

                for (int i = 0; i < colums.Length; i++)
                {
                    string value = colums[i];

                    if (value.Contains("."))
                        colums[i] = value.Replace(".", "").Trim('\"');
                    else
                        colums[i] = value.Trim('\"');
                }

                while (true)
                {
                    line = stream.ReadLine();

                    if (line == null)
                    {
                        stream.Close();
                        yield break;
                    }

                    var result = new ExpandoObject() as IDictionary<string, Object>;
                    var values = line.Split(',');

                    for (int i = 0; i < values.Length; i++)
                    {
                        string value = values[i].Trim('\"');
                        var field = result.GetType().GetField(colums[i]);

                        if (value == "NA")
                        {
                            result.Add(colums[i], null);
                        }
                        else
                        {
                            double dValue;
                            int iValue;

                            if (double.TryParse(value, out dValue))
                                result.Add(colums[i], dValue);
                            else if (int.TryParse(value, out iValue))
                                result.Add(colums[i], iValue);
                            else
                                result.Add(colums[i], value);
                        }
                    }

                    yield return result;
                }
            }
        }

        static void Main(string[] args)
        {
            //Task 1
            foreach (string[] array in ReadCSV(@"C:\Users\maste\Downloads\\airquality.csv"))
            {
                Console.WriteLine(array[0] + "\t" + array[1] + "\t" + array[2] + "\t"
                    + array[3] + "\t" + array[4] + "\t" + array[5] + "\t" + array[6]);
            }

            //Task 2
            foreach (Line line in ReadCSV<Line>(@"C:\Users\maste\Downloads\\airquality.csv"))
            {
                Console.WriteLine(line.Name + "\t" + line.SolarR + "\t" + line.Ozone);
            }

            //Task 3
            foreach (var line in ReadCsv3(@"C:\Users\maste\Downloads\\airquality.csv"))
            {
                Console.WriteLine(line["Name"] + "\t" + line["Ozone"] + "\t" + line["Wind"]);
            }

            //Task 4
            foreach (var line in ReadCsv4(@"C:\Users\maste\Downloads\\airquality.csv"))
            {
                Console.WriteLine(line.Name + "\t" + line.Ozone + "\t" + line.Wind);
            }
        }
    }
}
