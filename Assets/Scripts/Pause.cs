using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{



    [SerializeField] public GameObject pausePanel; 

    // Start is called before the first frame update
    void Start()
    {
        //pausePanel.SetActive(false);
    }

    // Update is called once per frame
       void Update()
       {


           if (Input.GetKeyDown(KeyCode.Escape))
           {
            Debug.Log("first"); 
               if (!pausePanel.activeInHierarchy)
               {
                Debug.Log("second"); 
                   PauseGame();
               }

           else if (pausePanel.activeInHierarchy)
            {
                UnPauseGame();
                Debug.Log("third");
               
            }

           }
 
       }

    public  void  PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true); 
    }

   public  void  UnPauseGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
