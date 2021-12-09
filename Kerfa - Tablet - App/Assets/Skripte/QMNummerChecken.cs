using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class QMNummerChecken : MonoBehaviour
{
    private string QMAK;
    private string path;
    // Start is called before the first frame update
    public void ParseQMAK(string qmak)
    {
        QMAK = qmak;
        CheckQMAK(QMAK);
    }

    // Update is called once per frame
    void CheckQMAK(string qmak)
    {
        string rootfolder = "C:/Users/alexa/OneDrive/Dokumente/Kerfa/Allgemein";
        DirectoryInfo imageDir = new DirectoryInfo(rootfolder);
        Debug.Log(imageDir);
        FileInfo[] arrFilenames = imageDir.GetFiles(qmak ,SearchOption.AllDirectories);

        Debug.Log(arrFilenames[0]);

        /*
            //Einfache verwendung von System.IO.Directory.Exists(string path)
            //Path mit Path.Combine(string path1, string path2) bilden:

            string fullPath = Path.Combine(rootFolder, qmak);
            return Directory.Exists(fullPath);
        */
    }








        /*
        //BEISPIEL QMAK-PR-7.5-031_Serviceeinsätze_Rev0.docx
        if (qmak.Length == 8)
        {
            //gucken, ob der Ordner mit Auftragsnummer existiert
            path = "C:/Users/alexa/OneDrive/Dokumente/Kerfa/Auftragsordner";
            System.IO.DirectoryInfo ParentDirectory = new System.IO.DirectoryInfo(path);

            foreach (System.IO.DirectoryInfo ordner in ParentDirectory.EnumerateDirectories())
            {
                if (ordner.Name == auftragsnummer)
                {
                    textfield.enabled = false;
                    buttonBestätigen.SetActive(false);
                    ButtonFoto.SetActive(true);
                    Meldung_positiv("In Auftrag " + auftragsnummer + " einloggen");

                    screenshotHandler.fotopath = "C:/Users/alexa/OneDrive/Dokumente/Kerfa/Auftragsordner/" + auftragsnummer + "/9.0_Fotos";
                    screenshotHandler.auftragsnummer = auftragsnummer;
                }
                else
                {
                    Meldung_negativ("Ordner " + auftragsnummer + " existiert nicht");
                }
            }

        }*/
}
