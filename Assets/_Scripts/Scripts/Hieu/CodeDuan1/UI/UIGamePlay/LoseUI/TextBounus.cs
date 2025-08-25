using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class TextBounus : TextContentAbstract
{    
    protected override void OnEnable()
    {
        base.OnEnable();
        this.TextContent();
    }
    protected override void TextContent()
    {
        this.textContent.text = "Bounst : " + ProgressLevel.Instance.LevelSO.bonus;
    }
}
