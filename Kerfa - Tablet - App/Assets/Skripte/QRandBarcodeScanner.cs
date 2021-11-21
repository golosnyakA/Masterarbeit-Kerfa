using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ZXing;

public class QRandBarcodeScanner : MonoBehaviour
{
    private bool qrSaved = false;

    public GameObject popUp;
    public GameObject parent;
    public GameObject logo;
    public GameObject hintergrund;
    public GameObject panel;
    public Canvas CanvasQR;
    public Button QRwiederholen;

    [SerializeField]
    public RawImage rawImage;

    WebCamTexture webcamTexture;
    TempCode temp = new TempCode();

    [SerializeField]
    public string QrCode = string.Empty;

    private Texture2D snap;
    public void StartQR()
    {
        QrCode = string.Empty;
        RawImage renderer = rawImage;
        rawImage.gameObject.SetActive(true);
        webcamTexture = new WebCamTexture(512, 512);

        if(qrSaved == false)
        {
            QRwiederholen.interactable = false;
        }
        else
        {
            QRwiederholen.interactable = true;
        }

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
        rawImage.gameObject.SetActive(false);
        hintergrund.SetActive(false);
        temp.TempQRcode = QrCode;
        qrSaved = true;
        logo.SetActive(false);
        GameObject PopUp = Instantiate(popUp,parent.transform);
        QRwiederholen.interactable = false;
        popUp.transform.localPosition = new Vector3(0, 0, 0);
        PopUp.GetComponentInChildren<TextMeshProUGUI>().text = "Der QR-Code entspricht:\n " + QrCode;
    }
    public void CloseCanvas()
    {
        logo.SetActive(true);
        GameObject PopUp = GameObject.Find("Pop-Up(Clone)");
        if(PopUp != null)
        {
            Destroy(PopUp);
            
        }
        panel.SetActive(true);
        rawImage.gameObject.SetActive(false);
        hintergrund.SetActive(true);
        parent.SetActive(false);
        StopWebcam();
        gameObject.SetActive(false);
    }

    public void DebugQR()
    {
        QrCode = "debugCode";
        OpenPopUP();
    }

    class TempCode
    {
        private string tempQRcode;

        public string TempQRcode
        {
            get { return tempQRcode; }
            set { tempQRcode = value; }
        }
    }

    public void GetQRcode()
    {
        QrCode = temp.TempQRcode;
        OpenPopUP();
    }

    private void ChangeMaterial()
    {
        MaterialKerfa canvasMaterial = GameObject.Find("Material").GetComponent<MaterialKerfa>();
        rawImage.material = null;
        rawImage.material = canvasMaterial.uiDefault;
    }
}

