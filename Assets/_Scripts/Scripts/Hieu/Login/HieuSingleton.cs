using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HieuSingleton<T> : HieuMonoBehaviour where T : MonoBehaviour
{
    protected static T instance;        
    public static T Instance
    {
        get
        {
            if (instance == null) Debug.LogError("Singleton instance has not been crated yet!");
            return instance;
        }
    }
    protected override void Awake()
    {
        base.Awake();
        this.LoadInstance();
    }
    protected virtual void LoadInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        if (instance == null)
        {
            instance = this as T;
            //if (gameObject.transform.parent != null) return;
            DontDestroyOnLoad(gameObject);
            return;
        }
        if (instance != this) Debug.LogError("Aother instance of singletonExample already exist");
    }
}
