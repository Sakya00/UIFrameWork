using UnityEngine;
using System.Collections;
using System;

public class MainGUI : UIBaseWindow
{
    private GUIData guidata;
    private GameObject closeBtn;

    public override void Init()
    {
        //为界面赋值ID
        guidata = new GUIData();
        guidata.id = GUIDef.GUIID.GUI_MainMenuGUI;
        guidata.showType = UIWindowType.Fixed;
        guidata.showMode = UIWindowShowMode.DoNothing;
        guidata.colliderMode = UIWindowColliderMode.Normal;

        closeBtn = transform.Find("close_btn").gameObject;
        UIEventListener.Get(closeBtn).onClick = delegate { Control.guiManager.Close(GUIDef.GUIID.GUI_MainMenuGUI); };
    }

    public override void Open()
    {

    }

    public override void Close()
    {

    }

    public override void Action()
    {

    }

    public override GUIData GetGUiData()
    {
        return guidata;
    }
}
