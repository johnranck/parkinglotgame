using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{

    int n;
    public Pause paused; 

    public void OnButtonPress()
    {
        n++; 
        Debug.Log("Button clicked " + n + "times");
        paused.UnPauseGame(); 
       // GetComponent<Pause>().UnPauseGame(); 
    }

}


