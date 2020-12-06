using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;


var passports = LoadPassports();

Console.WriteLine($"Total passports: {passports.Count()}");
Console.WriteLine($"Valid Passports: {passports.Count(IsPassportValid)}");



bool IsPassportValid(Dictionary<string, string> passport)
{
    var requiredFields = new List<string>(){
        "byr", "iyr","eyr","hgt","hcl","ecl", "pid"
    };
    return requiredFields.All(passport.ContainsKey);
}

IEnumerable<Dictionary<string, string>> LoadPassports()
{
    var input = File.ReadAllLines("input.txt");
    var passports = new List<Dictionary<string, string>>();

    var passport = new Dictionary<string, string>();
    foreach (var line in input)
    {
        if (line.Length == 0)
        {
            passports.Add(passport);
            passport = new Dictionary<string, string>();
            continue;
        }

        var keyValues = line.Split(' ');
        foreach (var keyValue in keyValues)
        {
            var match = Regex.Match(keyValue, "(.*):(.*)");
            passport.Add(match.Groups[1].Value, match.Groups[2].Value);
        }
    }
    passports.Add(passport);
    return passports;
}


public class Passport
{
    public int BirthYear { get; set; }
    public int IssueYear { get; set; }
    public int ExpirationYear { get; set; }
    public string Height { get; set; }
    public string HairColor { get; set; }
    public string EyeColor { get; set; }
    public int Id { get; set; }
    public int CountryId { get; set; }
}