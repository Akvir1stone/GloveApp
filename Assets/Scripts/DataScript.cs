using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;
using UnityEngine.SceneManagement;


public class DataScript : MonoBehaviour
{
    public GameObject MinPanel;
    public GameObject MaxPanel;
    public GameObject ButtonPlay;
    public GameObject Player;
    public GameObject Camera;
    public GameObject Event;
    public GameObject Movement;
    public GameObject MovChanger;
    public TMP_Text TextAnser1;
    public TMP_Text TextAnser2;
    public TMP_Text Status;
    public float timeout;
    public string collector;
    public string anse;
    public char[] ans;
    string sensor1;
    string sensor2;
    string sensor3;
    string sensor4;
    string sensor5;
    string sensor6;
    string sensor7;
    string sensor8;
    string dsensor1;
    string dsensor2;
    string dsensor3;
    string dsensor4;
    string dsensor5;
    string dsensor6;
    string dsensor7;
    string dsensor8;
    float sen1;
    float sen2;
    float sen3;
    float sen4;
    float sen5;
    float sen6;
    float sen7;
    float sen8;
    public static float ave;
    public static float aver;    
    int sens;
    public static float minAve;
    public static float maxAve;
    public float delay = 1.5f;
    //public TMP_Text AveText;
    public static bool AveTextGO;
    public GameObject chButton;
    

    // Start is called before the first frame update
    public void OnButtonMin()
    {        
        minAve = float.Parse(TextAnser1.text);
        //TextAnser1.text = minAve.ToString();
        MinPanel.SetActive(false);
        MaxPanel.SetActive(true);
    }

    public void OnButtonMax()
    {        
        maxAve = float.Parse(TextAnser2.text);;
        //TextAnser2.text = maxAve.ToString();
        ButtonPlay.SetActive(true);
    }

    public static float getAve()
    {
        aver = ave;
        return aver;
    }

    public void OnButtonPlay()
    {
        MinPanel.SetActive(false);
        MaxPanel.SetActive(false);
        Player.SetActive(true);
        Movement.SetActive(true);
        Camera.SetActive(true);
        SpawnObs.spawn = true;
        MovChanger.SetActive(true);
        chButton.SetActive(true);
        //AveTextGO.SetActive(true);
        //PlayerCrash.crash = false;
        //SpawnObs.StartSpawn();
        AveTextGO = true;
        

    }


    void Start()
    {
        MinPanel.SetActive(true);
        MaxPanel.SetActive(false);
        Player.SetActive(false);
        Movement.SetActive(false);
        ButtonPlay.SetActive(false);
        MovChanger.SetActive(false);
        chButton.SetActive(false);
        AveTextGO = false;
        //AveTextGO.SetActive(false);
        //PlayerCrash.crash = true;
        SpawnObs.spawn = false;
    }

    // Update is called once per frame
    void Update()
    {
        
            if(timeout > 0f)
            {
                timeout -= Time.deltaTime;
                if(timeout <= 0f)
                {
                    timeout = 0.2f;
                    Connection.SendString("GA");
                    anse = Connection.receivedMess;
                    ans = anse.ToCharArray();
                    sensor1 = "";
                    sensor2 = "";
                    sensor3 = "";
                    sensor4 = "";
                    sensor5 = "";
                    sensor6 = "";
                    sensor7 = "";
                    sensor8 = "";
                    for (int i = 0; i <= anse.Length; i++)
                    {
                        collector = collector + ans[i];
                        if (i == 0) sens = 0;
                        switch (collector.Substring(collector.Length - 4))
                        {
                            case ("AD1:"):
                            //Status.text = collector.Substring(collector.Length - 5);
                            if (collector.Substring(collector.Length - 1) != ",") sens = 1;
                            break;
                            case ("AD2:"):
                            if (collector.Substring(collector.Length - 1) != ",") sens = 2;
                            break;
                            case ("AD3:"):
                            if (collector.Substring(collector.Length - 1) != ",") sens = 3;
                            break;
                            case ("AD4:"): 
                            if (collector.Substring(collector.Length - 1) != ",") sens = 4;
                            break;
                            case ("AD5:"):
                            if (collector.Substring(collector.Length - 1) != ",") sens = 5;
                            break;
                            case ("AD6:"):
                            if (collector.Substring(collector.Length - 1) != ",") sens = 6;
                            break;
                            case ("AD7:"):
                            if (collector.Substring(collector.Length - 1) != ",") sens = 7;
                            break;
                            case ("AD8:"):
                            if (collector.Substring(collector.Length - 1) != ",") sens = 8;
                            break;
                        }
                        switch (sens)
                        {
                            case (1):
                            sensor1 = sensor1 + ans[i];
                            break;
                            case (2):
                            sensor2 = sensor2 + ans[i];
                            break;
                            case (3):
                            sensor3 = sensor3 + ans[i];
                            break;
                            case (4):
                            sensor4 = sensor4 + ans[i];
                            break;
                            case (5):
                            sensor5 = sensor5 + ans[i];
                            break;
                            case (6):
                            sensor6 = sensor6 + ans[i];
                            break;
                            case (7):
                            sensor7 = sensor7 + ans[i];
                            break;
                            case (8):
                            sensor8 = sensor8 + ans[i];
                            break;
                        }
                        //dsensor1 = sensor1.Substring(1, sensor1.Length-5);
                        if(sensor1.Length >= 5) dsensor1 = sensor1.Substring(1, sensor1.Length-5);
                        try { sen1 += (-sen1 + float.Parse(dsensor1))*0.2f;} catch{}
                        if(sensor2.Length >= 5) dsensor2 = sensor2.Substring(1, sensor2.Length-5);
                        try { sen2 += (-sen2 + float.Parse(dsensor2))*0.2f;} catch{}
                        if(sensor3.Length >= 5) dsensor3 = sensor3.Substring(1, sensor3.Length-5);
                        try { sen3 += (-sen3 + float.Parse(dsensor3))*0.2f;} catch{}
                        if(sensor4.Length >= 5) dsensor4 = sensor4.Substring(1, sensor4.Length-5);
                        try { sen4 += (-sen4 + float.Parse(dsensor4))*0.2f;} catch{}
                        if(sensor5.Length >= 5) dsensor5 = sensor5.Substring(1, sensor5.Length-5);
                        try { sen5 += (-sen5 + float.Parse(dsensor5))*0.2f;} catch{}
                        if(sensor6.Length >= 5) dsensor6 = sensor6.Substring(1, sensor6.Length-5);
                        try { sen6 += (-sen6 + float.Parse(dsensor6))*0.2f;} catch{}
                        if(sensor7.Length >= 5) dsensor7 = sensor7.Substring(1, sensor7.Length-5);
                        try { sen7 += (-sen7 + float.Parse(dsensor7))*0.2f;} catch{}
                        if(sensor8.Length >= 5) dsensor8 = sensor8.Substring(1, sensor8.Length-2);
                        try { sen8 += (-sen8 + float.Parse(dsensor8))*0.2f;} catch{}
                        //ave = (sen1+sen2+sen3+sen4+sen5+sen6+sen7+sen8)/8;
                        ave = (sen2)/1;
                        TextAnser1.text = ave.ToString();
                        TextAnser2.text = ave.ToString();
                        //AveText.text = ave.ToString();
                    }
                    collector = "";
                    
                }
            }
        
    }
}
