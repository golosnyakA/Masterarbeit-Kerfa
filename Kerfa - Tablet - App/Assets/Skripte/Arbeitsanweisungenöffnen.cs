using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Arbeitsanweisungenöffnen : MonoBehaviour
{
    string path;
    string directory;
    string auftrag;

    public void OpenFileExplorer()
    {
        //hier try catch
        //auftrag = inputfield.text;
        directory = "C:\\Users\\alexa\\OneDrive\\Dokumente\\Alexander";
        //directory = string.Format("X:\\Vertrieb\\Aufträge\\{0}\\9.0_Fotos",auftrag); 
        path = EditorUtility.OpenFilePanel("Fotos speichern",directory, "");
        Debug.LogWarning("Hier ändern");
    }

    public void ShowFile(string itemPath)
    {
        //itemPath = itemPath.Replace(@"/", @"\");   // explorer doesn't like front slashes
        System.Diagnostics.Process.Start("explorer.exe", "C:\\Users\\alexa\\OneDrive\\Dokumente\\Alexander\\1.docx");   
    }

    public void OpenAA(FileInfo file)
    {
        Debug.Log(file.DirectoryName+ "/" + file.Name);
        System.Diagnostics.Process.Start(file.DirectoryName + "/" + file.Name);
            
    }
}
