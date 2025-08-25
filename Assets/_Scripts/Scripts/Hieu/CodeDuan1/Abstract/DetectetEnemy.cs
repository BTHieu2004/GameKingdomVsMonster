using UnityEngine;

public abstract class DetectetEnemy : HieuMonoBehaviour
{
    [SerializeField] protected PlantCtrl planCtrl;
    [SerializeField] protected Vector2 directionEnemy;
    public Vector2 DirectionEnemy => directionEnemy;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlantCtrl();
    }
    protected virtual void LoadPlantCtrl()
    {
        if (this.planCtrl != null) return;
        this.planCtrl = GetComponentInParent<PlantCtrl>();
    }    
    protected virtual void DeffaultAttack()
    {
        this.planCtrl.AniPlantCtrl.AniDeffaultAttack();        
    }
    protected virtual void IdlePlant()
    {
        this.planCtrl.AniPlantCtrl.AniIdleDeffaultAttack();
    }
}
