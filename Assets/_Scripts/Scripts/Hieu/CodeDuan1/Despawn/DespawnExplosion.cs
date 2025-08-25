using UnityEngine;

public class DespawnExplosion : Despawn<Explosion>
{
    [SerializeField] protected AnimationClip animationClip;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAniClip();
    }
    protected virtual void LoadAniClip()
    {
        if (this.animationClip != null) return;
        this.animationClip = GetComponentInParent<Explosion>().AnimatorExplosion.GetAniCLipByName("Explosion");
    }
    protected override void Resetvalue()
    {
        base.Resetvalue();
        this.timeLife = this.animationClip.length;
    }
}
