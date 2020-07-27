using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class CompSongPlayer : MonoBehaviour
{

    public GameObject talkBox;
    public bool playerInRange;
    [SerializeField] AudioSource playMusic;
    [SerializeField] AudioSource playCompSong1;
    public bool talkOn = false;
    public InkScript inkScript; 

    void Start()
    {
    }

// WORKING VERSION OF THIS SCRIPT WITH FINAL FUNCTIONALITY
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)

        {
            if (talkOn == false)
            {
                Debug.Log("talking");
                talkBox.SetActive(true);
                talkBox.GetComponent<InkScript>().ShowPanels();
                talkBox.GetComponent<InkScript>().refreshUI();
                ChangeMusicToSong();
                talkOn = true;
                talkBox.GetComponent<InkScript>().ContinueBool(); 
            }

            else if (Input.GetKeyDown(KeyCode.Space) && inkScript.continuing)

            {
                Debug.Log("talkingMore");
                talkBox.GetComponent<InkScript>().refreshUI();
                talkBox.GetComponent<InkScript>().ContinueBool();

            }

            else 
            {
                Debug.Log("ending");
                talkOn = false;
                talkBox.GetComponent<InkScript>().eraseUI();
                talkBox.GetComponent<InkScript>().refreshStory();
                talkBox.GetComponent<InkScript>().HidePanels();
                ChangeMusicToMain();
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().UnFreeze();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            talkBox.GetComponent<InkScript>().eraseUI();
            talkBox.GetComponent<InkScript>().refreshStory();
            talkBox.GetComponent<InkScript>().HidePanels();
            ChangeMusicToMain(); 
        }
    }

    public void ChangeMusicToSong()
    {
        playMusic.mute = true;
        playCompSong1.mute = false;
    }

    public void ChangeMusicToMain()
    {
        playMusic.mute = false;
        playCompSong1.mute = true;
    }
    ///method to be used in "Fade" script
    public void Off()
    {
        talkBox.SetActive(false);
    }


    /*BASIC STSART OF PREVIOUS 'TALKINGFRIEND' SCRIPT
     * void Update()
     {
         if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
         {
             if (talkBox.activeInHierarchy)
             {
                 talkBox.SetActive(true);
                 talkBox.GetComponent<InkScript>().ShowPanels();
                 talkBox.GetComponent<InkScript>().refreshUI();
                 ChangeMusicToSong();
             }
             else
             {
                 talkBox.SetActive(false);
                 talkBox.GetComponent<InkScript>().HidePanels();
                 ChangeMusicToMain();
             }
         }
     }
     */


    /*WORKING VERSION OF FIRST VERSION OF THIS SCRIPT
     * 
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && playerInRange)

            {
                if (talkOn == false)
                {
                    Debug.Log("talking");
                    talkBox.SetActive(true);
                    talkBox.GetComponent<InkScript>().ShowPanels();
                    talkBox.GetComponent<InkScript>().refreshUI();
                    ChangeMusicToSong();
                    talkOn = true;
                }

             else

            {
                Debug.Log("test");
                     talkOn = false;
                     talkBox.GetComponent<InkScript>().eraseUI();
                      talkBox.GetComponent<InkScript>().refreshStory();
                    talkBox.GetComponent<InkScript>().HidePanels();
                     ChangeMusicToMain();
                     GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().UnFreeze();
                }
            }
    }
    */
}