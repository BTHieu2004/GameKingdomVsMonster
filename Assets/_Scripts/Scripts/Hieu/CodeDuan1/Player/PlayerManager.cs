using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : HieuSingleton<PlayerManager>
{
    [SerializeField] protected PlayerSO player;
    public PlayerSO PlayerSO => player;
    protected virtual void Start()
    {
        GameManager.Instance.onPlayerWin += IncreaseMony;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
    }
    public virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = Resources.Load<PlayerSO>("Player");
    }
    protected virtual void IncreaseMony()
    {
        this.player.money += ProgressLevel.Instance.LevelSO.bonus;
    }
}
