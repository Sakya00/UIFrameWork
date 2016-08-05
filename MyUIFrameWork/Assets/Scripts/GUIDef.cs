using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//界面类型定义 GUI_加上类名
public class GUIDef
{
    public const int GUI_MainMenuGUI = 0;

    public enum GUIID
    {
        GUI_MainMenuGUI = 0,        //主界面ID
    }

    /// <summary>
    /// GUIID对应的Prefab路径
    /// </summary>
    public static Dictionary<GUIID, string> guiPrefabPath = new Dictionary<GUIID, string>()
    {
        { GUIID.GUI_MainMenuGUI,"MainMenuGUI"}
    };

    public static string UIPrefabString = "UIPrefab/";
}

public enum UIWindowType
{
    Normal,    // 可推出界面(UIMainMenu,UIRank等)
    Fixed,     // 固定窗口(UITopBar等)
    PopUp,     // 模式窗口
}

public enum UIWindowShowMode
{
    DoNothing,
    HideOther,     // 闭其他界面
    NeedBack,      // 点击返回按钮关闭当前,不关闭其他界面(需要调整好层级关系)
    NoNeedBack,    // 关闭TopBar,关闭其他界面,不加入backSequence队列
}
