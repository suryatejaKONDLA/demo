namespace Demo.Components.Pages;

public partial class Index
{
    private List<WizardStep> WizardSteps;

    protected override async Task OnInitializedAsync()
    {
        WizardSteps = await WizardData.GetWizardDataAsync();
    }

    private static void HandleWizardCompleted(Dictionary<string, object> allData)
    {
        var json = JsonSerializer.Serialize(allData, new JsonSerializerOptions { WriteIndented = true });
        const string dataDirectory = "Data";
        Directory.CreateDirectory(dataDirectory);
        var fileName = $"{DateTime.Now:yyyyMMdd_HHmmssfff}.txt";
        var filePath = Path.Combine(dataDirectory, fileName);
        File.WriteAllText(filePath, json);

        Console.WriteLine($"Data written to {filePath}");
    }
}