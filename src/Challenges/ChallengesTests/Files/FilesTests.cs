using System;
using System.Collections.Generic;
using System.Linq;
using Files;
using NUnit.Framework;

namespace ChallengesTests.Files
{
    public class FilesTests : TestBase
    {
        private const string _filePath = @"E:\CodeProjects\C#\ulearnhomeworks\src\Challenges\ChallengesTests\Files\airquality.csv";

        private CsvReader _csvReader;

        public override void SetUp()
        {
            _csvReader = new CsvReader();
        }

        [Test]
        public void TestReadCsv1()
        {
            var enumerator = _csvReader
                .ReadCsv1(_filePath)
                .GetEnumerator();

            var lines = GetLines(3, enumerator);

            PrintResult(lines);

            Assert.AreEqual(3, lines.Count);
        }

        [Test]
        public void TestReadCsv2()
        {
            var enumerator = _csvReader
                .ReadCsv2<CsvObject>(_filePath)
                .GetEnumerator();

            var lines = GetLines(7, enumerator);

            PrintResult(lines);

            Assert.AreEqual(7, lines.Count);
        }

        [Test]
        public void TestReadCsv3()
        {
            var enumerator = _csvReader
                .ReadCsv3(_filePath)
                .GetEnumerator();

            var lines = GetLines(7, enumerator);

            PrintResult(lines);

            Assert.AreEqual(7, lines.Count);
        }

        [Test]
        public void TestReadCsv4()
        {
            var windValues = _csvReader
                .ReadCsv4(_filePath)
                .Where(z => z.Ozone > 10)
                .Select(z => z.Wind)
                .ToList();

            windValues.ForEach(Console.WriteLine);
        }

        private static void PrintResult(List<string> lines)
        {
            lines.ForEach(Console.WriteLine);
        }

        private static List<string> GetLines(int linesCount, IEnumerator<string[]> enumerator)
        {
            var lines = new List<string>();

            enumerator.MoveNext();

            for (int i = 0; i < linesCount; ++i)
            {
                lines.Add(string.Join(" ", enumerator.Current));
                enumerator.MoveNext();
            }

            return lines;
        }

        private static List<string> GetLines(int linesCount, IEnumerator<Dictionary<string, object>> enumerator)
        {
            var lines = new List<string>();

            enumerator.MoveNext();

            for (int i = 0; i < linesCount; ++i)
            {
                var line = String.Join(" ", enumerator.Current.Select(item => $"{item.Key} : {item.Value}; "));

                lines.Add(line);
                enumerator.MoveNext();
            }

            return lines;
        }

        private static List<string> GetLines<T>(int linesCount, IEnumerator<T> enumerator)
        {
            var lines = new List<string>();

            enumerator.MoveNext();

            for (int i = 0; i < linesCount; ++i)
            {
                lines.Add(enumerator.Current.ToString());
                enumerator.MoveNext();
            }

            return lines;
        }
    }
}