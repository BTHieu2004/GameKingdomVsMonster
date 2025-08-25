using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InfoSelection : HieuMonoBehaviour
{    
    [SerializeField] protected TextMeshProUGUI topText;
    [SerializeField] protected TextMeshProUGUI description;
    [SerializeField] protected Image image;   
    protected override void LoadComponents()
    {
        base.LoadComponents();      
        this.LoadTopText();
        this.LoadDescription();
        this.LoadImage();
    }    
    protected virtual void LoadTopText()
    {
        if (this.topText != null) return;
        this.topText = transform.Find("TopText").GetComponent<TextMeshProUGUI>();
    }
    protected virtual void LoadDescription()
    {
        if (this.description != null) return;
        this.description = transform.Find("Description").GetComponent<TextMeshProUGUI>();
    }
    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = transform.Find("Image").GetComponent<Image>();
    }    
    public virtual void InfoSelectPlant(PlantSO plantSO)
    {        
        this.topText.text = plantSO.name.ToString();
        this.description.text = plantSO.description.ToString();
        this.image.sprite = plantSO.sprite;
    }
}
