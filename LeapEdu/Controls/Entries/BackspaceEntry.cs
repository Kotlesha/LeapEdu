namespace LeapEdu.Controls.Entries;

internal partial class BackspaceEntry : Entry
{
    public event EventHandler BackspacePressedOnEmpty;
    public void InvokeBackspace() => BackspacePressedOnEmpty?.Invoke(this, EventArgs.Empty);
}
