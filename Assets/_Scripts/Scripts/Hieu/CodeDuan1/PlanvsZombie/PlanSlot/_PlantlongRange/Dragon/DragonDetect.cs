using UnityEngine;

public class DragonDetect : PlantlongRangeDetect
{
    public LayerMask LayerMask;        
    protected virtual void Update()
    {
        this.IdlePlant();
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, range, LayerMask);       
        if (hit.collider == null) return;
        if (hit.collider.GetComponent<AttackZond>() != null)
        {
            Color rayColor = (hit.collider != null) ? Color.red : Color.green;
            Debug.DrawRay(transform.position, Vector2.right * range, rayColor);
            return;
        }
        Debug.DrawRay(transform.position, Vector2.right * range, Color.green);
        this.directionEnemy = hit.transform.position;
        this.DeffaultAttack();
    }
}
