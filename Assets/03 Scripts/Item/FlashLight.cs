using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField]
    GameObject FlashLightLight;
    public bool flashlightActive;
    public Light light;

    public GameObject flashLightActive = null;
    
    void Start()
    {
        light.intensity = 0.0f;
        FlashLightLight.gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(flashlightActive == false && flashLightActive.GetComponent<ItemController>().islightitemGet)
            {
                light.intensity = 4.5f;
                FlashLightLight.gameObject.SetActive(true);
                flashlightActive = true;
            }
            else
            {
                light.intensity = 0.0f;
                FlashLightLight.gameObject.SetActive(false);
                flashlightActive = false;
            }
        }
    } // 참고자료 : https://www.youtube.com/watch?v=vRKrg9Ku8Aw
}
