using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Sun",menuName = "SO/Sun")]
public class SunSO : ScriptableObject
{
    public string nameSun;           
    public float speedDrop;
    public float timeLife;
    public int quantitySun;
    public RandomPosDop randomPosDop;
    public RandomToDopY randomToDopY;
    public LayerMask layer;
    public GameObject objSun;
}
[Serializable]
public class RandomPosDop
{
    public float posX_A;
    public float posX_B;
    public float posY;
}
[Serializable]
public class RandomToDopY
{
    public float posA;
    public float posB;
}