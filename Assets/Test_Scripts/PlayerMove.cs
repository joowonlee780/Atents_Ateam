using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameObject cube;
    public float speed = 5.0f;
    private float hor;
    private float ver;


    private void Start()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");  
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = new Vector3(hor, ver);
        transform.Translate(vec);
    }
}
