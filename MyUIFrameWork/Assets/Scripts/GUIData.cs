﻿using UnityEngine;
using System.Collections;

/// <summary>
/// 界面基本数据
/// </summary>
public class GUIData
{
    //界面的编号
    public GUIDef.GUIID id;

    //界面类型
    public UIWindowType showType;

    //界面显示方式
    public UIWindowShowMode showMode;

    //界面背景模式
    public UIWindowColliderMode colliderMode;
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

public enum UIWindowColliderMode
{
    None,      // 显示该界面不包含碰撞背景
    Normal,    // 碰撞透明背景
    WithBg,    // 碰撞非透明背景
}
