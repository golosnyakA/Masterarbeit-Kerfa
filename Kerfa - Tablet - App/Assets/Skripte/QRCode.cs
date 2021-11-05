using UnityEngine;

public class QRCode
{
   private string qrCode;
   public string QrCode
   {
        get {
            Debug.Log("der qrcode entspricht: "+ qrCode);
            return qrCode; }   // get method
        set { qrCode = value;
            Debug.Log("der qrcode entspricht: " + qrCode);
              }  // set method*/

    }
}
