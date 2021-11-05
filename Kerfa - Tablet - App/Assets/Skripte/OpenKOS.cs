using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKOS : MonoBehaviour
{
    public void OpenKos()
    {
        //hier statt explorer exe die KOS.exe mit filepath
        System.Diagnostics.Process.Start("explorer.exe", "C:\\Users\\alexa\\OneDrive\\Dokumente\\Alexander\\1.docx");
    }
}
