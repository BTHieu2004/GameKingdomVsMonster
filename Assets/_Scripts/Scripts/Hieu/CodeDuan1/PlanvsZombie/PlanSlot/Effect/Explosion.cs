using UnityEngine;

public class Explosion : PoolingObj
{
    [SerializeField] protected AnimatorExplosion animatorExplosion;
    public AnimatorExplosion AnimatorExplosion => animatorExplosion;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAniExplosion();
    }
    protected virtual void LoadAniExplosion()
    {
        if (this.animatorExplosion != null) return;
        this.animatorExplosion = GetComponentInChildren<AnimatorExplosion>();
    }
    public override string NameObj()
    {
        return "Explosion";
    }    
}
