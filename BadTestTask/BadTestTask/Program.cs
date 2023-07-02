// See https://aka.ms/new-console-template for more information

using BadTestTask;

while (true)
{
    Console.WriteLine("input you text or press ENTER to exit");
    string? input = Console.ReadLine();
    if (string.IsNullOrWhiteSpace(input)) break;

    var parser = new UniqueCharacterParser();

    Console.WriteLine($"first unique character: {parser.GetFirstUniqueChar(input)}");
    Console.WriteLine();
}