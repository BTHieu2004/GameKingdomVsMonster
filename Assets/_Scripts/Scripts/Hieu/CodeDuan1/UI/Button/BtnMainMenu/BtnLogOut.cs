using UnityEngine;

public class BtnLogOut : BtnMenuAbstract
{
    protected override void OnClick()
    {
        this.LogOut();
    }
    protected virtual void LogOut()
    {
        GameManager.Instance.LoadScene(NameScene.SceneLogin);
    }
}
