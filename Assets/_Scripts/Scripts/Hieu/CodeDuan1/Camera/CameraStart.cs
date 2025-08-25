using UnityEngine;

public class CameraStart : HieuMonoBehaviour
{
    [SerializeField] protected Vector2 cameraPosX;
    [SerializeField] protected float speed;

    protected virtual void Update()
    {
        transform.parent.position = Vector3.Lerp(transform.parent.position, this.cameraPosX ,speed*Time.deltaTime);
    }
}
