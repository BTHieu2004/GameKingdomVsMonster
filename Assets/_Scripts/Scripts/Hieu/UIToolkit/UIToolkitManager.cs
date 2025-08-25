using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIToolkitManager : HieuMonoBehaviour
{
    //public VisualElement root;
    //public VisualElement loginHolder;
    //public TextField textName;
    //public TextField textEmail;
    //public TextField textPassword;
    //public Button btnLogin;
    //public Label message;
    //public VisualElement achivement;
    //public VisualElement content;
    //public Button btnAchi;
    //public Label textAchi;
    //[SerializeField] protected List<AchivementCtrl> achivementCtrls;
    //[SerializeField] protected List<InfoAchivementSO> infoAchi;    
    //protected override void OnEnable()
    //{
    //    base.OnEnable();
    //    root = GetComponent<UIDocument>().rootVisualElement;
    //    this.loginHolder = root.Q<VisualElement>("LoginHolder");

    //    #region LoginHoder
    //    this.textName = this.loginHolder.Q<TextField>("TextName");
    //    this.textEmail = this.loginHolder.Q<TextField>("TextEmail");
    //    this.textPassword = this.loginHolder.Q<TextField>("TextPassword");
    //    this.btnLogin = this.loginHolder.Q<Button>("BtnLogin");
    //    this.message = this.loginHolder.Q<Label>("Message");        
    //    // ClickEvent                
    //    this.btnLogin.RegisterCallback<ClickEvent>(ClickEventLogin);
    //    #endregion

    //    #region Achivement                
    //    //this.achivementCtrls = AchivementManager.Instance.AchivementCtrls;
    //    //foreach (AchivementCtrl achivementCtrl in this.achivementCtrls)
    //    //{
    //    //    this.infoAchi.AddRange(achivementCtrl.AchivementSO);
    //    //}
    //    this.achivement = root.Q<VisualElement>("Achivement");
    //    this.content = achivement.Q<VisualElement>("unity-content-container");
    //    for (int i = 0; i < 30; i++)
    //    {
    //        btnAchi = new Button();
    //        //this.textAchi = new Label();
    //        //textAchi.AddToClassList("textAchi");
    //        //textAchi.text = infoAchi[i].requiedCountCurrent.ToString()+"/"+ infoAchi[i].requiedCountMax.ToString();
    //        //btnAchi.text = infoAchi[i].description;
    //        this.btnAchi.AddToClassList("btnAchi");
    //        //this.btnAchi.Add(textAchi);
    //        this.content.Add(btnAchi);
    //    }
    //    #endregion
    //}
    //protected virtual void ClickEventLogin(ClickEvent clickEvent)
    //{        
    //    LoginManager.Instance.RegisterUser.Register(textName.text,textEmail.text,textPassword.text);
    //    //this.message.text = LoginManager.Instance.RegisterUser.ResultMessage();
    //    StartCoroutine(cd());
    //}
    //protected IEnumerator cd()
    //{        
    //    yield return new WaitForSeconds(1);
    //    LoginManager.Instance.RegisterUser.ResultMessage(this.message);
    //}
}
