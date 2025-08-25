using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public class PlantCtrl : HieuMonoBehaviour
{    
    [SerializeField] protected PlantSO plantSO;
    public PlantSO PlantSO => plantSO;


    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected DetectetEnemy detectEnemy;
    public DetectetEnemy DetectEnemy => detectEnemy;


    [SerializeField] protected PlantDamageReceive plantDamageReceive;
    public PlantDamageReceive PlantDamageReceive => plantDamageReceive;


    [SerializeField] protected PlantAnimationCtrl aniPlantCtrl;
    public PlantAnimationCtrl AniPlantCtrl => aniPlantCtrl;

    [SerializeField] protected Spawner<SoundCtrl> spawner;
    public Spawner<SoundCtrl> SoundSpawner => spawner;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlantSO();
        this.LoadModel();
        this.LoadDetectEnemy();
        this.LoadDamageReceive();
        this.LoadAniPlantCtrl();
        this.LoadSoundSpawner();
    }    
    protected virtual void LoadPlantSO()
    {
        if (this.plantSO != null) return;
        string name = transform.name;
        this.plantSO = Resources.Load<PlantSO>("Plant/"+name);
    }
    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
    }        
    protected virtual void LoadDetectEnemy()
    {
        if (this.detectEnemy != null) return;
        this.detectEnemy = GetComponentInChildren<DetectetEnemy>();
    }
    protected virtual void LoadDamageReceive()
    {
        if (this.plantDamageReceive != null) return;
        this.plantDamageReceive = GetComponentInChildren<PlantDamageReceive>();
    }
    protected virtual void LoadAniPlantCtrl()
    {
        if (this.aniPlantCtrl != null) return;
        this.aniPlantCtrl = GetComponentInChildren<PlantAnimationCtrl>();
    }     
    protected virtual void LoadSoundSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = FindAnyObjectByType<Spawner<SoundCtrl>>();
    }
}
