using TMPro;
using UnityEngine;

public class ConfirmPurChaseUI : BaseUIAbstract
{
    [SerializeField] protected PlantSO plantSO;
    [SerializeField] protected TextMeshProUGUI textMeshProUGUI;
    public PlantSO PlantSO => plantSO;
    public virtual void ConfirmKingdom(PlantSO Plantso)
    {
        this.plantSO = Plantso;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        if (this.textMeshProUGUI != null) return;
        this.textMeshProUGUI = transform.Find("TextPrirce").GetComponent<TextMeshProUGUI>();
    }
    protected virtual void LateUpdate()
    {
        textMeshProUGUI.text = "Price : " + this.plantSO.Price.ToString();
    }
}
