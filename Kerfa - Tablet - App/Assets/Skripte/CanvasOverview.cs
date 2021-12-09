using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasOverview : MonoBehaviour
{
    public GameObject Allgemein_Layout;
    public GameObject Produktion_Layout;
    public GameObject KaufmännischerBereich_Layout;
    public GameObject EDV_Layout;
    public GameObject Materialwesen_Layout;
    public GameObject Organisation_Layout;
    public GameObject Personal_Layout;
    public GameObject TBTechnischerBereich_Layout;
    public GameObject Vertrieb_Layout;
    public GameObject Qualitätsmanagment_Layout;

    public GameObject HLB;
    public GameObject ZUS;
    public GameObject WZB;
    public GameObject FOR;


    public void LayoutDeactivated()
    {
        GameObject[] LayoutArbeitsanweisung = new GameObject[10];
        LayoutArbeitsanweisung[0] = Allgemein_Layout;
        LayoutArbeitsanweisung[1] = KaufmännischerBereich_Layout;
        LayoutArbeitsanweisung[2] = Produktion_Layout;
        LayoutArbeitsanweisung[3] = EDV_Layout;
        LayoutArbeitsanweisung[4] = Materialwesen_Layout;
        LayoutArbeitsanweisung[5] = Organisation_Layout;
        LayoutArbeitsanweisung[6] = Personal_Layout;
        LayoutArbeitsanweisung[7] = TBTechnischerBereich_Layout;
        LayoutArbeitsanweisung[8] = Vertrieb_Layout;
        LayoutArbeitsanweisung[9]= Qualitätsmanagment_Layout;



        foreach (GameObject layout in LayoutArbeitsanweisung)
        {
            layout.SetActive(false);
        }
    }

    public void ScrollViewDeactivated()
    {
        GameObject[] LayoutArbeitsanweisung = new GameObject[4];
        LayoutArbeitsanweisung[0] = HLB;
        LayoutArbeitsanweisung[1] = ZUS;
        LayoutArbeitsanweisung[2] = WZB;
        LayoutArbeitsanweisung[3] = FOR;

        foreach (GameObject scrollView in LayoutArbeitsanweisung)
        {
            scrollView.SetActive(false);
        }
    }
}
