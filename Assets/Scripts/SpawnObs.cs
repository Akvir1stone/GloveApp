using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObs : MonoBehaviour
{
    public GameObject ob1;
    public GameObject ob2;
    public GameObject ob3;
    public GameObject ob4;
    public static bool spawn;

    [SerializeField]
    private static float interval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }
    // public static void StartSpawn(float delay)
    // {
    //     interval = delay;
    // }
    IEnumerator Spawn()
    {
        int choos;
        if(!PlayerCrash.crash){
        while(true)
        {
            if (spawn == true){
            choos = Random.Range(1,5);            
            switch (choos)
            {
                case 1:
                Instantiate (ob1, new Vector2(Random.Range(-2.8f,2.8f), 6.3f), Quaternion.identity);
                break;
                case 2:
                Instantiate (ob2, new Vector2(Random.Range(-2.8f,2.8f), 6.3f), Quaternion.identity);
                break;
                case 3:
                Instantiate (ob3, new Vector2(Random.Range(-2.8f,2.8f), 6.3f), Quaternion.identity);
                break;
                case 4:
                Instantiate (ob4, new Vector2(Random.Range(-2.8f,2.8f), 6.3f), Quaternion.identity);
                break;
            }}
            yield return new WaitForSeconds(interval);
        }}
    }
}
