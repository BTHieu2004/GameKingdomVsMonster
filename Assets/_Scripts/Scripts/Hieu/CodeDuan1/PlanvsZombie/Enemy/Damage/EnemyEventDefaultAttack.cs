using System.Collections;
using UnityEngine;

public class EnemyEventDefaultAttack : EnemyDamageSender
{        
    [SerializeField] protected PlantDamageReceive damageReceive;      
    protected override void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<PlantDamageReceive>() == null) return;
        damageReceive = collider.GetComponent<PlantDamageReceive>();
        damageReceive.TakeDamage(5);                                
    }    
}
