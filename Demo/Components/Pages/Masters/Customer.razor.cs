namespace Demo.Components.Pages.Masters;

public partial class Customer
{
    private CustomerModel Model;
    [Parameter] public string StepName { get; set; }
    [Parameter] public StepWizard Wizard { get; set; }
    [Parameter] public object Context { get; set; }
    [Parameter] public EditContext EditContext { get; set; }

    protected override void OnInitialized()
    {
        Model = Context as CustomerModel ?? new CustomerModel();
        EditContext = new(Model);
    }

    private async Task HandleValidSubmit()
    {
        if (!EditContext.Validate())
        {
            return;
        }

        await Wizard.OnStepValidSubmit(StepName, Model);
    }
}