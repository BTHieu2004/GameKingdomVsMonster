using UnityEngine;

public class WarriorSpawnSunCtrl : PlantCtrl
{
    [SerializeField] protected PlantSpawnSun plantSpawnSun;
    public PlantSpawnSun PlanetSpawnSun => plantSpawnSun;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnSun();
    }
    protected virtual void LoadSpawnSun()
    {
        if (this.plantSpawnSun != null) return;
        this.plantSpawnSun = GetComponentInChildren<PlantSpawnSun>();
    }
}
