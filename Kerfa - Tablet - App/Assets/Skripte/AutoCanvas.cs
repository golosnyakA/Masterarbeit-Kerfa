using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using TMPro;

public class AutoCanvas : MonoBehaviour
{
    //https://www.youtube.com/watch?v=CGsEJToeXmA
    public GameObject Kachel_button;
    public GameObject parent;
    private string path = "C:/Users/alexa/OneDrive/Dokumente/Kerfa";

    public void Start()
    {
        CreateButtons(path);
        
    }
    public void CreateButtons(string path)
    {
        try
        {
            System.IO.DirectoryInfo ParentDirectory = new System.IO.DirectoryInfo(path);

            foreach (System.IO.DirectoryInfo ordner in ParentDirectory.EnumerateDirectories())
            {
                Instantiate(Kachel_button,parent.transform);
                Kachel_button.GetComponentInChildren<TextMeshProUGUI>().text = ordner.Name;
                Kachel_button.name = ordner.Name;     
            }
        }
        catch (Exception e)
        {
            Debug.Log("Fehler in Ordnerstruktur" + e.ToString());
        }
        
    }
}

