using UnityEngine;
using System.Collections;

public class Utility : MonoBehaviour
{
    /// <summary>
    /// 添加子节点
    /// </summary>
    public static void AddChildToTarget(Transform target, Transform child)
    {
        //child.parent = target;
        //child.localScale = Vector3.one;
        //child.localPosition = Vector3.zero;
        //child.localEulerAngles = Vector3.zero;
        child.SetParent(target,false);

        ChangeChildLayer(child, target.gameObject.layer);
    }

    /// <summary>
    /// 修改子节点Layer  NGUITools.SetLayer();
    /// </summary>
    public static void ChangeChildLayer(Transform t, int layer)
    {
        t.gameObject.layer = layer;
        for (int i = 0; i < t.childCount; ++i)
        {
            Transform child = t.GetChild(i);
            child.gameObject.layer = layer;
            ChangeChildLayer(child, layer);
        }
    }

    /// <summary>
    /// 查找子节点
    /// </summary>
    public static Transform FindDeepChild(GameObject _target, string _childName)
    {
        Transform resultTrs = null;
        resultTrs = _target.transform.Find(_childName);
        if (resultTrs == null)
        {
            foreach (Transform trs in _target.transform)
            {
                resultTrs = Utility.FindDeepChild(trs.gameObject, _childName);
                if (resultTrs != null)
                    return resultTrs;
            }
        }
        return resultTrs;
    }
}
