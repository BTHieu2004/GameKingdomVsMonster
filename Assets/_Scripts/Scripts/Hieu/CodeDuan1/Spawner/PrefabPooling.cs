using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PrefabPooling : HieuMonoBehaviour
{
    [SerializeField] protected List<PoolingObj> listPoolingObj = new();
    public List<PoolingObj> ListPoolingObj => listPoolingObj;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadListPooling();
    }
    protected virtual void LoadListPooling()
    {
        
    }
}
