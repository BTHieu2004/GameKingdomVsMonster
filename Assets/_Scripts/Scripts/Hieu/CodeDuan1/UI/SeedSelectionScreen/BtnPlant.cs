using System;
using UnityEngine;
using UnityEngine.UI;

public class BtnPlant : BtnMenuAbstract
{
    [SerializeField] protected PlantSO plantSO;
    [SerializeField] protected Image backGround;
    [SerializeField] protected Image infoImage;
    [SerializeField] protected InfoSelection infoSelection;
    [SerializeField] protected SelectedUI Selected;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBackGroundIm();
        this.LoadInfoIm();
        this.LoadInfoSelectionUI();
        this.LoadPlantSlot();
    }
    protected virtual void LoadBackGroundIm()
    {
        if (this.backGround != null) return;
        this.backGround = transform.Find("BackGround").GetComponent<Image>();
    }
    protected virtual void LoadInfoIm()
    {
        if (this.infoImage != null) return;
        this.infoImage = transform.Find("Image").GetComponent<Image>();
    }
    protected virtual void LoadInfoSelectionUI()
    {
        if (this.infoSelection != null) return;
        this.infoSelection = GetComponentInParent<SelectionHolder>().InfoSelection;
    }
    protected virtual void LoadPlantSlot()
    {
        if (this.Selected != null) return;
        this.Selected = GetComponentInParent<SelectionHolder>().GetComponentInParent<SelectionUI>().GetComponentInChildren<SelectedUI>();
    }
    protected override void OnClick()
    {
        if (!this.plantSO.unLock) return;
        if (this.plantSO.selected == true) return;
        this.plantSO.selected = true;
        this.Selected.AddSlot(plantSO);
        this.infoSelection.InfoSelectPlant(plantSO);            
    }
    public virtual void SetUpBtnInfo(PlantSO plantSO)
    {
        this.plantSO = plantSO;
        this.infoImage.sprite = this.plantSO.sprite;
    }
}
