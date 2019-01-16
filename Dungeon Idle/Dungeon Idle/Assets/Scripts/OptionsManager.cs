using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public int width, height;
    public bool fullscreen;

    public void SetWidth(int newWidth) {
        width = newWidth;
    }

    public void SetHeight(int newHeight) {
        height = newHeight;
    }

    public void SetRes() {
        Screen.SetResolution(width, height, fullscreen);
    }
    
    public void SetFullscreen() {
        if (fullscreen == true)
            fullscreen = false;
        else if (fullscreen == false)
            fullscreen = true;
    }
    
}
