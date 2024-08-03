using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonBtnScripts : MonoBehaviour
{
    public void exitApp() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
