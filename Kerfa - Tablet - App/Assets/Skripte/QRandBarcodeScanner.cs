using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class QRandBarcodeScanner : MonoBehaviour
{
    public GameObject popUp;
    public GameObject parent;
    public GameObject logo;
    public Canvas CanvasQR;

    [SerializeField]
    public RawImage rawImage;

    WebCamTexture webcamTexture;
    Result Result;

    [SerializeField]
    public string QrCode = string.Empty;


    private Texture2D snap;
    public void StartQR()
    {
        QrCode = string.Empty;
        RawImage renderer = rawImage;
        webcamTexture = new WebCamTexture(512, 512);

        renderer.material.mainTexture = webcamTexture;
        StartCoroutine(GetQRCode());
    }

    IEnumerator GetQRCode()
    {
        var barCodeReader = new BarcodeReaderGeneric();
        webcamTexture.Play();
        snap = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.ARGB32, false);
        while (string.IsNullOrEmpty(QrCode))
        {
            try
            {
                snap.SetPixels32(webcamTexture.GetPixels32());
                Result = barCodeReader.Decode(snap.GetRawTextureData(), webcamTexture.width, webcamTexture.height, RGBLuminanceSource.BitmapFormat.ARGB32);
                Debug.Log(Result.Text);
                if (Result != null)
                {
                    //hier ist der string im qr gespeichert qrcode

                    QrCode = Result.Text;

                    if (!string.IsNullOrEmpty(QrCode))
                    {
                        Debug.Log("DECODED TEXT FROM QR: " + QrCode);
                        OpenPopUP();

                        webcamTexture.Stop();

                        break;
                    }
                }
            }
            catch (Exception ex) { Debug.LogWarning(ex.Message); }
            yield return null;
        }
        webcamTexture.Stop();
    }

    public void OpenFile(string AnlagenNummer)
    {
        Debug.Log(AnlagenNummer);
        System.Diagnostics.Process.Start("explorer.exe", "C:\\Users\\alexa\\OneDrive\\Dokumente\\Alexander\\1.docx");
        //System.Diagnostics.Process.Start(string.Format("explorer.exe", "X:\\Maschinen und Anlagen\\{0}\\",AnlagenNummer));
    }

    public void StopWebcam()
    {
        if (webcamTexture != null)
        {
            StopCoroutine(GetQRCode());
            webcamTexture.Stop();
        }
    }

    private void OpenPopUP()
    {
        logo.SetActive(false);
        GameObject PopUp = Instantiate(popUp,parent.transform);
        popUp.transform.localPosition = new Vector3(0, 0, 0);
        PopUp.GetComponentInChildren<TextMeshProUGUI>().text = "Der QR-Code entspricht:\n " + QrCode;
    }
    public void CloseCanvas()
    {   
        GameObject PopUp = GameObject.Find("Pop-Up(Clone)");
        if(PopUp != null)
        {
            Destroy(PopUp);
        }

        parent.SetActive(false);
        StopWebcam();
        gameObject.SetActive(false);
    }

    public void DebugQR()
    {
        QrCode = "debugCode";
        Result = null;
        OpenPopUP();
    }
}

