using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class QRCode:MonoBehaviour
{
    string QrCode;
    public AuftragsnummerChecken auftragsnummerChecken;
    public Webcam webcamManager;
    public bool stopQR = false;
    WebCamTexture webcamTexture;

    public IEnumerator GetQRCode(WebCamTexture webcamTexture)
    {
        var barCodeReader = new BarcodeReaderGeneric();
        webcamTexture.Play();
        Texture2D snap = new Texture2D(webcamTexture.width, webcamTexture.height, TextureFormat.ARGB32, false);
        while (string.IsNullOrEmpty(QrCode))
        {
            try
            {
                webcamTexture.Play();
                snap.SetPixels32(webcamTexture.GetPixels32());
                var Result = barCodeReader.Decode(snap.GetRawTextureData(), webcamTexture.width, webcamTexture.height, RGBLuminanceSource.BitmapFormat.ARGB32);
                if (Result != null)
                {
                    //hier ist der string im qr gespeichert qrcode
                    QrCode = Result.Text;

                    if (!string.IsNullOrEmpty(QrCode))
                    {
                        Debug.Log("DECODED TEXT FROM QR: " + QrCode);
                        Result result = new Result();
                        result.QR = QrCode;
                        //webcamTexture.Stop();
                        auftragsnummerChecken.textfield.text = QrCode;
                        auftragsnummerChecken.ParseAuftragsnummer(QrCode);

                        break;
                    }
                }
            }
            catch (Exception ex) { Debug.LogWarning(ex.Message); }
            yield return null;
        }
        
    }

    class Result
    {
        private string qr;

        public string QR
        {
            get { return qr; }
            set { qr = value; }
        }
    }

    public void StopWebcam()
    {
       //webcamTexture.Stop();
        if (webcamTexture != null)
        {
            StopCoroutine(GetQRCode(webcamTexture));
            webcamTexture.Stop();
            Webcam web = new Webcam();
            web.StartStopCam_Clicked();
        }
    }
}
