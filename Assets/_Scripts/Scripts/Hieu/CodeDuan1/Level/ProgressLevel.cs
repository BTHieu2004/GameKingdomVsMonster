using Unity.VisualScripting;
using UnityEngine;

public class ProgressLevel : HieuSingleton<ProgressLevel>
{
    [SerializeField] protected LevelDataSO levelDataSO;
    public LevelDataSO LevelDataSO => levelDataSO;

    [SerializeField] protected LevelSO levelSO;
    public LevelSO LevelSO => levelSO;


    [SerializeField] protected GameStartHolder gameStartHolder;
    [SerializeField] protected int quantitySun;
    public int QuantitySun => quantitySun;

    [SerializeField] protected int countEnemyDead;
    [SerializeField] protected int countEnemySpawn;
    public bool isSpawnEnemy = true;
    public bool isStart;
    protected virtual void Start()
    {
        this.quantitySun = this.levelSO.countSunStart;
    }
    protected override void LoadInstance()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        if (instance == null)
        {
            instance = this;            
            return;
        }
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLevelDataSO();
        this.LoadLevelSO();
        this.LoadGameStartHolder();
    }
    protected virtual void LoadLevelDataSO()
    {
        if (this.levelDataSO != null) return;
        this.levelDataSO = Resources.Load<LevelDataSO>("Level/LevelData");
    }
    protected virtual void LoadLevelSO()
    {        
        this.levelSO = this.LevelDataSO.currentLevelSO;
    }
    protected virtual void LoadGameStartHolder()
    {
        if (this.gameStartHolder != null) return;
        this.gameStartHolder = FindAnyObjectByType<GameStartHolder>();
        this.gameStartHolder.gameObject.SetActive(false);
    }
    public virtual void CountEnemyDead(int count)
    {
        this.countEnemyDead += count;
        AchivementManager.instance.GetAchivementTypeID(EnumAchiverment.Hidden, 1);
        this.CompletedLevel();
    }
    public virtual void CountEnemySpawn(int count)
    {
        this.countEnemySpawn += count;
        if (countEnemySpawn == this.levelSO.countEnemySpawn)
        {
            this.isSpawnEnemy = false;
        }
    }
    protected virtual void CompletedLevel()
    {
        if (this.countEnemyDead < this.levelSO.countEnemySpawn) return;
        GameManager.Instance.PlayerWin();  
        this.CompleteAchivement();
        
        this.levelSO.completedLevel = true;
    }
    public virtual void IncreaseSun(int quantitySun)
    {
        this.quantitySun += quantitySun;
    }
    public virtual void MinusSun(int quantitySun)
    {
        this.quantitySun -= quantitySun;
    }
    public virtual void StartGame()
    {
        this.gameStartHolder.gameObject.SetActive(true);
        this.isStart = true;
    }
    protected virtual void CompleteAchivement()
    {
        int idLevel = this.levelSO.idLevel;
        AchivementManager.instance.GetAchivementTypeID(EnumAchiverment.Progress,idLevel);
    }
}
