using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUI : MonoBehaviour
{
    public GameObject CanvasSwip;
    public GameObject Canvas2d;
    public void ChangeUIStyle()
    {
        if(CanvasSwip.activeSelf == true)
        {
            CanvasSwip.SetActive(false);
            Canvas2d.SetActive(true);
        }
        else
        {
            Canvas2d.SetActive(false);
            CanvasSwip.SetActive(true);
        }
    }
}
