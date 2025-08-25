using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "sa",menuName = "SO/Achivement")]
public class InfoAchivementSO : ScriptableObject
{
    public EnumAchiverment enumAchiverment;
    public EnumTargetAcvm enumTargetAcvm;
    public int id;
    public int reward;
    public string description;
    public int requiedCountMax;
    public int requiedCountCurrent;
    public bool isComplete;
    public bool isClaimed;    
}
