using System;
using System.IO;
using System.Linq;

var input = File.ReadAllText("input.txt");

var yesAnswers = input.Split("\n\n")
                .Select(s => s.Replace("\n", "")
                              .Distinct()
                              .Count())
                .Sum();

Console.WriteLine($"Yes answers across groups: {yesAnswers}");