using UnityEngine;

public abstract class PlantAnimationEventCloseRange : PlantAnimationEvent
{
    [SerializeField] protected PlantCloseRangeAttackCtrl plantCloseRangeCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlantCtrl();
    }
    protected virtual void LoadPlantCtrl()
    {
        if (this.plantCloseRangeCtrl != null) return;
        this.plantCloseRangeCtrl = GetComponentInParent<PlantCloseRangeAttackCtrl>();
    }
    public override void StartEventDefaultDamageSender()
    {          
        this.plantCloseRangeCtrl.PlantEventDefaultAttack.gameObject.SetActive(true);
    }
    public override void EndEventDefaultDamageSender()
    {        
        this.plantCloseRangeCtrl.PlantEventDefaultAttack.gameObject.SetActive(false);
    }
}
