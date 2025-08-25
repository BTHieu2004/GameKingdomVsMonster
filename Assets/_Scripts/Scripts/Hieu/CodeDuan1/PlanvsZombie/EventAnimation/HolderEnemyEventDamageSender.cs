using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HolderEnemyEventDamageSender : HieuMonoBehaviour
{
    [SerializeField] protected List<EnemyDamageSender> damageSender;
    [SerializeField] protected Vector2 posDamageReceive;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListEnemyDamageSender();        
    }
    protected virtual void LoadListEnemyDamageSender()
    {
        if (this.damageSender.Count > 0) return;
        this.damageSender = this.GetComponentsInChildren<EnemyDamageSender>().ToList();
    }    
    public EnemyDamageSender GetObjEventDamageSender(string name)
    {
        foreach (EnemyDamageSender child in this.damageSender)
        {
            if (child.name != name) continue;
            return child;
        }
        return null;
    }
    public virtual void AddPosDamageSender(Vector2 pos)
    {
        this.posDamageReceive = pos;
    }
    public virtual Vector2 PosDamageSender()
    {
        return this.posDamageReceive;
    }
}
