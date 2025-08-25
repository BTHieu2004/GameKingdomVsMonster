using UnityEngine;

public class ContentBtnLevel : TextContentAbstract
{
    [SerializeField] protected BtnSelectLevel btnSelectLevel;
    protected virtual void Start()
    {
        this.TextContent();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnLevel();
    }
    protected virtual void LoadBtnLevel()
    {
        if (this.btnSelectLevel != null) return;
        this.btnSelectLevel = GetComponentInParent<BtnSelectLevel>();
    }
    protected override void TextContent()
    {        
        this.textContent.text = this.btnSelectLevel.LevelSO.name;
    }
}
