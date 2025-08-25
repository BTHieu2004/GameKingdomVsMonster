using TMPro;
using UnityEngine;

public abstract class TextContentAbstract : HieuMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textContent;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextContent();
    }
    protected virtual void LoadTextContent()
    {
        if (this.textContent != null) return;
        this.textContent = GetComponent<TextMeshProUGUI>();
    }
    protected abstract void TextContent();
}
