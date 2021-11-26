using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotHandler : MonoBehaviour
{
    private Camera myCamera;
    private static ScreenshotHandler instance;
    private bool takesScreenshotOnNextFrame;
    public GameObject buttons;
    public string auftragsnummer;
    public string fotopath;
    public int Anzahl;
    public AuftragsnummerChecken auftragsnummerChecken;

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

            System.IO.DirectoryInfo ParentDirectory = new System.IO.DirectoryInfo(fotopath);
            System.IO.File.WriteAllBytes(fotopath+ "/"+ auftragsnummer +"_"+Anzahl +".png", byteArray);
            Debug.Log("Saved CameraScreenshot");
            Anzahl = 0;

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;

            buttons.SetActive(true);

            auftragsnummerChecken.Meldung_positiv("Foto aufgenommen");
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
        CountPictures();
        buttons.SetActive(false);
        TakeScreenshot_Static(1024, 768);
    }

    public void CountPictures()
    {
        DirectoryInfo ParentDirectory = new DirectoryInfo(fotopath);
        foreach (FileInfo file in ParentDirectory.EnumerateFiles())
        {
            if (file.Name.Substring(file.Name.Length - 4) == ".png")
            {
                Anzahl++;
            }
            else
            {
                Anzahl = 0;
            }
        }
    }
}
