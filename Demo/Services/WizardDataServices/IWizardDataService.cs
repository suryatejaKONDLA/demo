namespace Demo.Services.WizardDataServices;

public interface IWizardDataService
{
    public Task<List<WizardStep>> GetWizardDataAsync();
}