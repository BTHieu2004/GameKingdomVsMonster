using UnityEngine;

public abstract class Bullet : PoolingObj
{
    [SerializeField] protected BulletSO bulletSO;
    public BulletSO BulletSO => bulletSO;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBullet();
    }
    protected virtual void LoadBullet()
    {
        if (this.bulletSO != null) return;
        string name = transform.name;
        this.bulletSO = Resources.Load<BulletSO>("Bullet/"+name);
    }
}
