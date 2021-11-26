using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeleteIn3Sec : MonoBehaviour
{
    public void popUP()
    {
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
