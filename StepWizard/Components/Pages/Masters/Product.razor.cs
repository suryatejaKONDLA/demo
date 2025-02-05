namespace StepWizard.Components.Pages.Masters;

public partial class Product
{
    private ProductModel Model;
    [Parameter] public string StepName { get; set; }
    [Parameter] public Controls.StepWizard Wizard { get; set; }
    [Parameter] public object Context { get; set; }

    protected override void OnInitialized() { Model = Context as ProductModel ?? new ProductModel(); }

    private async Task HandleValidSubmit(EditContext context)
    {
        if (!context.Validate())
        {
            return;
        }

        await Wizard.OnStepValidSubmit(StepName, Model);
    }
}