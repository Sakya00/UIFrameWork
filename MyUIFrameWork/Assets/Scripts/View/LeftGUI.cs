using UnityEngine;
using System.Collections;
using System;

public class LeftGUI : UIBaseWindow
{
    private GUIData guidata;
    private GameObject closeBtn;

    public override void Init()
    {
        //为界面赋值ID
        guidata = new GUIData();
        guidata.id = GUIDef.GUIID.GUI_LeftGUI;
        guidata.showType = UIWindowType.Fixed;
        guidata.showMode = UIWindowShowMode.DoNothing;
        guidata.colliderMode = UIWindowColliderMode.None;

        closeBtn = transform.Find("Content/close_btn").gameObject;
        UIEventListener.Get(closeBtn).onClick = delegate { Control.guiManager.Close(this); };
    }

    public override void Open()
    {

    }

    public override void Action()
    {

    }

    public override void Close()
    {

    }

    public override GUIData GetGUiData()
    {
        return guidata;
    }
}
