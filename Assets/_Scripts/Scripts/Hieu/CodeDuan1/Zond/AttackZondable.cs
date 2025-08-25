using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class AttackZondable : HieuMonoBehaviour
{
    [SerializeField] protected EnemyAbstract enemyAbstract;
    [SerializeField] protected CircleCollider2D circleCollider;

    [SerializeField] protected bool isAttackZon;
    public bool IsAttackZon => isAttackZon;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyAbstract();
        this.LoadCollider();
    }
    protected virtual void LoadEnemyAbstract()
    {
        if (this.enemyAbstract != null) return;
        this.enemyAbstract = GetComponentInParent<EnemyAbstract>();
    }
    protected virtual void LoadCollider()
    {
        if (this.circleCollider != null) return;
        this.circleCollider = GetComponent<CircleCollider2D>();
        this.circleCollider.isTrigger = true;
        this.circleCollider.radius = 0.3f;
        this.circleCollider.enabled = true;
    }
    protected override void Resetvalue()
    {
        base.Resetvalue();
        this.enemyAbstract.DetectPlant.gameObject.SetActive(false);
        this.isAttackZon = false;
    }
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<AttackZond>() == null) return;
        this.enemyAbstract.DetectPlant.gameObject.SetActive(true);
        isAttackZon = true;
    }
}
