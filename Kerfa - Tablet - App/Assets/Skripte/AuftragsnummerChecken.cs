using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AuftragsnummerChecken : MonoBehaviour
{
    public ScreenshotHandler screenshotHandler;
    private string path;
    public string auftragsnummer;
    public TMP_InputField textfield;
    public GameObject buttonBestätigen;
    public GameObject ButtonFoto;

    public void ExistiertAuftrags()
    {
        auftragsnummer = textfield.text;
        ParseAuftragsnummer(auftragsnummer);
    }
    public void ParseAuftragsnummer(string auftragsnummer)
    {
        
        //Anzahl von von Buchstaben/Zahlen kontrollieren
        if (auftragsnummer.Length == 5)
        {
            //gucken, ob der Ordner mit Auftragsnummer existiert
            path = "C:/Users/alexa/OneDrive/Dokumente/Kerfa/Auftragsordner";
            System.IO.DirectoryInfo ParentDirectory = new System.IO.DirectoryInfo(path);

            foreach (System.IO.DirectoryInfo ordner in ParentDirectory.EnumerateDirectories())
            {
                if (ordner.Name == auftragsnummer)
                {
                    Debug.Log("Ordner " + auftragsnummer + " existiert");
                    textfield.enabled = false;
                    buttonBestätigen.SetActive(false);
                    ButtonFoto.SetActive(true);

                    screenshotHandler.fotopath = "C:/Users/alexa/OneDrive/Dokumente/Kerfa/Auftragsordner/" + auftragsnummer + "/9.0_Fotos";
                    screenshotHandler.auftragsnummer = auftragsnummer;
                }
                else
                {
                    Debug.Log("Ordner " + auftragsnummer + " existiert nicht");
                }
            }

        }
        else if (auftragsnummer.Length < 5)
        {
            Debug.Log("Auftragsnummer zu kurz");
        }
        else
        {
            Debug.Log("Auftragsnummer zu lang");
        }
    }

    public void OnValueChangeTextfield()
    {
        if(textfield.text.Length == 5 )
        {
            buttonBestätigen.SetActive(true);
        }
        else
        {
            buttonBestätigen.SetActive(false);
        }
    }
}
