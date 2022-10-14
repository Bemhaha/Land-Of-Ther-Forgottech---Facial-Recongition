using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamScript : MonoBehaviour
{
    int currentCamIndex = 0;

    WebCamTexture tex;

    public RawImage display;

    public Text startStopText;

    public void SwitchCam_Clicked()
    {
        if(WebCamTexture.devices.Length > 0)
        {
            currentCamIndex += 1;
            currentCamIndex %= WebCamTexture.devices.Length;

        }
    }

    public void StartStopCam_Clicked()
    {
        if(tex != null) //Detener cámara web
        {
            display.texture = null;
            tex.Stop();
            tex = null;
            startStopText.text = "Start Camera";
        }
        else //Iniciar cámara web
        {

            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;

            tex.Play();
            startStopText.text = "Stop Camera";

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
