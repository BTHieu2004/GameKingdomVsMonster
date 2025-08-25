using UnityEngine;

public class AcherEventDefaultAttack : PlantEventLongRangeDefaultAttack
{    
    protected override void SpawnBullet()
    {
        this.DirectionEnemy();
        Bullet bulltetIns = this.spawner.Spawn(this.bullet, transform.position, transform.rotation);
    }
    protected virtual void DirectionEnemy()
    {
        Vector2 direction =  this.plantCtrl.DetectEnemy.DirectionEnemy - (Vector2)transform.position;
        float agle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(agle,Vector3.forward);
        transform.rotation = rotation;        
    }
}
