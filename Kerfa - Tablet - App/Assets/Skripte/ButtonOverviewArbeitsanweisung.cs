using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOverviewArbeitsanweisung : MonoBehaviour
{
    public GameObject buttonLayout;
    public void Deactivate()
    {
        foreach(Transform children in buttonLayout.transform)
        {
                children.gameObject.SetActive(false);  
        }
    }

    public void Activate()
    {
        foreach (Transform children in buttonLayout.transform)
        {
            children.gameObject.SetActive(true);
        }
    }


}
