using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopManager : HieuSingleton<ShopManager>
{    
    [SerializeField] protected List<PlantSO> Plants = new();
    public List<PlantSO> PlantSOs => Plants;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadKingdomSo();
    }
    protected virtual void LoadKingdomSo()
    {
        if (this.Plants.Count > 0) return;
        this.Plants = Resources.LoadAll<PlantSO>("Warrior").ToList();
    }
}

