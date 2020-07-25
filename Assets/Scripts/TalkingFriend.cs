using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingFriend : MonoBehaviour
{

    public GameObject talkBox;
    public bool playerInRange;


    void Start()
    {
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (talkBox.activeInHierarchy)
            {
                talkBox.SetActive(true);
                talkBox.GetComponent<InkScript>().ShowPanels();
                talkBox.GetComponent<InkScript>().refreshUI();
            }
            else
            {
                talkBox.SetActive(false);
                talkBox.GetComponent<InkScript>().HidePanels();
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
        }
    }



    ///method to be used in "Fade" script
    public void Off()
    {
        talkBox.SetActive(false);
    }


}