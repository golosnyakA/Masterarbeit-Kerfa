using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUPButtons : MonoBehaviour
{
    QRandBarcodeScanner qrScanner;
    public GameObject parent;


    //ch qr scan -> 2 buttons 

// Anlagendokumente einsehen(Ordner)

//artung durchführen(Anweisung/Dokumentation
    public void Bestaetigen()
    {
        qrScanner = GameObject.Find("QR-Manager").GetComponent<QRandBarcodeScanner>();
        Debug.Log(qrScanner.QrCode);
        qrScanner.OpenFile(qrScanner.QrCode);
        qrScanner.logo.SetActive(true);
        qrScanner.CloseCanvas();
        Destroy(parent);
    }

    // Update is called once per frame
    public void Wiederholen()
    {
        qrScanner = GameObject.Find("QR-Manager").GetComponent<QRandBarcodeScanner>();
        qrScanner.logo.SetActive(true);
        qrScanner.CloseCanvas();
        Manager qr = GameObject.Find("Manager").GetComponent<Manager>();
        qr.qrManager.SetActive(true);
        qrScanner.parent.SetActive(true);
        qrScanner.StartQR();
        Destroy(parent);
    }
}
