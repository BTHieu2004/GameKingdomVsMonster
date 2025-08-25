using UnityEngine;

public class PlantlongRangeDetect : DetectetEnemy
{    
    [SerializeField] protected float range;    
    protected virtual void Start()
    {
        this.Resetvalue();
    }    
    protected override void Resetvalue()
    {
        base.Resetvalue();        
        this.range = this.planCtrl.PlantSO.rangeAttack;
    }
}
