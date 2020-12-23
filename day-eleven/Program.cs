using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var input = File.ReadAllLines("input.txt");

var seatMap = input.Select(line => line.ToList()).ToList();

var currentSeatMap = seatMap;
List<List<char>> nextSeatMap = new List<List<char>>();
while (true)
{
    nextSeatMap = ComputeDirectAdjecant(currentSeatMap);
    if (CompareSeatMaps(nextSeatMap, currentSeatMap))
    {
        break;
    }
    currentSeatMap = nextSeatMap;
}

Console.WriteLine($"Total occupied seats: {nextSeatMap.SelectMany(x => x).Count(y => y == '#')}");

currentSeatMap = seatMap;
while (true)
{
    nextSeatMap = ComputeVisibleAjecant(currentSeatMap);
    if (CompareSeatMaps(nextSeatMap, currentSeatMap))
    {
        break;
    }
    currentSeatMap = nextSeatMap;
}

Console.WriteLine($"Total occupied seats: {nextSeatMap.SelectMany(x => x).Count(y => y == '#')}");

List<List<char>> ComputeVisibleAjecant(List<List<char>> seatMap)
{
    var newSeatMap = new List<List<char>>();
    for (var x = 0; x < seatMap.Count; x++)
    {
        var newRow = new List<char>();
        for (var y = 0; y < seatMap[x].Count; y++)
        {
            var seat = seatMap[x][y];
            var seats = GetVisibleSeats(seatMap, x, y);
            var newSeat = seat;
            if (seat == 'L' && seats.All(s => s != '#'))
            {
                newSeat = '#';
            }
            else if (seat == '#' && seats.Count(s => s == '#') >= 5)
            {
                newSeat = 'L';
            }
            newRow.Add(newSeat);
        }
        newSeatMap.Add(newRow);
    }
    return newSeatMap;
}

List<char> GetVisibleSeats(List<List<char>> map, int x, int y)
{
    var list = new List<char>();
    if (map[x][y] == '.')
    {
        return list;
    }

    // horizontal
    var row = map[x];
        var right = row.Skip(y + 1).FirstOrDefault(s => s != '.');
        var left = row.Take(y - 1).LastOrDefault(s => s != '.');
        list.Add(right);
        list.Add(left);

    //vertical
    var col = map.Select(r => r[y]);
    var top = col.Take(x - 1).LastOrDefault(s => s != '.');
    var bottom = col.Skip(x + 1).FirstOrDefault(s => s != '.');
    list.Add(top);
    list.Add(bottom);

    //diagnoally
    //???
    // get starting point for top/left start diaginoal and then select +1 until no more

    // get starting point for top/right start then select +1 on both until no more

    return list;
}

char GetVisibleSeatAt(List<List<char>> map, int x, int y)
{
    var m = map.Select(r => r.Where(c => c != '.'));
    if (x < 0 || y < 0 || x >= m.Count() || y >= m.ElementAt(x).Count())
    {
        return '*';
    }
    return m.ElementAt(x).ElementAt(y);
};

List<List<char>> ComputeDirectAdjecant(List<List<char>> seatMap)
{
    var newSeatMap = new List<List<char>>();
    for (var x = 0; x < seatMap.Count; x++)
    {
        var newRow = new List<char>();
        for (var y = 0; y < seatMap[x].Count; y++)
        {
            var seat = seatMap[x][y];
            var seats = GetSeatsAround(seatMap, x, y);
            var newSeat = seat;
            if (seat == 'L' && seats.All(s => s != '#'))
            {
                newSeat = '#';
            }
            else if (seat == '#' && seats.Count(s => s == '#') >= 4)
            {
                newSeat = 'L';
            }
            newRow.Add(newSeat);
        }
        newSeatMap.Add(newRow);
    }
    return newSeatMap;
}

List<char> GetSeatsAround(List<List<char>> seatMap, int x, int y)
{
    return new List<char>
    {
        GetSeatAt(seatMap, x - 1, y - 1),
        GetSeatAt(seatMap, x - 1, y),
        GetSeatAt(seatMap, x - 1, y + 1),
        GetSeatAt(seatMap, x, y - 1),
        GetSeatAt(seatMap, x, y + 1),
        GetSeatAt(seatMap, x + 1, y - 1),
        GetSeatAt(seatMap, x + 1, y),
        GetSeatAt(seatMap, x + 1, y + 1),
    }
    .Where(s => s != '*')
    .ToList();
}

char GetSeatAt(List<List<char>> map, int x, int y)
{
    if (x < 0 || y < 0 || x >= map.Count() || y >= map[0].Count())
    {
        return '*';
    }
    return map[x][y];
};

bool CompareSeatMaps(List<List<char>> a, List<List<char>> b) => Enumerable.Range(0, a.Count()).All(index => a[index].SequenceEqual(b[index]));