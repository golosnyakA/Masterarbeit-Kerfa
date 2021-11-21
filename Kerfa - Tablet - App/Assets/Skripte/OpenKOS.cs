using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenKOS : MonoBehaviour
{
    public string file;
    public string path;
    public void OpenFile(string file, string path)
    {
        System.Diagnostics.Process.Start(file, path);
    }

    public void OpenKos()
    {
        //hier statt explorer exe die KOS.exe mit filepath
        file = "Kerfa Office Suit.exe";
        path = "C:\\Users\\alexa\\OneDrive\\Dokumente\\Alexander\\1.docx";
        
        OpenFile(file, path);
    }

    public void OpenEssentials()
    {
        file = "Kerfa Essential.exe";
        path = "C:\\Users\\alexa\\OneDrive\\Dokumente\\Alexander\\1.docx";

        OpenFile(file, path);
    }
}
