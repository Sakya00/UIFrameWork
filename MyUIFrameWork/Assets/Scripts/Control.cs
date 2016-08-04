using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour
{
    public GameObject guiManagerObj;
    public static GUIManager guiManager;

    void Awake()
    {
        guiManagerObj = new GameObject("GuiManager");
        guiManager = guiManagerObj.AddComponent<GUIManager>();
    }
}
