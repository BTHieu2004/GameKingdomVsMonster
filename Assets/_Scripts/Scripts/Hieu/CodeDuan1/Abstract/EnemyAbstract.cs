using UnityEngine;

public abstract class EnemyAbstract : PoolingObj
{
    [SerializeField] protected EnemySO enemySO;

    [SerializeField] protected Spawner<EnemyAbstract> spawner;
    public Spawner<EnemyAbstract> Spawner => spawner;

    [SerializeField] protected EnemyAnimationCtrl enemyAnimationCtrl;
    public EnemyAnimationCtrl EnemyAnimationCtrl => enemyAnimationCtrl;

    [SerializeField] protected EnemyMoving enemyMoving;
    public EnemyMoving EnemyMoving => enemyMoving;


    [SerializeField] protected EnemyDamageSender enemyDamageSender;
    public EnemyDamageSender EnemyDamageSender => enemyDamageSender;


    [SerializeField] protected EnemyDamageReceive enemyDamageReceive;
    public EnemyDamageReceive EnemyDamageReceive => enemyDamageReceive;


    [SerializeField] protected AttackZondable attackZonAble;
    public AttackZondable AttackZonAble => attackZonAble;


    [SerializeField] protected DetectPlant detecdPlant;


    [SerializeField] protected Spawner<SoundCtrl> soundSpawner;
    public Spawner<SoundCtrl> SoundSpawner => soundSpawner;

    public DetectPlant DetectPlant => detecdPlant;
    public EnemySO EnemySO => enemySO;
    [SerializeField] protected int speedStart;
    public int SpeedStart => speedStart;
    [SerializeField] protected int speed;
    public int SpeedEnemy => speed;
    [SerializeField] protected int hp;    
    public int HpEnemy => hp;

    [SerializeField] protected int damageDefault;
    public int DamageDefault => damageDefault;
    protected override void OnEnable()
    {
        this.Resetvalue();
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySO();
        this.LoadSpawner();
        this.LoadAnimatorCtrl();
        this.LoadEnemyMoving();
        this.LoadDamageSender();
        this.LoadDamageReceive();
        this.LoadDetecdPlant();
        this.LoadAttackZon();
        this.LoadSoundSpawner();
    }
    protected override void Resetvalue()
    {
        base.Resetvalue();
        this.HideObj();
        this.InfoEnemy();
    }
    protected virtual void HideObj()
    {
        this.detecdPlant.gameObject.SetActive(false);
        this.enemyDamageSender.gameObject.SetActive(false);
    }
    protected virtual void InfoEnemy()
    {
        this.speedStart = this.enemySO.speedEnemy;
        this.speed = this.speedStart;
        this.hp = this.enemySO.hpEnemy;
        this.damageDefault = this.enemySO.damage;
    }
    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = FindAnyObjectByType<Spawner<EnemyAbstract>>();
    }
    protected virtual void LoadAnimatorCtrl()
    {
        if (this.enemyAnimationCtrl != null) return;
        this.enemyAnimationCtrl = GetComponentInChildren<EnemyAnimationCtrl>();
    }
    protected virtual void LoadEnemyMoving()
    {
        if (this.enemyMoving != null) return;
        this.enemyMoving = GetComponentInChildren<EnemyMoving>();
    }
    protected virtual void LoadEnemySO()
    {
        if (this.enemySO != null) return;
        string name = transform.name;
        this.enemySO = Resources.Load<EnemySO>("Enemy/"+name);
    }
    protected virtual void LoadDamageSender()
    {
        if (this.enemyDamageSender != null) return;
        this.enemyDamageSender = GetComponentInChildren<EnemyDamageSender>();
    }
    protected virtual void LoadDamageReceive()
    {
        if (this.enemyDamageReceive != null) return;
        this.enemyDamageReceive = GetComponentInChildren<EnemyDamageReceive>();
    }
    protected virtual void LoadDetecdPlant()
    {
        if (this.detecdPlant != null) return;
        this.detecdPlant = GetComponentInChildren<DetectPlant>();
    }
    protected virtual void LoadAttackZon()
    {
        if (this.attackZonAble != null) return;
        this.attackZonAble = GetComponentInChildren<AttackZondable>();
    }
    protected virtual void LoadSoundSpawner()
    {
        if (this.soundSpawner != null) return;
        this.soundSpawner = FindAnyObjectByType<Spawner<SoundCtrl>>();
    }
    public virtual void EnemyHp(int hp)
    {
        this.hp -= hp;
    }
    public virtual void EnemySpeed(int speed)
    {
        this.speed = speed;
    }
}
