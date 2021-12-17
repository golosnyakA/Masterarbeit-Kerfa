using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class QMNummerChecken : MonoBehaviour
{
    private string QMAK;
    private string path;
    public GameObject FileManager;
   
    public void ParseQMAK(string qmak)
    { 
        QMAK = qmak;
        try
        {
            FileInfo file = CheckQMAK(QMAK);
            Arbeitsanweisungenöffnen AA = FileManager.GetComponent<Arbeitsanweisungenöffnen>();
            AA.OpenAA(file);
        }
        catch
        {
            Debug.Log("Datei nicht vorhanden");
        }
        
    }

    FileInfo CheckQMAK(string qmak)
    {
        Debug.LogWarning("hier ändern");
        string rootfolder = "C:/Users/alexa/OneDrive/Dokumente/Kerfa/Allgemein";

        DirectoryInfo imageDir = new DirectoryInfo(rootfolder);
        if(qmak != "")
        {
            qmak = qmak + "*";
        }

        FileInfo[] arrFilenames = imageDir.GetFiles(qmak ,SearchOption.AllDirectories);

        Debug.Log(arrFilenames[0].Name);

        return arrFilenames[0];
    }
}
