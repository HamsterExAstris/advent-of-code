// See https://aka.ms/new-console-template for more information

long sum = 0;
await foreach (var line in File.ReadLinesAsync("input.txt"))
{
    int first = 0, last = 0;
    bool firstSet = false;
    bool lastSet = false;
    foreach (var character in line)
    {
        if (character >= 48 && character <= 57)
        {
            var digit = character - 48;
            if (firstSet)
            {
                last = digit;
                lastSet = true;
            }
            else
            {
                first = digit;
                firstSet = true;
            }
        }
    }
    if (!lastSet)
    {
        last = first;
    }
    sum += 10 * first;
    sum += last;
}

Console.WriteLine(sum);

var numbers = new[]
{
    "zero",
    "one",
    "two",
    "three",
    "four",
    "five",
    "six",
    "seven",
    "eight",
    "nine"
};
sum = 0;
await foreach (var line in File.ReadLinesAsync("input.txt"))
{
    var firstIndex = Int32.MaxValue;
    var firstValue = -1;

    var lastIndex = -1;
    var lastValue = -1;

    for (var x = 0; x <= 9; x++)
    {
        var index = line.IndexOf((char)(x + 48));
        if (index >= 0 && index < firstIndex)
        {
            firstIndex = index;
            firstValue = x;
        }

        index = line.LastIndexOf((char)(x + 48));
        if (index > lastIndex)
        {
            lastIndex = index;
            lastValue = x;
        }
    }

    for (var x = 0; x < numbers.Length; x++)
    {
        var index = line.IndexOf(numbers[x]);
        if (index >= 0 && index < firstIndex)
        {
            firstIndex = index;
            firstValue = x;
        }

        index = line.LastIndexOf(numbers[x]);
        if (index > lastIndex)
        {
            lastIndex = index;
            lastValue = x;
        }
    }

    if (lastIndex == -1)
    {
        lastValue = firstValue;
    }
    sum += 10 * firstValue;
    sum += lastValue;
}

Console.WriteLine(sum);