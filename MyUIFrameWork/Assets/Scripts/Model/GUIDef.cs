using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//界面类型定义 GUI_加上类名
public class GUIDef
{
    public enum GUIID
    {
        GUI_MainMenuGUI = 0,        //主界面ID
        GUI_LeftGUI,
        GUI_RightGUI,
    }

    /// <summary>
    /// GUIID对应的Prefab路径
    /// </summary>
    public static Dictionary<GUIID, string> guiPrefabPath = new Dictionary<GUIID, string>()
    {
        { GUIID.GUI_MainMenuGUI,"MainMenuGUI"},
        { GUIID.GUI_LeftGUI,"LeftGUI"},
        { GUIID.GUI_RightGUI,"RightGUI"}
    };

    public static string UIPrefabString = "UIPrefab/";
}
