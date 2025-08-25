using UnityEngine;

public class SelectionUI : BaseUIAbstract
{
    [SerializeField] protected SelectionHolder selectionHolder;
    public SelectionHolder SelectionHolder => selectionHolder;

    [SerializeField] protected SelectedUI selectedUI;
    public SelectedUI SelectedUI => selectedUI;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSelectionHolder();
        this.LoadSelectedUI();
    }
    protected virtual void LoadSelectionHolder()
    {
        if (this.selectionHolder != null) return;
        this.selectionHolder = GetComponentInChildren<SelectionHolder>();
    }
    protected virtual void LoadSelectedUI()
    {
        if (this.selectedUI != null) return;
        this.selectedUI = GetComponentInChildren<SelectedUI>();
    }
}
