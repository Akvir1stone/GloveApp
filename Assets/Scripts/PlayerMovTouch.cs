using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerMovTouch : MonoBehaviour
{
    public Transform player;
    //public TMP_Text aveOut;
    private float aveInterval;
    private float maxa;
    private float mina;
    //private float modif;
    Vector3 touchPos;
    int c = 0;
    public TMP_Text nums;

    bool mode;
    [SerializeField]
    private float speed = 2f;
    void Start()
    {
        mode = true;
    }
    public void OnButtonChange()
    {
        if(mode == true) mode = false;
        else mode = true;
    }
    void Update()
    {
        // проверка макс и мин значений для соответствия формуле
        if(c == 0)
        {
            c++;
            if(DataScript.maxAve > DataScript.minAve)
        {
            maxa = DataScript.maxAve;
            mina = DataScript.minAve;
        }
        else
        {
            maxa = DataScript.minAve;
            mina = DataScript.maxAve;
        }
        aveInterval = maxa - mina;
        }
        // переключение ввода true для перчатки и false для сенсорного управления
       if (mode == true)
       {
        touchPos.x = (DataScript.ave - mina)/aveInterval*4.8f - 2.4f;
            touchPos.z = 0f;
            touchPos.y = -3.6f;
            // текст использовался для дебага, если удалить тестовое поле со сцены, нужно удалить эту строку
            nums.text = "pos: " + touchPos.x.ToString() + " min: " + mina + " max: " + maxa + " inter:" + aveInterval;
            touchPos.x = touchPos.x > 2.40f ? 2.40f: touchPos.x;
            touchPos.x = touchPos.x < -2.40f ? -2.40f: touchPos.x;
            player.position = Vector2.MoveTowards(player.position, touchPos, speed*Time.deltaTime);
       }
       else{
         if (Input.anyKey)
        {
            touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            touchPos.z = 0f;
            touchPos.y = -3.6f;
            touchPos.x = touchPos.x > 2.40f ? 2.40f: touchPos.x;
            touchPos.x = touchPos.x < -2.40f ? -2.40f: touchPos.x;
            player.position = Vector2.MoveTowards(player.position, touchPos, speed*Time.deltaTime);
        }

       }
    }
}
