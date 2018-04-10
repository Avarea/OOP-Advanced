using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft
{
    using System;
    using System.IO;


    public class Tester : IContentComparer
    {
        public void CompareContent(string userOutputPath, string expectedOutputPath)
        {
            OutputWriter.WriteMessageOnNewLine("Reading files...");
            try
            {
                if (userOutputPath.LastIndexOf("\\") < 0)
                {
                    userOutputPath = SessionData.currentPath + "\\" + userOutputPath;
                }

                if (expectedOutputPath.LastIndexOf("\\") < 0)
                {
                    expectedOutputPath = SessionData.currentPath + "\\" + expectedOutputPath;
                }

                string mismatchPath = GetMismatchPath(expectedOutputPath);

                string[] actualOutputLines = File.ReadAllLines(userOutputPath);
                string[] expectedOutputLines = File.ReadAllLines(expectedOutputPath);

                bool hasMismatch;
                string[] mismatches =
                    GetLinesWithPossibleMissmatches(actualOutputLines, expectedOutputLines, out hasMismatch);

                PrintOutput(mismatches, hasMismatch, mismatchPath);
                OutputWriter.WriteMessageOnNewLine("Files read!");
            }
            catch (IOException)
            {
                throw new InvalidPathException();
            }
        }

        private void PrintOutput(string[] missmatches, bool hasMissmatch, string missmatchPath)
        {
            if (hasMissmatch)
            {
                foreach (var line in missmatches)
                {
                    OutputWriter.WriteMessageOnNewLine(line);
                }
                File.WriteAllLines(missmatchPath, missmatches);

                return;
            }
            OutputWriter.WriteMessageOnNewLine("Files are identical. There are no missmatches.");
        }

        private string[] GetLinesWithPossibleMissmatches(string[] actualOutputLines,
            string[] expectedOutputLines, out bool hasMissmatch)
        {
            hasMissmatch = false;
            string output = String.Empty;

            OutputWriter.WriteMessageOnNewLine("Comparing files...");

            int minOutputLines = actualOutputLines.Length;
            if (actualOutputLines.Length != expectedOutputLines.Length)
            {
                hasMissmatch = true;
                minOutputLines = Math.Min(actualOutputLines.Length, expectedOutputLines.Length);
                OutputWriter.DisplayException(ExceptionMessages.ComparisonOfFilesWithDifferentSizes);
            }
            string[] missmatches = new string[minOutputLines];


            for (int index = 0; index < minOutputLines; index++)
            {
                string actualLine = actualOutputLines[index];
                string expectedLine = expectedOutputLines[index];

                if (!actualLine.Equals(expectedLine))
                {
                    output = String.Format($"Missmatch at line {index} -- expected: \"{expectedLine}\", actual: \"{actualLine}\" ");
                    output += Environment.NewLine;
                    hasMissmatch = true;
                }

                else
                {
                    output = actualLine;
                    output += Environment.NewLine;
                }
                missmatches[index] = output;
            }
            return missmatches;
        }

        private string GetMismatchPath(string expectedOutputPath)
        {
            int indexOf = expectedOutputPath.LastIndexOf('\\');
            string directoryPath = expectedOutputPath.Substring(0, indexOf);
            string finalPath = directoryPath + @"Mismatches.txt";
            return finalPath;
        }
    }
}
