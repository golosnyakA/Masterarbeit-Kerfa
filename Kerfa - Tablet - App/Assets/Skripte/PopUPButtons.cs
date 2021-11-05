using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUPButtons : MonoBehaviour
{
    QRandBarcodeScanner qrScanner;
    public GameObject parent;

    public void Start()
    {
        qrScanner = GameObject.Find("QR-Manager").GetComponent<QRandBarcodeScanner>();
        MaterialKerfa canvasMaterial = GameObject.Find("Material").GetComponent<MaterialKerfa>();
        qrScanner.rawImage.material = canvasMaterial.uiDefault;
    }
    public void Bestaetigen()
    {
        //hier Analge Ordner öffnen
        qrScanner = GameObject.Find("QR-Manager").GetComponent<QRandBarcodeScanner>();
        qrScanner.OpenFile(qrScanner.QrCode);
        qrScanner.CloseCanvas();
        Destroy(parent);
    }

    public void Wiederholen()
    {
        //erneuten Scan öffnen
        qrScanner = GameObject.Find("QR-Manager").GetComponent<QRandBarcodeScanner>();
        qrScanner.CloseCanvas();
        Manager qr = GameObject.Find("Manager").GetComponent<Manager>();
        qr.qrManager.SetActive(true);
        qrScanner.parent.SetActive(true);
        qrScanner.StartQR();
        Destroy(parent);
    }

    public void WartungDurchführen()
    {
        //Open files... Wartungsdoku und oder 

        qrScanner = GameObject.Find("QR-Manager").GetComponent<QRandBarcodeScanner>();
        qrScanner.logo.SetActive(true);
        qrScanner.CloseCanvas();
        Destroy(parent);
    }
}
