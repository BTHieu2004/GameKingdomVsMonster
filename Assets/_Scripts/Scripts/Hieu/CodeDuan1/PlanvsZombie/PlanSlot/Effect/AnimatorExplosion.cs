using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimatorExplosion : HieuMonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected List<AnimationClip> aniClips = new();
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
        if (this.aniClips.Count > 0) return;
        this.aniClips = this.animator.runtimeAnimatorController.animationClips.ToList();
    }
    public virtual AnimationClip GetAniCLipByName(string name)
    {
        foreach(AnimationClip child in this.aniClips)
        {
            if (child.name != name) continue;
            return child;
        }
        return null;
    }
}
