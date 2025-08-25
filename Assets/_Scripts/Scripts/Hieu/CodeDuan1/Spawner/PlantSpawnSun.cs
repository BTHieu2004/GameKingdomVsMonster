using UnityEngine;

public class PlantSpawnSun : HieuMonoBehaviour
{
    [SerializeField] protected SunSpawner sunSpawner;
    [SerializeField] protected Sun sun;
    [SerializeField] protected float waittingTimeSpawn = 0;
    [SerializeField] protected float timeSpawn = 4;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnSun();
        this.LoadSun();
    }
    protected virtual void LoadSpawnSun()
    {
        if (this.sunSpawner != null) return;
        this.sunSpawner = FindAnyObjectByType<SunSpawner>();
    }
    protected virtual void LoadSun()
    {
        if (this.sun != null) return;
        this.sun = this.sunSpawner.Sun;
    }
    protected virtual void Update()
    {
        this.waittingTimeSpawn += Time.deltaTime;
        if (this.waittingTimeSpawn < timeSpawn) return;
        this.waittingTimeSpawn = 0;
        Sun sunSpawn = this.sunSpawner.Spawn(this.sun,transform.position,Quaternion.identity);
        sunSpawn.DopToYPos(transform.position.y - 1);
        sunSpawn.transform.position = new Vector2(transform.position.x,transform.position.y + 1);
    }
}
