using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AchivementManager : HieuSingleton<AchivementManager>
{    
    [SerializeField] protected List<AchivementCtrl> achivementCtrls = new();
    public List<AchivementCtrl> AchivementCtrls => achivementCtrls;
    protected override void LoadComponents()
    {
        base.LoadComponents();        
        this.LoadAchivements();
    }    
    protected virtual void LoadAchivements()
    {
        if (this.achivementCtrls.Count > 0) return;
        this.achivementCtrls = GetComponentsInChildren<AchivementCtrl>().ToList();
    }
    public virtual void GetAchivementTypeID(EnumAchiverment enumAchivement,int id)
    {        
        foreach(AchivementCtrl achivementCtrl in this.achivementCtrls)
        {
            if (achivementCtrl.enumAchivement() != enumAchivement) continue;
            achivementCtrl.GetSO(id);
        }        
    }   
}
