using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour
{
    [System.NonSerialized]
    public Transform canvas;        //Canvas节点
    private Texture bgTexture;
    private float canvanWidth;
    private float canvasHeight;

    private Control control;
    private List<UIBaseWindow> allWindows = new List<UIBaseWindow>();

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
        UIBaseWindow window = GetWindow(id);

    }

    /// <summary>
    /// 获取界面
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private UIBaseWindow GetWindow(GUIDef.GUIID id)
    {
        for (int i = 0; i < allWindows.Count; i++)
        {
            if (allWindows[i].GetGUiData().id == id)
            {
                return null;
            }
        }

        UIBaseWindow window = null;
        //界面未打开则resource加载prefab
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
                window = uiObj.GetComponent<UIBaseWindow>();
                allWindows.Add(window);
            }
        }

        //TODO:调整界面层级

        //TODO:根据界面类型，添加背景遮挡
        AddColliderBg(window);

        return window;
    }

    /// <summary>
    /// 为界面添加背景遮挡
    /// </summary>
    /// <param name="window"></param>
    private void AddColliderBg(UIBaseWindow window)
    {
        GUIData gdata = window.GetGUiData();

        if (gdata != null)
        {
            if (gdata.colliderMode == UIWindowColliderMode.None)
            {
                //不添加背景
                return;
            }
            else if (gdata.colliderMode == UIWindowColliderMode.Normal)
            {
                //添加碰撞半透明背景
                AddColliderBgToTarget(window.gameObject, true);

            }
            else if (gdata.colliderMode == UIWindowColliderMode.WithBg)
            {
                //添加碰撞不透明背景,界面自己带背景图片,添加一层完全透明的图片遮挡事件即可
                AddColliderBgToTarget(window.gameObject, false);
            }
        }
    }

    private void AddColliderBgToTarget(GameObject target, bool isTransParent)
    {
        Transform bgNode = Utility.FindDeepChild(target, "WindowBg");
        if (bgNode == null)
        {
            bgNode = new GameObject("WindowBg").transform;
            Utility.AddChildToTarget(target.transform, bgNode);
            bgNode.SetAsFirstSibling();
        }

        //添加背景图
        RawImage bgImage = bgNode.gameObject.AddComponent<RawImage>();
        bgImage.texture = bgTexture;
        RectTransform rt = bgImage.rectTransform;
        rt.sizeDelta = new Vector2(canvanWidth, canvasHeight);
        if (!isTransParent)
        {
            Color col = bgImage.color;
            bgImage.color = new Color(col.r, col.g, col.b, 0f);
        }
    }

    /// <summary>
    /// 关闭界面
    /// </summary>
    /// <param name="id"></param>
    public void Close(GUIDef.GUIID id)
    {
        for (int i = allWindows.Count - 1; i >= 0; i--)
        {
            UIBaseWindow window = allWindows[i];
            Debug.Log("关闭的界面ID： " + id);
            if (window.GetGUiData().id == id)
            {
                //关闭此ID的界面
                allWindows.Remove(window);
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

            //获取Canvas高宽
            canvanWidth = ((RectTransform)canvas).rect.width;
            canvasHeight = ((RectTransform)canvas).rect.height;
        }

        //加载背景图
        bgTexture = Resources.Load("UITexture/bgMask") as Texture;

    }
}
