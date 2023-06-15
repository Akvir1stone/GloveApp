using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrash : MonoBehaviour
{
    public static bool crash = false;
    public static int crashCount = 0;
    public static float delay = 1.5f;
    void OnTriggerEnter2D (Collider2D other)
    {        
        crashCount++;
        if (other.gameObject.tag == "ob")
        {            
            StartCoroutine(WaitAndChangeCrash(delay));
        }        
    }

    IEnumerator WaitAndChangeCrash(float delayn)
{
    crash = true;    
    yield return new WaitForSeconds(delay);            
    crash = false;    
}
}
