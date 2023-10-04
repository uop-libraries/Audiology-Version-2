using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowedTestScript : MonoBehaviour
{
    public void WindowedMode()
    {
        Debug.Log("windowed");
        Screen.fullScreen = !Screen.fullScreen;
    }
}
