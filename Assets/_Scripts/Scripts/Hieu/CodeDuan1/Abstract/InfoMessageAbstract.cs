using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class InfoMessageAbstract : HieuMonoBehaviour
{
    [SerializeField] protected string message;
    public string ResultMessage => message;    
    public string Message(string message)
    {   
        return this.message = message;        
    }    
}
