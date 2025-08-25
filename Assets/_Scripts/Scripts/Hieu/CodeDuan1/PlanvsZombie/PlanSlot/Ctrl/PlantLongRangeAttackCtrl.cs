using UnityEngine;

public class PlantLongRangeAttackCtrl : PlantCtrl
{
    [SerializeField] protected PlantEventLongRangeDefaultAttack plantEventDefaultAttack;
    public PlantEventLongRangeDefaultAttack PlantEventDefaultAttack => plantEventDefaultAttack;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEventDefaultAttack();
    }
    protected virtual void LoadEventDefaultAttack()
    {
        if (this.plantEventDefaultAttack != null) return;
        this.plantEventDefaultAttack = GetComponentInChildren<PlantEventLongRangeDefaultAttack>();
    }
}
