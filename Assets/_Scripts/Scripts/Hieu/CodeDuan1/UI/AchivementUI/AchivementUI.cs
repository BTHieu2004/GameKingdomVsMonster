using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AchivementUI : BaseUIAbstract
{
    [SerializeField] protected List<AchivementCtrl> achivementCtrls;
    [SerializeField] protected List<InfoAchivementSO> listInfoSO;    
    [SerializeField] protected BtnAchivement btnAchivement;
    [SerializeField] protected List<BtnAchivement> listBtnAchivement;
    protected override void OnEnable()
    {
        if (AchivementManager.Instance == null) return;
        this.LoadachivementCtrls();
        this.LoadInfoSO();
        this.InsBtnAchivement();
        if (this.listBtnAchivement.Count == 0) return;
        this.SortBtnAchiIndex();
        this.SetBilingIndex();

    }
    protected virtual void Start()
    {                  
        gameObject.SetActive(false);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnAchivement();
        btnAchivement.gameObject.SetActive(false);
    }
    protected virtual void LoadBtnAchivement()
    {
        if (this.btnAchivement != null) return;
        this.btnAchivement = GetComponentInChildren<BtnAchivement>();
    }
    protected virtual void LoadachivementCtrls()
    {        
        this.achivementCtrls = AchivementManager.Instance.AchivementCtrls;
    }   
    protected virtual void LoadInfoSO()
    {
        if (listInfoSO.Count > 0)
        {            
            listInfoSO.Clear();
        }
        foreach (AchivementCtrl achivement in this.achivementCtrls)
        {
            if (this.achivementCtrls == null) continue;
            listInfoSO.AddRange(achivement.AchivementSO);
        }
    }
    protected virtual void InsBtnAchivement()
    {
        if (this.listBtnAchivement.Count > 0) return;
        foreach (InfoAchivementSO infoAchivementSO in this.listInfoSO)
        {            
            BtnAchivement achivement = Instantiate(btnAchivement);
            achivement.transform.SetParent(this.btnAchivement.transform.parent,false);
            achivement.SetAchivement(infoAchivementSO);
            achivement.name = infoAchivementSO.name;            
            achivement.gameObject.SetActive(true);
            listBtnAchivement.Add(achivement);
        }
    }
    protected virtual void SortBtnAchiIndex()
    {
        //for(int i =0; i< this.listBtnAchivement.Count; i++)
        //{
        //    for(int j = i+1; j < this.listBtnAchivement.Count; j++)
        //    {
        //        if (!this.listBtnAchivement[i].BtnInfoAchivement.isComplete && this.listBtnAchivement[j].BtnInfoAchivement.isComplete)
        //        {
        //            Debug.Log("sort");
        //            var soCopy = this.listBtnAchivement[i];
        //            this.listBtnAchivement[i] = this.listBtnAchivement[j];                    
        //            this.listBtnAchivement[j] = soCopy;
        //        }
        //    }
        //}                
        this.listBtnAchivement = this.listBtnAchivement.OrderBy(x => x.AchivementSO.isClaimed).ThenByDescending(x => x.AchivementSO.isComplete).ToList();
    }
    protected virtual void SetBilingIndex()
    {
        for(int i = 0; i<listBtnAchivement.Count; i++)
        {
            listBtnAchivement[i].transform.SetSiblingIndex(i);
        }
    }
}
