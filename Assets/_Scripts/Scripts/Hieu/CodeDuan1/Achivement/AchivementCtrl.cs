using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class AchivementCtrl : HieuMonoBehaviour
{
    [SerializeField] protected List<InfoAchivementSO> achivementsSO = new();
    public List<InfoAchivementSO> AchivementSO => achivementsSO;    
    public abstract EnumAchiverment enumAchivement();    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAchivementsSO();
    }
    protected virtual void LoadAchivementsSO()
    {
        string name = transform.name;
        if (this.achivementsSO.Count > 0) return;
        achivementsSO = Resources.LoadAll<InfoAchivementSO>(name).ToList();                
    }    
    public virtual void GetSO(int id)
    {        
        foreach(InfoAchivementSO child in achivementsSO)
        {
            if (child.id != id) continue;            
            if (child.isComplete) continue;
            child.requiedCountCurrent++;
            if (CompleteAchivement(child)) return;                        
            return;
        }
    }       
    public virtual bool CompleteAchivement(InfoAchivementSO infoAchivementSO)
    {
        if (infoAchivementSO.requiedCountCurrent < infoAchivementSO.requiedCountMax) return false;
        infoAchivementSO.isComplete = true;               
        return true;
    }
}
