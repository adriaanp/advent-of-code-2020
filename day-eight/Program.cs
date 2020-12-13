using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

var input = File.ReadAllLines("input.txt");

var executeHistory = new List<int>();
var accumulator = 0;
var instructionPointer = 0;

while (instructionPointer <= input.Length)
{
    if (executeHistory.Contains(instructionPointer))
    {
        Console.WriteLine($"Instruction repeated: {instructionPointer} with acc value {accumulator}.");
        break;
    }
    executeHistory.Add(instructionPointer);
    var regex = Regex.Match(input[instructionPointer], @"(.{3}) (.+)");
    switch(regex.Groups[1].Value)
    {
        case "jmp":
            instructionPointer += int.Parse(regex.Groups[2].Value);
            break;
        case "nop":
            instructionPointer++;
            break;
        case "acc":
            accumulator += int.Parse(regex.Groups[2].Value);
            instructionPointer++;
            break;
    }
}