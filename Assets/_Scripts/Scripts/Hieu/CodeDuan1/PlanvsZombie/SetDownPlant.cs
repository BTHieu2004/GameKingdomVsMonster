using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class SetDownPlant : HieuMonoBehaviour
{    
    public event Action<PlantSO> setDownPlant;
    public PlantSO currentPlant;
    public Sprite currentPlanSprite;
    public Transform tiles;
    public LayerMask tileMask;    
    [SerializeField] protected Transform holder;
    [SerializeField] protected Spawner<SoundCtrl> soundSpawner;
    public Spawner<SoundCtrl> SoundSpawner => soundSpawner;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHolder();
        this.LoadSoundSpawner();
    }
    protected virtual void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = transform.Find("Holder");
    }
    protected virtual void LoadSoundSpawner()
    {
        if (this.soundSpawner != null) return;
        this.soundSpawner = FindAnyObjectByType<Spawner<SoundCtrl>>();
    }
    public void PlantSelected(PlantSO currentPlant, Sprite sprite)
    {
        this.currentPlant = currentPlant;
        this.currentPlanSprite = sprite;
    }
    protected virtual void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, tileMask);
        this.DisableTile();
        if (hit.collider == null || currentPlant == null) return;
        if (hit.collider.GetComponent<Tile>().HasPlant) return;
        this.HitData(hit);
        this.SetDown(hit);

    }
    protected virtual void SetDown(RaycastHit2D hit)
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.setDownPlant?.Invoke(this.currentPlant);            
            GameObject plant = Instantiate(this.currentPlant.objPlant, hit.collider.transform.position, Quaternion.identity);            
            plant.gameObject.SetActive(true);
            AchivementManager.Instance.GetAchivementTypeID(EnumAchiverment.Hidden, 2);
            this.PlayMusicSFX();
            plant.transform.parent = holder;
            plant.name = this.currentPlant.name;            
            this.currentPlanSprite = null;
            ProgressLevel.Instance.MinusSun(this.currentPlant.Price);            
            this.currentPlant = null;
        }
    }
    protected virtual void DisableTile()
    {
        foreach (Transform tile in tiles)
        {
            tile.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    protected virtual void HitData(RaycastHit2D hit)
    {
        hit.collider.GetComponent<SpriteRenderer>().sprite = currentPlanSprite;
        hit.collider.GetComponent<SpriteRenderer>().enabled = true;
    }
    protected virtual void PlayMusicSFX()
    {
        SoundSO soundSO = this.GetSoundSO();
        if (soundSO == null) return;
        SoundCtrl soundCtrl = soundSO.objSound.GetComponent<SoundCtrl>();
        this.soundSpawner.Spawn(soundCtrl,transform.position,Quaternion.identity);
    }
    protected virtual SoundSO GetSoundSO()
    {
        return this.currentPlant.GetSoundSO(SoundName.SoundPlaceWarrior);
    }
}
