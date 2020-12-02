﻿using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using System.Collections.Generic;

Console.WriteLine(GetLines().Count(IsPasswordValid));

IEnumerable<Line> GetLines() => File.ReadAllLines("input.txt")
            .Select(txt =>
            {
                var m = Regex.Match(txt, @"(\d*)-(\d*) (.): (.*)");
                return new Line(int.Parse(m.Groups[1].Value), int.Parse(m.Groups[2].Value), char.Parse(m.Groups[3].Value), m.Groups[4].Value);
            });

bool IsPasswordValid(Line line) => line.Password.Count(p => p == line.Character) >= line.LowerBound
&& line.Password.Count(p => p == line.Character) <= line.UpperBound;

public record Line(int LowerBound, int UpperBound, char Character, string Password);