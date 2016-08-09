using UnityEngine;
using System.Collections;

public abstract class UIBaseWindow : MonoBehaviour
{
    /// <summary>
    /// 初始化
    /// </summary>
    public abstract void Init();

    /// <summary>
    /// 打开界面
    /// </summary>
    public abstract void Open();

    /// <summary>
    /// 关闭界面，释放资源
    /// </summary>
    public abstract void Close();

    /// <summary>
    /// 界面更新
    /// </summary>
    public abstract void Action();

    public abstract GUIData GetGUiData();

    void Awake()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        Action();
    }
}
