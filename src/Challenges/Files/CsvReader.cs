using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Files
{
    public class CsvReader
    {
        public IEnumerable<string[]> ReadCsv1(string path)
        {
            return ReadLines(path)
                .Select(line => line.Split(','));
        }

        public IEnumerable<T> ReadCsv2<T>(string path) where T : class, new()
        {
            var properties = ReadLines(path)
                .First()
                .Split(',')
                .Select(GetPropertyName)
                .ToArray();

            return ReadLines(path)
                .Skip(1)
                .Select(values => ParseToObject<T>(properties, values.Split(',')));
        }

        public IEnumerable<Dictionary<string, object>> ReadCsv3(string path)
        {
            var properties = ReadLines(path)
                .First()
                .Split(',')
                .Select(GetPropertyName)
                .ToArray();

            return ReadLines(path)
                .Skip(1)
                .Select(values => ParseToDictionary(properties, values.Split(',')));
        }

        public IEnumerable<dynamic> ReadCsv4(string path)
        {
            var properties = ReadLines(path)
                .First()
                .Split(',')
                .Select(GetPropertyName)
                .ToArray();

            return ReadLines(path)
                .Skip(1)
                .Select(values => ParseToDynamic(properties, values.Split(',')));
        }

        private static IEnumerable<string> ReadLines(string path)
        {
            using (var textReader = new StreamReader(path))
            {
                while (true)
                {
                    var line = textReader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    yield return line;
                }
            }
        }

        private static T ParseToObject<T>(string[] propertyNames, string[] values) where T : class, new()
        {
            CheckArraySizes(propertyNames.Length, values.Length);

            var obj = new T();
            var objectType = obj.GetType();

            for (int i = 0; i < propertyNames.Length; ++i)
            {
                var property = objectType.GetProperty(propertyNames[i], BindingFlags.Public | BindingFlags.Instance);

                if (property == null)
                {
                    throw new ArgumentException($"Wrong name of property : { propertyNames[i] }");
                }

                var value = GetValue(values[i]);

                property.SetValue(obj, value, null);
            }

            return obj;
        }

        private static Dictionary<string, object> ParseToDictionary(string[] propertyNames, string[] values)
        {
            CheckArraySizes(propertyNames.Length, values.Length);

            var result = new Dictionary<string, object>();

            for (int i = 0; i < propertyNames.Length; ++i)
            {
                result.Add(propertyNames[i], GetValue(values[i]));
            }

            return result;
        }

        private static dynamic ParseToDynamic(string[] propertyNames, string[] values)
        {
            CheckArraySizes(propertyNames.Length, values.Length);

            dynamic obj = new ExpandoObject();

            for (int i = 0; i < propertyNames.Length; ++i)
            {
                ((IDictionary<string, object>)obj).Add(propertyNames[i], GetValue(values[i]));
            }

            return obj;
        }

        private static object GetValue(string value)
        {
            var trimmedValue = value.Trim('"');

            if (value == "NA")
            {
                return null;
            }

            int intValue;

            if (int.TryParse(trimmedValue, out intValue))
            {
                return intValue;
            }

            double doubleValue;

            if (double.TryParse(trimmedValue.Replace('.', ','), out doubleValue))
            {
                return doubleValue;
            }

            return value;
        }

        private static string GetPropertyName(string name)
        {
            var regex = new Regex(@"[^a-zA-Z0-9 -]");
            return regex.Replace(name, "").Trim('"');
        }

        private static void CheckArraySizes(int firstLenght, int secondLenght)
        {
            if (firstLenght != secondLenght)
            {
                throw new ArgumentException("Array sizes do not equal");
            }
        }
    }
}