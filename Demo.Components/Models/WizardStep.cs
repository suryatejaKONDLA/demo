namespace Demo.Components.Models;

public class WizardStep
{
    /// <summary>
    ///     Display name or title for this step in the wizard
    /// </summary>
    public string StepName { get; set; }

    /// <summary>
    ///     The Blazor component to render for this step
    ///     (e.g. typeof(MyFormComponent))
    /// </summary>
    public Type ComponentType { get; set; }

    /// <summary>
    ///     Whether the user has completed this step
    /// </summary>
    public bool IsCompleted { get; set; }
}