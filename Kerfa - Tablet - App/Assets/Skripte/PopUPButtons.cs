using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUPButtons : MonoBehaviour
{
    QRandBarcodeScanner qrScanner;
    // Start is called before the first frame update
    public void Bestaetigen()
    {
        Debug.Log(qrScanner.QrCode);
        qrScanner.OpenFile(qrScanner.QrCode);
    }

    // Update is called once per frame
    public void Wiederholen()
    {
        qrScanner.StopWebcam();
        qrScanner.StartQR();
       // gameObject.transform.Destroy();
  

    }
}
