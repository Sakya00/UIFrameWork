using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour
{
    [System.NonSerialized]
    public GameObject guiManagerObj;
    public static GUIManager guiManager;

    void Awake()
    {
        guiManagerObj = new GameObject("GuiManager");
        guiManager = guiManagerObj.AddComponent<GUIManager>();
        guiManager.SetContorlObject(this);
    }
}
