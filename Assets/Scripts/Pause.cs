using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{



    [SerializeField] public GameObject pausePanel;
     [SerializeField] AudioSource playMusic;
    [SerializeField] AudioSource playPauseMusic;

    // Start is called before the first frame update
    void Start()
    {
        //playMusic = GetComponent<AudioSource>();
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
                //playMusic.mute = playMusic.mute;
                PauseGame();
             //   playMusic.mute = true;
                
            }

            else if (pausePanel.activeInHierarchy)
            {
                UnPauseGame();
                Debug.Log("third");
                playMusic.mute = false; 
            }

           }
 
       }

    public  void  PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        playMusic.mute = true;
        playPauseMusic.mute = false; 

    }

    public  void  UnPauseGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        playMusic.mute = false;
        playPauseMusic.mute = true; 
    }
}
