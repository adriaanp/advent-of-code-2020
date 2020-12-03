using System;
using System.IO;

var input = File.ReadAllLines("input.txt");

var numberOfTrees = 0;
var pointer = 3;
var currentLine = 1;

while (currentLine < input.Length)
{
    var line = input[currentLine];
    Console.WriteLine($"{currentLine}-{pointer}: {line} --> {pointer} = {line[pointer]}");

    if (line[pointer] == '#')
    {
        numberOfTrees++;
    }

    pointer += 3;
    if (pointer > line.Length - 1)
    {
        pointer = pointer - line.Length;
    }
    currentLine++;
}

Console.WriteLine($"{numberOfTrees} Trees");