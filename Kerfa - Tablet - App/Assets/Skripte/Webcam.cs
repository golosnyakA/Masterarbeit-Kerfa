using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class Webcam : QRCode
{

    WebCamTexture tex;
    public RawImage display;

    int currentCamIndex = 0;
    public void SwapCam_Clicked()
    {
        //check Webcam an
        if(WebCamTexture.devices.Length <0)
        {
            currentCamIndex += 1;
            currentCamIndex %= WebCamTexture.devices.Length;
        }
    }
    
    public void StartStopCam_Clicked()
    {
        if( tex != null)
        {
            Debug.Log("hier");
            display.texture = null;
            tex.Stop();
            tex = null;

        }
        else
        {
            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;
            float antiRotation = 360 - tex.videoRotationAngle;
            Quaternion quatRot = new Quaternion();
            quatRot.eulerAngles = new Vector3(0, 0, antiRotation);
            display.transform.rotation = quatRot;
            tex.Play();

            StartCoroutine(GetQRCode(tex));
        }
    }
}
