using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class AuftragsnummerChecken : MonoBehaviour
{
    public ScreenshotHandler screenshotHandler;
    private string path= "";
    public string auftragsnummer = "";
    public TMP_InputField textfield;
    public GameObject buttonBestätigen;
    public GameObject ButtonFoto;

    public GameObject Meldung_erfolgreich;
    public GameObject Meldung_nicht_erfolgreich;


    public void ExistiertAuftrags()
    {
        auftragsnummer = textfield.text;
        if(auftragsnummer == textfield.text)
        {
         ParseAuftragsnummer(auftragsnummer);
        }
        else
        {
            Debug.Log("zu langsam");
        }
                
              
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
                    textfield.enabled = false;
                    buttonBestätigen.SetActive(false);
                    ButtonFoto.SetActive(true);
                    Meldung_positiv("In Auftrag "+ auftragsnummer+ " einloggen");

                    screenshotHandler.fotopath = "C:/Users/alexa/OneDrive/Dokumente/Kerfa/Auftragsordner/" + auftragsnummer + "/9.0_Fotos";
                    screenshotHandler.auftragsnummer = auftragsnummer;
                }
                else
                {
                    Meldung_negativ("Ordner " + auftragsnummer + " existiert nicht");
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

    public void Meldung_positiv(string meldung)
    {
        Meldung_erfolgreich.SetActive(true);
        Meldung_erfolgreich.GetComponentInChildren<TextMeshProUGUI>().text = meldung;
        Meldung_erfolgreich.GetComponent<DeleteIn3Sec>().popUP();
    }

    public void Meldung_negativ(string meldung)
    {
        Meldung_nicht_erfolgreich.SetActive(true);
        Meldung_nicht_erfolgreich.GetComponentInChildren<TextMeshProUGUI>().text = meldung;
        Meldung_nicht_erfolgreich.GetComponent<DeleteIn3Sec>().popUP();
    }
}
