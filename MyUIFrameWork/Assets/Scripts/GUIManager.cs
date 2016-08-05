using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIManager : MonoBehaviour
{
    [System.NonSerialized]
    public Transform canvas;        //Canvas节点

    private Control control;
    private List<UIBaseWindow> commonWindows = new List<UIBaseWindow>();

    public void SetContorlObject(Control control)
    {
        this.control = control;
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
        Init();
    }

    void Update()
    {

    }

    /// <summary>
    /// 打开界面
    /// </summary>
    /// <param name="id">界面ID</param>
    public void OpenGUI(GUIDef.GUIID id)
    {
        UIBaseWindow baseWindow = null;
        //resource加载prefab
        if (GUIDef.guiPrefabPath.ContainsKey(id))
        {
            string prefabName = GUIDef.guiPrefabPath[id];
            string prefabPath = GUIDef.UIPrefabString + prefabName;

            GameObject prefab = Resources.Load(prefabPath) as GameObject;

            if (prefab != null)
            {
                GameObject uiObj = Instantiate(prefab);
                //将uiObj放到Canvas下
                Utility.AddChildToTarget(canvas, uiObj.transform);

                baseWindow = uiObj.GetComponent<UIBaseWindow>();
                commonWindows.Add(baseWindow);
            }
        }
    }

    /// <summary>
    /// 关闭界面
    /// </summary>
    /// <param name="id"></param>
    public void Close(GUIDef.GUIID id)
    {
        Debug.Log("关闭界面");
        for (int i = commonWindows.Count - 1; i >= 0; i--)
        {
            UIBaseWindow window = commonWindows[i];
            Debug.Log("关闭的界面ID： " + id);
            if (window.GetGUiData().id == id)
            {
                //关闭此ID的界面
                commonWindows.Remove(window);
                Destroy(window.gameObject);
                return;
            }
        }
    }

    private void Init()
    {
        GameObject canvasObj = GameObject.Find("Canvas");
        if (canvasObj != null)
        {
            canvas = canvasObj.transform;
        }
    }
}
