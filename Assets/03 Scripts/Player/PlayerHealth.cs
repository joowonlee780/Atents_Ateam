using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float health = 100;
    public float maxHealth = 100;

    public Text healthText = null;
    public Slider healthSlider = null;
    private const string enumyTag = "ENUMY";
    private const string gasTag = "GAS";



    public float Health
    {
        get => health;
        set
        {
            health = value;
        }
    }

    private void Awake()
    {
        healthText = GameObject.Find("HealthText").GetComponent<Text>();
        healthSlider = GameObject.Find("HealthSlider").GetComponent<Slider>();
        
    }

    private void Start()
    {
        Health = health;
    }

    

    private void OnTriggerEnter(Collider coll)
    {
        if (health > 10) 
        {
            if (coll.tag == enumyTag)
                enumydamage();
        }
        if (health > 10)
        {
            if (coll.tag == enumyTag)
                gasdamage();
        }

        if (health < 1)
        {
            if (coll.tag == enumyTag)
                PlayerDie();
        }
        if (health < 1)
        {
            if (coll.tag == enumyTag)
                PlayerDie();
        }


    }

    private void enumydamage()
    {
        health -= maxHealth * 0.1f;
        healthSlider.value = health / maxHealth;
        healthText.text = $"{health}/{maxHealth}";
    }
    private void gasdamage()
    {
        health -= maxHealth * 0.01f;
        healthSlider.value = health / maxHealth;
        healthText.text = $"{health}/{maxHealth}";
    }
    private void PlayerDie()
    {
        Debug.Log("gameover");
    }

   

}
