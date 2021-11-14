using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AutoCanvas : MonoBehaviour
{
    public CSVParse cSV;
    public GameObject FensterPrefab;
    public GameObject ButtonPrefab;
    public GameObject parent;
    GameObject Fenster;

    [SerializeField]
    public string[,] grid;
    public int steps;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void FensterErstellen()
    {
        // Schaut sich die erste Zeile der csv an und erstellt die Anzahl von Fenstern, die dort angegeben sind
        steps = getInt(cSV.grid[0,0])+1;

        for (int i = 1; i < steps; i++)
        {
            Fenster = Instantiate(FensterPrefab, parent.transform);
            Fenster.name = i.ToString();
            Fenster.GetComponentInChildren<TextMeshProUGUI>().text = "Schritt " + i.ToString();
            if(Fenster.name == "1")
            {
                Fenster.SetActive(true);
            }
            else
            {
                Fenster.SetActive(false);
            }
        }
        FensterBearbeiten();
    }

    private int getInt(string grid)
    {
        string resultString = Regex.Match(grid, @"\d+").Value;
        return Int32.Parse(resultString);
    }

    public void FensterBearbeiten()
    {

        //for (int i = 1; i < steps+1; i++)
        //{
        steps = getInt(cSV.grid[0, 1]);
        Fenster = GameObject.Find(steps.ToString());
        Fenster.SetActive(true);
        try
        {
            string inhalt = cSV.grid[0, 2];
            string[] spalte = inhalt.Split(';');
            GameObject Text = GameObject.FindGameObjectWithTag("Überschrift");
            Text.GetComponentInChildren<Text>().text = spalte[1];
        }
        catch
        {
            Debug.Log("Fehler");
        }
        AktionZuordnen();
        //      }
    }

    void AktionZuordnen()
    {

        //läuft durch den Array
        foreach (string element in cSV.grid)
        {
            if (element != null)
            {
                string inhalt = element;
                string[] spalte = inhalt.Split(';');
                if (spalte[0] == "Option")
                {
                    GameObject ButtonParent = GameObject.FindGameObjectWithTag("Button");
                    Instantiate(ButtonPrefab, ButtonParent.transform);
                    ButtonPrefab.GetComponentInChildren<TextMeshProUGUI>().text = spalte[1];
                }

                if (spalte[0] == "Beschreibung")
                {

                }
            }
        }
    }
}
