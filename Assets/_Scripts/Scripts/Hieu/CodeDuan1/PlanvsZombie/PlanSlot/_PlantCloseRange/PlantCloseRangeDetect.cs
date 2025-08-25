using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class PlantCloseRangeDetect : DetectetEnemy
{    
    [SerializeField] protected CapsuleCollider2D rangeDetectPlant;
    protected override void LoadComponents()
    {
        base.LoadComponents();        
        this.LoadCollider();
    }    
    protected virtual void LoadCollider()
    {
        if (this.rangeDetectPlant != null) return;
        this.rangeDetectPlant = GetComponentInChildren<CapsuleCollider2D>();
        this.rangeDetectPlant.isTrigger = true;        
        this.rangeDetectPlant.offset = new Vector2(this.planCtrl.PlantSO.rangeAttack,0);
        this.rangeDetectPlant.size = new Vector2(1.27f,0.68f);
    }
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyDamageReceive>() == null) return;              
        this.DeffaultAttack();        
    }
    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyDamageReceive>() == null) return;
        this.IdlePlant();        
    }
}
