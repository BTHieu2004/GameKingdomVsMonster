using UnityEngine;
using UnityEngine.UIElements;

public class PlantCloseRangeAttackCtrl : PlantCtrl
{
    [SerializeField] protected PlantCloseRangeDetect rangeAttackCtrl;
    public PlantCloseRangeDetect CloseRangeAttack => rangeAttackCtrl;
    [SerializeField] protected PlantEventCloseRangeDefaultAttack plantEventDefaultAttack;
    public PlantEventCloseRangeDefaultAttack PlantEventDefaultAttack => plantEventDefaultAttack;
    protected override void LoadComponents()
    {
        base.LoadComponents();        
        this.LoadRangeAttack();
        this.LoadEventAttack();
    }
    protected virtual void LoadRangeAttack()
    {
        if (this.rangeAttackCtrl != null) return;
        this.rangeAttackCtrl = GetComponentInChildren<PlantCloseRangeDetect>();
    }
    protected virtual void LoadEventAttack()
    {
        if (this.plantEventDefaultAttack != null) return;
        this.plantEventDefaultAttack = GetComponentInChildren<PlantEventCloseRangeDefaultAttack>();
    }
}
