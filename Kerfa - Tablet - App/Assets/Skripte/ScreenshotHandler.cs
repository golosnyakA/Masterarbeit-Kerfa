using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenshotHandler : MonoBehaviour
{
    private Camera myCamera;
    private static ScreenshotHandler instance;
    private bool takesScreenshotOnNextFrame;
    private void Awake()
    {
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();
    }

    private void OnPostRender()
    {
        if (takesScreenshotOnNextFrame) 
        { 
            takesScreenshotOnNextFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;
            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/CameraScreenshots.png", byteArray);
            Debug.Log("Saved CameraScreenshot");

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;


        }
    }
    public void TakeScreenshot(int width, int height)
    {
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takesScreenshotOnNextFrame = true;
    }

    public void TakeScreenshot_Static(int width, int height)
    {
        instance.TakeScreenshot(width, height);

    }

    public void OnButtonPressed()
    {
        TakeScreenshot_Static(700, 500);
    }
}
