using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlantAnimationCtrl : HieuMonoBehaviour
{
    [SerializeField] protected Animator animator;
    
    [SerializeField] protected List<AnimationClip> aniClip = new();
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadAniClip();
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponent<Animator>();
    }
    protected virtual void LoadAniClip()
    {
        if (this.aniClip.Count > 0) return;
        this.aniClip = this.animator.runtimeAnimatorController.animationClips.ToList();
    }    
    public virtual AnimationClip GetAniClipPlant(EnumAniClipPlant enumAni)
    {
        foreach (AnimationClip child in this.aniClip)
        {
            if (child.name != enumAni.ToString()) continue;
            return child;
        }
        return null;
    }
    public virtual void AniDeffaultAttack()
    {
        this.animator.SetBool("DefaultAttack",true);
        this.animator.SetBool("Idle", false);
    }
    public virtual void AniIdleDeffaultAttack()
    {
        this.animator.SetBool("Idle",true);
        this.animator.SetBool("DefaultAttack", false);
    }
}
