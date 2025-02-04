namespace Demo.Components.Pages.Masters;

public partial class Supplier
{
    private SupplierModel Model;
    [Parameter] public string StepName { get; set; }
    [Parameter] public StepWizard Wizard { get; set; }
    [Parameter] public object Context { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Model = Context as SupplierModel ?? new SupplierModel();
    }

    private async Task HandleValidSubmit(EditContext context)
    {
        if (!context.Validate())
        {
            return;
        }

        await Wizard.OnStepValidSubmit(StepName, Model);
    }
}