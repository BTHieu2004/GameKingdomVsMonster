using UnityEngine;

public class SelectionHolder : BaseUIAbstract
{
    [SerializeField] protected ListSelection listSelection;
    public ListSelection ListSelection => listSelection;

    [SerializeField] protected InfoSelection infoSelection;
    public InfoSelection InfoSelection => infoSelection;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListSelection();
        this.LoadInfoSelection();
    }
    protected virtual void LoadListSelection()
    {
        if (this.listSelection != null) return;
        this.listSelection = GetComponentInChildren<ListSelection>();
    }
    protected virtual void LoadInfoSelection()
    {
        if (this.infoSelection != null) return; 
        this.infoSelection = GetComponentInChildren<InfoSelection>();
    }
}
