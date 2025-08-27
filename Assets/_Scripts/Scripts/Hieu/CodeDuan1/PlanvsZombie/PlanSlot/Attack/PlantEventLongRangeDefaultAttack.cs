using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlantEventLongRangeDefaultAttack : HieuMonoBehaviour
{
    [SerializeField] protected PlantCtrl plantCtrl;
    [SerializeField] protected BulletSpawner spawner;
    [SerializeField] protected Bullet bullet;

    protected override void OnEnable()
    {
        base.OnEnable();
        if (this.bullet == null) return;
        this.Shoot();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlantCtrl();
        this.LoadBullet();        
    }
    protected virtual void LoadPlantCtrl()
    {
        if (this.plantCtrl != null) return;
        this.plantCtrl = GetComponentInParent<PlantCtrl>();
    }
    protected virtual void LoadBullet()
    {
        this.spawner = FindAnyObjectByType<BulletSpawner>();
        this.bullet = this.plantCtrl.PlantSO.bullet.objBullet.GetComponent<Bullet>();
    }   
    protected virtual void Shoot()
    {
        this.SpawnBullet();
    }
    protected virtual void SpawnBullet()
    {
        Bullet bulltetIns = this.spawner.Spawn(this.bullet, transform.position, Quaternion.identity);
    }
}
