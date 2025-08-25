using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BtnAchivement : BtnMenuAbstract
{
    [SerializeField] protected TextMeshProUGUI textContent;
    [SerializeField] protected TextMeshProUGUI textCount;
    [SerializeField] protected TextMeshProUGUI textComplete;
    [SerializeField] protected InfoAchivementSO achivementSO;
    public InfoAchivementSO AchivementSO => achivementSO;
    [SerializeField] protected Image imageBtn;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextContent();
        this.LoadTextCount();
        this.LoadTextComplete();
        this.LoadImageBtn();
    }
    protected override void Start()
    {
        base.Start();
        this.SetTextBtnAchivement();        
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        if (this.achivementSO == null) return;
        this.SetTextBtnAchivement();
    }
    protected virtual void LoadImageBtn()
    {
        if (this.imageBtn != null) return;
        this.imageBtn = GetComponent<Image>();
    }
    protected virtual void LoadTextContent()
    {
        if (this.textContent != null) return;
        this.textContent = transform.Find("TextContent").GetComponent<TextMeshProUGUI>();
    }
    protected virtual void LoadTextCount()
    {
        if (this.textCount != null) return;
        this.textCount = transform.Find("TextCount").GetComponent<TextMeshProUGUI>();
    }
    protected virtual void LoadTextComplete()
    {
        if(this.textComplete != null) return;
        this.textComplete = transform.Find("TextCompelete").GetComponent<TextMeshProUGUI>();
    }
    public virtual void SetAchivement(InfoAchivementSO infoAchivement)
    {
        this.achivementSO = infoAchivement;
    }
    protected override void OnClick()
    {        
        this.CompleteAchivement();
        this.TextComplete();
    }
    protected virtual void SetTextBtnAchivement()
    {
        if (this.achivementSO.isClaimed) return;
        this.textContent.text = achivementSO.description;        
        this.textCount.text = achivementSO.requiedCountCurrent +"/" +achivementSO.requiedCountMax;
      
    }   
    protected void CompleteAchivement()
    {
        if (!achivementSO.isComplete) return;
        this.imageBtn.color = Color.yellow;
        this.achivementSO.isClaimed = true;
    }
    protected virtual void TextComplete()
    {
        if (!this.achivementSO.isClaimed) return;
        this.textComplete.text = "Complete";        
        this.textCount.text = "";
        PlayerManager.Instance.PlayerSO.money += this.achivementSO.reward;
    }
}
