using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    // Update is called once per frame
    void Update()
    {
        if(!PlayerCrash.crash) 
        {
        if (transform.position.y < -6f)
        {
            Destroy(gameObject);
        }
        transform.position -= new Vector3(0, speed*Time.deltaTime, 0);
        }
    }
}
