using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var input = File.ReadAllLines("input.txt")
            .Select(line => int.Parse(line))
            .OrderBy(x => x)
            .ToList();

var maxJolt = input.Max() + 3;
input.Add(maxJolt);

Console.WriteLine($"Total {input.Count()}");

var diffs = input.Select((x, i) => i == 0 ? x : x - input[i-1]);
var oneJoltDiffs = diffs.Count(x => x == 1);
var threeJoltDiffs = diffs.Count(x => x == 3);

Console.WriteLine($"1-jolt differences = {oneJoltDiffs}, 3-jolt differences = {threeJoltDiffs}, answer = {oneJoltDiffs * threeJoltDiffs}");

