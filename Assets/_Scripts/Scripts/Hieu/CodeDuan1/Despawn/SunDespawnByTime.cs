using UnityEngine;

public class SunDespawnByTime : Despawn<Sun>
{
    protected override void Resetvalue()
    {
        base.Resetvalue();
        this.isDespawnByTime = true;
        this.timeLife = this.parent.SunSO.timeLife;
    }
}
