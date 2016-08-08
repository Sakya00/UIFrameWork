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
