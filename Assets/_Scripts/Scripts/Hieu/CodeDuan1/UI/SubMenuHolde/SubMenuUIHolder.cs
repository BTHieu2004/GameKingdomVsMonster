using UnityEngine;

public class SubMenuUIHolder : HieuMonoBehaviour
{
    [SerializeField] protected SoundUI soundUI;
    public SoundUI SoundUI => soundUI;

    [SerializeField] protected ShopUI shopUI;
    public ShopUI ShopUI => shopUI;

    [SerializeField] protected AchivementUI achivementUI;
    public AchivementUI AchivementUI => achivementUI;

    [SerializeField] protected SelectLevelUI selectLevelUI;
    public SelectLevelUI SelectLevelUI => selectLevelUI;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSoundUI();
        this.LoadShopUI();
        this.LoadAchivementUI();
        this.LoadSelectLevelUI();
    }
    protected virtual void LoadSoundUI()
    {
        if (this.soundUI != null) return;
        this.soundUI = GetComponentInChildren<SoundUI>();
    }
    protected virtual void LoadShopUI()
    {
        if (this.shopUI != null) return;
        this.shopUI = GetComponentInChildren<ShopUI>();
    }
    protected virtual void LoadAchivementUI()
    {
        if (this.achivementUI != null) return;
        this.achivementUI = GetComponentInChildren<AchivementUI>();
    }
    protected virtual void LoadSelectLevelUI()
    {
        if (this.selectLevelUI != null) return;
        this.selectLevelUI = GetComponentInChildren<SelectLevelUI>();
    }
}
