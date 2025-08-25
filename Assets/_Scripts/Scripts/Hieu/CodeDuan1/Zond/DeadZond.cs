using UnityEngine;

public class DeadZond : HieuMonoBehaviour
{
    protected virtual void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.GetComponent<EnemyAbstract>() == null) return;
        GameManager.Instance.PlayerLose();
        GameManager.Instance.onPlayerLose += Lose;
    }
    protected virtual void Lose()
    {
        Debug.Log("YouLose");
    }
}
