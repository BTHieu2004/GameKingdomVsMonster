using System.Collections.Generic;
using UnityEngine;

public class SelectLevelUI : BaseUIAbstract
{
    [SerializeField] protected LevelDataSO levelDataSO;
    public LevelDataSO LevelDataSO => levelDataSO;
    [SerializeField] protected List<LevelSO> listLevelSO;
    public List<LevelSO> ListLevelSO => listLevelSO;
    [SerializeField] protected BtnSelectLevel btnSelectLevel;
    protected virtual void Start()
    {
        this.InstanceBtnSelectLevel();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLevelData();
        this.LoadListLevelSO();
        this.LoadBtnSelectLevel();        
    }
    protected virtual void LoadLevelData()
    {
        if (this.levelDataSO != null) return;
        this.levelDataSO = Resources.Load<LevelDataSO>("Level/LevelData");
    }
    protected virtual void LoadListLevelSO()
    {        
        this.listLevelSO = this.levelDataSO.listLevelSO;
    }
    protected virtual void LoadBtnSelectLevel()
    {
        if (this.btnSelectLevel != null) return;
        this.btnSelectLevel = GetComponentInChildren<BtnSelectLevel>();
        this.btnSelectLevel.gameObject.SetActive(false);
    }
    protected virtual void InstanceBtnSelectLevel()
    {
        foreach(LevelSO child in this.listLevelSO)
        {
            BtnSelectLevel btnSelectLevel = Instantiate(this.btnSelectLevel);
            btnSelectLevel.SetLevelSOBtn(child);            
            btnSelectLevel.transform.SetParent(this.btnSelectLevel.transform.parent);
            btnSelectLevel.gameObject.SetActive(true);
            btnSelectLevel.transform.localScale = Vector3.one;
            btnSelectLevel.name = child.name;
        }
    }
}
