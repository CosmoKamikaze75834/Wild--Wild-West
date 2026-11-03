public abstract class Window : UIVisibility
{
    public override void Open()
    {
        base.Open();
        UIGroup.interactable = true;
        UIGroup.blocksRaycasts = true;
    }

    public override void Close()
    {
        base.Close();
        UIGroup.interactable = false;
        UIGroup.blocksRaycasts = false;
    }
}