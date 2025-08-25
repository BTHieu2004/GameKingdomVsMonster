using UnityEngine;

public class Slime : EnemyAbstract
{
    [SerializeField] protected Animator animator;
    public Animator Animator => animator;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAnimator();
    }
    protected virtual void LoadAnimator()
    {
        if (this.animator != null) return;
        this.animator = GetComponentInChildren<Animator>();
    }
    public override string NameObj()
    {
        return "Slime";
    }
}
