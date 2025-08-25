using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class Spawner<T> : HieuMonoBehaviour where T : PoolingObj
{
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<T> poolingObjs = new();    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHolder();        
    }
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
    }    
    public virtual T Spawn(T objSpawn, Vector2 transform, Quaternion direction)
    {        
        T newObj = this.GetObjPooling(objSpawn);        
        if (newObj == null)
        {
            newObj = Instantiate(objSpawn);
        }        
        newObj.transform.position = transform;
        newObj.transform.rotation = direction;
        newObj.transform.parent = this.holder;
        newObj.gameObject.SetActive(true);
        return newObj;
    }
    public virtual T Spawn(T objSpawn)
    {
        T newObj = this.GetObjPooling(objSpawn);        
        if (newObj == null)
        {
            newObj = Instantiate(objSpawn);
        }       
        newObj.transform.parent = this.holder;
        newObj.gameObject.SetActive(true);
        return newObj;
    }
    protected virtual T GetObjPooling(T objSpawn)
    {
        foreach (T child in this.poolingObjs)
        {
            if (child.NameObj() != objSpawn.NameObj()) continue;
            this.poolingObjs.Remove(child);
            return child;
        }        
        return null;        
    }        
    public virtual void Despawn(T objDespawn)
    {        
        this.AddObjToPool(objDespawn);
    }
    protected virtual void AddObjToPool(T obj)
    {
        if (obj is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.gameObject.SetActive(false);
            this.poolingObjs.Add(obj);
        }
    }
}
