using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
public class PlantDamageReceive : DamageReceiveAbstract
{
    [SerializeField] protected PlantCtrl planCtrl;
    [SerializeField] protected CapsuleCollider2D colliderPlant;
    public int hp;    
    protected virtual void Start()
    {
        this.Resetvalue();
    }
    protected override void Resetvalue()
    {
        base.Resetvalue();
        this.hp = this.planCtrl.PlantSO.hpPlant;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlantCtrl();
        this.LoadCollider();
    }
    protected virtual void LoadPlantCtrl()
    {
        if (this.planCtrl != null) return;
        this.planCtrl = GetComponentInParent<PlantCtrl>();                
    }
    protected virtual void LoadCollider()
    {
        if (this.colliderPlant != null) return;
        this.colliderPlant = GetComponent<CapsuleCollider2D>();        
        this.colliderPlant.isTrigger = true;
        this.colliderPlant.size = new Vector2(1,1);
    }
    public override void TakeDamage(int damage)
    {
        this.hp -= damage;
        if (this.hp <=0) Destroy(transform.parent.gameObject);
    }
}
