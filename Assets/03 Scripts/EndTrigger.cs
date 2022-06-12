using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndTrigger : MonoBehaviour
{
    // public GameManager gameManager;

    public Image Panel;
    float time = 0f;
    float F_time = 4.0f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           if(GameObject.FindObjectOfType<ItemController>().blackKeyOn)
           {
               GameObject.FindObjectOfType<PlayerController>().enabled = false;
               fadeOut();
               
           }
        }
        
    }
    public void fadeOut()
    {
        StartCoroutine(FadeFlow());
    }
    
    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true);
        Color alpha = Panel.color;
        
        
        while (alpha.a < 1f)
        {
            Panel.gameObject.SetActive(true);
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 1, time);
            Panel.color = alpha;
            yield return null;
        }
        time = 0;
        yield return new WaitForSeconds(3.0f);

        SceneManager.LoadScene(0);
    }
}
