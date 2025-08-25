
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BtnShop : BtnMenuAbstract
{
    //[SerializeField] protected TextMeshProUGUI textContent;
    [SerializeField] protected PlantSO plantSO;
    [SerializeField] protected ShopUI shopUI;
    [SerializeField] protected Image image;
    protected override void Start()
    {
        base.Start();        
    }
    protected virtual void Update()
    {
        this.WarriorColorImage();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBaseUI();
        this.LoadTextContent();
        this.LoadImage();
    }
    protected virtual void LoadBaseUI()
    {
        if (this.shopUI != null) return;
        this.shopUI = GetComponentInParent<ShopUI>();
    }
    protected virtual void LoadTextContent()
    {
        //if (this.textContent != null) return;
        //this.textContent = GetComponentInChildren<TextMeshProUGUI>();
    }
    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = GetComponentInChildren<Image>();
    }
    protected override void OnClick()
    {
        if (this.plantSO.unLock) return;
        this.ShowConfirmPurChaseUI();
        Debug.Log("Clik");
    }
    public virtual void SetPlantSO(PlantSO Plant)
    {        
        this.plantSO = Plant;
        this.image.sprite = this.plantSO.sprite;
    }
    protected virtual void ShowConfirmPurChaseUI()
    {
        this.shopUI.ConfirmPurChaseUI.Show();
        this.shopUI.ConfirmPurChaseUI.ConfirmKingdom(plantSO);        
    }
    protected virtual void WarriorColorImage()
    {
        if (!this.plantSO.unLock)
        {
            Color color;
            if (ColorUtility.TryParseHtmlString("#4C4C4C", out color))
            {
                this.image.color = color;
                Debug.Log("cp");
            }
            return;
        }
        Color colorUnLock;        
        if (ColorUtility.TryParseHtmlString("#FFFFFF", out colorUnLock))
        {
            this.image.color = colorUnLock;
        }
    }
}
