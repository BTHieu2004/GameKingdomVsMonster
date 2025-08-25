using UnityEngine;

[RequireComponent (typeof(CircleCollider2D))]
public class Tileable : HieuMonoBehaviour
{
    [SerializeField] protected CircleCollider2D circleCollider;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }
    protected virtual void LoadCollider()
    {
        if (this.circleCollider != null) return;
        this.circleCollider = GetComponent<CircleCollider2D>();
        this.circleCollider.isTrigger = true;
        this.circleCollider.radius = 0.3f;
    }
    protected virtual void OnTriggerEnter2D(Collider2D collider)
    {        
        if (collider.GetComponent<Tile>() == null) return;
        Tile tile = collider.GetComponent<Tile>();
        tile.IsPlant(true);
    }
    protected virtual void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.GetComponent<Tile>() == null) return;
        Tile tile = collider.GetComponent<Tile>();
        tile.IsPlant(false);
    }
}
