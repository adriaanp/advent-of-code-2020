using System;
using System.IO;
using System.Linq;

var input = File.ReadAllLines("input.txt")
            .Select(line => long.Parse(line))
            .ToList();

var pointer = 1;
while (pointer < input.Count())
{
    var x = input.Skip(pointer - 1).Take(25).SelectMany(item => input.Skip(pointer - 1).Take(25), (x, y) => x == y ? 0 : x + y)
            .ToList();
    var number = input.Skip(pointer + 24).Take(1).Single();
    if (!x.Contains(number))
    {
        Console.WriteLine($"{number} is invalid in pointer {pointer}");
        break;
    }
    pointer++;
}
