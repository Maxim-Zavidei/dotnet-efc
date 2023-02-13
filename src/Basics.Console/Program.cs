// See https://aka.ms/new-console-template for more information
using Basics.Console.DataAccess;

Console.WriteLine("Hello, World!");

using (var context = new BasicsContext())
{
    var items = context.Entities.ToList();
    string result = string.Join("\n", items.Select(e => $"Id: [{e.Id}] - Name: [{e.Name}]"));
    System.Console.WriteLine(result);
}

Console.ReadLine();
