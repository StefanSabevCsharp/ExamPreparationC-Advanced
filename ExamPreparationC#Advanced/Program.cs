int[] textile = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
int[] meds = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

Queue<int> textiles = new Queue<int>(textile);
Stack<int> medicaments = new Stack<int>(meds);

SortedDictionary<string, int> healingItems = new();

while(textiles.Count > 0 && medicaments.Count > 0)
{
    
    int currentTextile = textiles.Dequeue();
    int currentMedicament = medicaments.Pop();
    int sum = currentTextile + currentMedicament;
    if(sum == 30)
    {
        if (!healingItems.ContainsKey("Patch"))
        {
            healingItems.Add("Patch", 0);
        }
        healingItems["Patch"]++;
    }
    else if(sum == 40)
    {
        if (!healingItems.ContainsKey("Bandage"))
        {
            healingItems.Add("Bandage", 0);
        }
        healingItems["Bandage"]++;
    }
    else if (sum == 100)
    {
        if (!healingItems.ContainsKey("MedKit"))
        {
            healingItems.Add("MedKit", 0);
        }
        healingItems["MedKit"]++;
    }
    else if (sum > 100)
    {
        if (!healingItems.ContainsKey("MedKit"))
        {
            healingItems.Add("MedKit", 0);
        }
        healingItems["MedKit"]++;
        sum -= 100;
        int currentMedicamentToPush = medicaments.Pop();
        medicaments.Push(currentMedicamentToPush + sum);
    }
    else
    {
        currentMedicament += 10;
        medicaments.Push(currentMedicament);
    }

}
if (medicaments.Count == 0 && textiles.Count == 0 )
{
    Console.WriteLine("Textiles and medicaments are both empty.");
}
else if (medicaments.Count == 0)
{
    Console.WriteLine("Medicaments are empty.");
}
else
{
    Console.WriteLine("Textiles are empty.");
}

foreach (var item in healingItems.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
{
    Console.WriteLine($"{item.Key} - {item.Value}");
}
if (medicaments.Count > 0)
{

    Console.Write("Medicaments left: ");
    Console.WriteLine(string.Join(", ", medicaments));
}
else if (textiles.Count > 0)
{
    Console.Write("Textiles left: ");

    Console.WriteLine(string.Join(", ", textiles));
}