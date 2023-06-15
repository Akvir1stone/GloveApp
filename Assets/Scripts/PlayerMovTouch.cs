using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMovTouch : MonoBehaviour
{
    public Transform player;
    public TMP_Text aveOut;
    private float aveInterval;
    //private float modif;
    Vector3 touchPos;

    bool mode;
    [SerializeField]
    private float speed = 10f;
    void Start()
    {
        aveInterval = DataScript.maxAve - DataScript.minAve;
        //modif = aveInterval/4.8f;
        mode = true;

    }
    public void OnButtonChange()
    {
        if(mode == true) mode = false;
        else mode = true;
    }
    void Update()
    {      
          
        
       if (mode == true)
       {
        touchPos.x = (DataScript.ave - DataScript.minAve)/aveInterval*4.8f - 2.4f;
            //Debug.Log(touchPos);
            if (DataScript.AveTextGO == true) aveOut.text = DataScript.ave.ToString() + " !!!" + touchPos.x.ToString() + "!!!" + DataScript.maxAve + " " + DataScript.minAve;
            else aveOut.text = "";
            touchPos.z = 0f;
            touchPos.y = -3.6f;
            touchPos.x = touchPos.x > 2.40f ? 2.40f: touchPos.x;
            touchPos.x = touchPos.x < -2.40f ? -2.40f: touchPos.x;
            player.position = Vector2.MoveTowards(player.position, touchPos, speed*Time.deltaTime);
       }
       else{
         if (Input.anyKey)
        {            
            //Debug.Log("there is key");
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            //touchPos.x = (DataScript.ave - DataScript.minAve)/modif;
            Debug.Log(touchPos);
            touchPos.z = 0f;
            touchPos.y = -3.6f;
            touchPos.x = touchPos.x > 2.40f ? 2.40f: touchPos.x;
            touchPos.x = touchPos.x < -2.40f ? -2.40f: touchPos.x;
            player.position = Vector2.MoveTowards(player.position, touchPos, speed*Time.deltaTime);
        }

       }
    }
}
