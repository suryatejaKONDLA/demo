namespace StepWizard.Components.Controls;

public partial class StepWizard
{
    private readonly Dictionary<string, object> StepDataStore = new();
    [Parameter] public List<WizardStep> Steps { get; set; } = [];

    [Parameter] public EventCallback<Dictionary<string, object>> OnCompleted { get; set; }

    private int CurrentStepIndex { get; set; }

    private bool IsLastStep => CurrentStepIndex == Steps.Count - 1;

    private WizardStep ActiveStep => Steps[CurrentStepIndex];

    public async Task OnStepValidSubmit(string stepName, object stepData)
    {
        // Store the child step’s data
        StepDataStore[stepName] = stepData;
        Steps[CurrentStepIndex].IsCompleted = true;

        if (IsLastStep)
        {
            // Final submission
            if (OnCompleted.HasDelegate)
            {
                await OnCompleted.InvokeAsync(StepDataStore);
            }

            ResetWizard();
        }
        else
        {
            // Go to the next step
            CurrentStepIndex++;
            await InvokeAsync(StateHasChanged);
        }
    }

    public void GoPrevious()
    {
        if (CurrentStepIndex > 0)
        {
            CurrentStepIndex--;
        }
    }

    private object GetCurrentStepData()
    {
        var stepName = ActiveStep.StepName;
        return StepDataStore.GetValueOrDefault(stepName);
    }

    private EventCallback GetStepOnClick(int stepIndex) { return IsStepClickable(stepIndex) ? EventCallback.Factory.Create(this, () => OnStepIndicatorClicked(stepIndex)) : default; }

    private string GetStepClass(int stepIndex)
    {
        if (stepIndex == CurrentStepIndex)
        {
            return "step active";
        }

        return Steps[stepIndex].IsCompleted ? "step completed" : "step incomplete";
    }

    private void OnStepIndicatorClicked(int stepIndex)
    {
        if (!IsStepClickable(stepIndex))
        {
            return;
        }

        CurrentStepIndex = stepIndex;
        StateHasChanged();
    }

    private void ResetWizard()
    {
        StepDataStore.Clear(); // Clear all saved step data

        foreach (var step in Steps)
        {
            step.IsCompleted = false; // Mark all steps as incomplete
        }

        CurrentStepIndex = 0; // Go back to the first step
        StateHasChanged(); // Refresh UI
    }

    private int GetMaxClickableStepIndex()
    {
        var maxClickable = -1;
        for (var i = 0; i < Steps.Count; i++)
        {
            if (Steps[i].IsCompleted)
            {
                maxClickable = i;
            }
        }

        return maxClickable + 1;
    }

    private bool IsStepClickable(int stepIndex)
    {
        var maxStep = GetMaxClickableStepIndex();
        return stepIndex <= maxStep;
    }
}