using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

var seat = "BFFFBBFRRR";
Console.WriteLine($"{seat}: {GetSeatId(seat)}");

var input = File.ReadAllLines("input.txt");
Console.WriteLine($"Highest seat id: {input.Select(GetSeatId).Max()}");

int GetSeatId(string seat)
{

    var row = Scan(seat.Take(7), 0, 127, 'F', 'B');
    var column = Scan(seat.Skip(7), 0, 7, 'L', 'R');

    return row * 8 + column;
}

int Scan(IEnumerable<char> rowData, int lowerRegion, int upperRegion, char lowerHalfChar, char upperHalfChar)
{
    foreach (var c in rowData)
    {
        var diff = (upperRegion - lowerRegion) / 2 + 1;

        if (c == lowerHalfChar)
        {
            upperRegion -= diff;
        }

        if (c == upperHalfChar)
        {
            lowerRegion += diff;
        }
    }
    return lowerRegion;
}