using Implementation1;
using SharedLibrary;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.ObjectModel;

string? firstName, lastName;

Console.WriteLine("Hello, this is Implementation 1!");

// Request user input
Console.WriteLine("Please input your first name...");

while (string.IsNullOrWhiteSpace(firstName = Console.ReadLine()))
    Console.WriteLine("Please enter a valid name");

Console.WriteLine("Please input your last name...");

while (string.IsNullOrWhiteSpace(lastName = Console.ReadLine()))
    Console.WriteLine("Please enter a valid name");

// Initialize fixed parameters. Normally these would come from a configuration file akin to appsettings, or another external configuration source (like a database).
var dividers = new Dictionary<int, string>()
{ 
    { 15, $"{firstName} {lastName}" },
    { 3, firstName },
    { 5, lastName }
};

var start = 1;
var end = 100;

// Initialize DI host
using var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => services
        .AddSingleton<IDivider, GeneralDivider>(_ => new GeneralDivider(new ReadOnlyDictionary<int, string>(dividers)))
        .AddTransient<IIterator, ConsoleIterator>(s => new ConsoleIterator(s.GetService<IDivider>()!, start, end)))
    .Build();

// To use DI in a console app, we need to create a scope.
using var scope = host.Services.CreateScope();

// Request an instance of the iterator and run it. Unfortunately we don't get the nicer version of DI (auto scoping, no need for service locator) in console apps.
var iterator = scope.ServiceProvider.GetService<IIterator>()!;

await iterator.StartSequence();
await host.RunAsync();