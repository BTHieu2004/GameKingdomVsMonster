using UnityEngine;

public class Tile : HieuMonoBehaviour
{
    [SerializeField] protected bool hasPlant;
    public bool HasPlant => hasPlant;
    public bool IsPlant(bool isPlant)
    {
        return hasPlant = isPlant;
    }
}
