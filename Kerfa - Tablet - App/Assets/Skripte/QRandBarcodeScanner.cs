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

    [SerializeField]
    public RawImage rawImage;

    WebCamTexture webcamTexture;
    string QrCode = string.Empty;

    private Texture2D snap;
    void Start()
    {
        Debug.Log("hier");

        QrCode = string.Empty;
        var renderer = rawImage;
        webcamTexture = new WebCamTexture(512, 512);
        Debug.Log("hier");

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
                var Result = barCodeReader.Decode(snap.GetRawTextureData(), webcamTexture.width, webcamTexture.height, RGBLuminanceSource.BitmapFormat.ARGB32);
                if (Result != null)
                {
                    //hier ist der string im qr gespeichert qrcode

                    QrCode = Result.Text;
                    
                    if (!string.IsNullOrEmpty(QrCode))
                    {
                        Debug.Log("DECODED TEXT FROM QR: " + QrCode);
                        //hier die Datei Öffnen und evtl. Pop Up UI öffnenmit QR-Inhalt und ja/ nein, ob nochmal scannen?
                        GameObject PopUp = Instantiate(popUp, parent.transform);
                        PopUp.GetComponentInChildren<TextMeshProUGUI>().text = "Der QR-Code entspricht:\n " + QrCode ;
                       
                        OpenFile(QrCode);
                        
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
        StopCoroutine(GetQRCode());
        webcamTexture.Stop();
        webcamTexture = null;
        
    }
}

