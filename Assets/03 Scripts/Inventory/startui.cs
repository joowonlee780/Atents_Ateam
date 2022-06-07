using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class startui : MonoBehaviour
{
    public GameObject First = null;
    //public GameObject Second = null;

    public void Start()
    {
        First.SetActive(false);
        //Second.SetActive(false);

        StartCoroutine(WaitBeforeShow());

    }
    IEnumerator WaitBeforeShow()
    {
        yield return new WaitForSeconds(0.2f);
        First.SetActive(true);

        
            
        //yield return new WaitForSeconds(1.6f);
        //Second.SetActive(true);
        //yield return new WaitForSeconds(2f);
       // Second.SetActive(false);

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            First.SetActive(false);
        }
    }

}
