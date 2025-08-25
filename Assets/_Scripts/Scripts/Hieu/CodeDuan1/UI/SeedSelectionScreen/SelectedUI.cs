using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SelectedUI : BaseUIAbstract
{
    [SerializeField] protected Slot slot;
    public Slot PlantSlot => slot;

    [SerializeField] protected List<Slot> listSlot = new();
    public int countSelected = 0;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlantSlot();
        this.LoadListSlot();
    }
    protected virtual void LoadPlantSlot()
    {
        if (this.slot != null) return;
        this.slot = GetComponentInChildren<Slot>();
    }
    protected virtual void LoadListSlot()
    {
        if (this.listSlot.Count > 0) return;
        this.listSlot = GetComponentsInChildren<Slot>().ToList();
    }
    public virtual void AddSlot(PlantSO plantSO)
    {
        foreach(Slot child in this.listSlot)
        {
            if (child.PlantSO != null) continue;
            this.countSelected++;
            child.AddPlantSlot(plantSO);
            return;
        }
    }
}
