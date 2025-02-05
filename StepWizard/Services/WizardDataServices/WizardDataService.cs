namespace StepWizard.Services.WizardDataServices;

public class WizardDataService : IWizardDataService
{
    private List<WizardStep> WizardSteps = [];

    public Task<List<WizardStep>> GetWizardDataAsync()
    {
        WizardSteps =
        [
            new() { StepName = "Supplier Info", ComponentType = typeof(Supplier) },
            new() { StepName = "Product Info", ComponentType = typeof(Product) },
            new() { StepName = "Customer Info", ComponentType = typeof(Customer) }
        ];
        return Task.FromResult(WizardSteps);
    }
}