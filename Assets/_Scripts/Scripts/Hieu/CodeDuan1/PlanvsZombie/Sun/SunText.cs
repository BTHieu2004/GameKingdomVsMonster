using TMPro;
using UnityEngine;

public class SunText : TextContentAbstract
{        
    protected virtual void Update()
    {
        this.TextContent();
    }
    protected override void TextContent()
    {
        this.textContent.text = ProgressLevel.Instance.QuantitySun.ToString();
    }
}
