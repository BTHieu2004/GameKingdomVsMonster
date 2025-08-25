using TMPro;
using UnityEngine;

public class TextMonies : TextContentAbstract
{        
    protected virtual void LateUpdate()
    {
        this.TextContent();
    }
    protected override void TextContent()
    {
        this.textContent.text = "Monies : " + PlayerManager.Instance.PlayerSO.money.ToString();
    }
}
