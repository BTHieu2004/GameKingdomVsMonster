using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyAnimationCtrl : HieuMonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected RuntimeAnimatorController controller;
    [SerializeField] protected List<AnimationClip> aniClips;    
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
        this.LoadAniCtrl();
        this.LoadAniClips();
    }    
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponent<Animator>();
    }
    protected virtual void LoadAniCtrl()
    {
        if (this.controller != null) return;
        this.controller = this.animator.runtimeAnimatorController;
    }
    protected virtual void LoadAniClips()
    {
        if (this.aniClips.Count > 0) return;
        this.aniClips = this.controller.animationClips.ToList();
    }
    public virtual AnimationClip GetAniClip(string name)
    {
        foreach (AnimationClip clip in aniClips)
        {
            if (clip.name != name) continue;
            return clip;
        }
        return null;
    }        
    public virtual void PlayAniAttack()
    {
        this.animator.SetBool("attack", true);
        this.animator.SetBool("walk", false);
    }
    public virtual void PlayAniWalk()
    {
        this.animator.SetBool("attack", false);
        this.animator.SetBool("walk", true);
    }

    public virtual void PlayAniDead()
    {
        this.animator.SetTrigger("Dead");
    }
}
