using UnityEngine;


public class AcherDetectEnemy : PlantlongRangeDetect
{
    protected virtual void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyDamageReceive>() == null) return;
        this.directionEnemy = collider.transform.position;
        this.DeffaultAttack();
    }
    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<EnemyDamageReceive>() == null) return;
        this.IdlePlant();
    }
}
