using var file = new StreamReader("input.txt");
var list1 = new List<int>();
var list2 = new List<int>();
var nextLine = await file.ReadLineAsync();
while (nextLine != null)
{
    var pieces = nextLine.Split(' ',
        StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    list1.Add(int.Parse(pieces[0]));
    list2.Add(int.Parse(pieces[1]));
    nextLine = await file.ReadLineAsync();
}
list1.Sort();
list2.Sort();

var distance = 0;
for (int x = 0; x < list1.Count; x++)
{
    distance += Math.Abs(list1[x] - list2[x]);
}
Console.WriteLine(distance);

var count2 = list2.GroupBy(v => v).ToDictionary(k => k.Key, v => v.Count());
var similarity = 0;
foreach (var v in list1)
{
    similarity += count2.TryGetValue(v, out var count) ? count * v : 0;
}
Console.WriteLine(similarity);