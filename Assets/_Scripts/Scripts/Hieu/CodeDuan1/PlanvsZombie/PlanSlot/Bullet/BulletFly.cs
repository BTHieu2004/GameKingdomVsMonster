using UnityEngine;

public class BulletFly : HieuMonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected Bullet bullet;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletSO();
    }
    protected virtual void LoadBulletSO()
    {
        if (this.bullet != null) return;
        bullet = GetComponentInParent<Bullet>();
        this.speed = this.bullet.BulletSO.speed;
    }
    protected virtual void Update()
    {
        transform.parent.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
