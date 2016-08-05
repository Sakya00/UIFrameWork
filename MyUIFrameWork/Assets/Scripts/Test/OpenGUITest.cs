using UnityEngine;
using System.Collections;

public class OpenGUITest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        UIEventListener.Get(gameObject).onClick = ((go) => { Control.guiManager.OpenGUI(GUIDef.GUIID.GUI_MainMenuGUI); });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
