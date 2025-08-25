using UnityEngine;

public class PlantAnimationEventLongRange : PlantAnimationEvent
{
    [SerializeField] protected PlantLongRangeAttackCtrl plantLongRangeCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlantLongRangeCtrl();
    }
    protected virtual void LoadPlantLongRangeCtrl()
    {
        if (this.plantLongRangeCtrl != null) return;
        this.plantLongRangeCtrl = GetComponentInParent<PlantLongRangeAttackCtrl>();
    }
    public override void EndEventDefaultDamageSender()
    {
        this.plantLongRangeCtrl.PlantEventDefaultAttack.gameObject.SetActive(true);
    }

    public override void StartEventDefaultDamageSender()
    {
        this.plantLongRangeCtrl.PlantEventDefaultAttack.gameObject.SetActive(false);
    }
}
