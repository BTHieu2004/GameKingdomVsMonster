using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BtnSelectLevel : BtnMenuAbstract
{
    [SerializeField] protected SelectLevelUI selectLevelUI;
    [SerializeField] protected LevelSO levelSO;
    [SerializeField] protected Image image;
    public LevelSO LevelSO => levelSO;
    protected override void Start()
    {
        base.Start();
        this.LevelCanSelect();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSelectLevelUI();
        this.LoadImage();
    }
    protected virtual void LoadSelectLevelUI()
    {
        if (this.selectLevelUI != null) return;
        this.selectLevelUI = GetComponentInParent<SelectLevelUI>();
    }
    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = GetComponent<Image>();
    }
    protected override void OnClick()
    {
        this.SelectLevel();
    }
    public virtual void SetLevelSOBtn(LevelSO levelSO)
    {
        this.levelSO = levelSO;
    }
    protected virtual void SelectLevel()
    {
        this.selectLevelUI.LevelDataSO.currentLevelSO = this.levelSO;
        SceneManager.LoadScene(NameScene.SceneGamePlay);
    }
    protected virtual void LevelCanSelect()
    {
        if (!this.levelSO.completedLevel)
        {
            this.button.interactable = false;
            Color color;
            if (ColorUtility.TryParseHtmlString("#77CF5F", out color))
            {
                this.image.color = color;
            }
            return;
        }
        this.button.interactable = true;
        Color colorUnlock;
        if (ColorUtility.TryParseHtmlString("#3AFF00", out colorUnlock))
        {
            this.image.color = colorUnlock;
        }
    }
}
