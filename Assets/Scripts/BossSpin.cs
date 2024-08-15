using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpin : MonoBehaviour
{

    [SerializeField] private float RotationSpeed;
    //private int direction = 1;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        BossSpinner();


    }

    public void BossSpinner()
    {

        transform.localEulerAngles = new Vector3 (0, 0, Mathf.PingPong(Time.time* RotationSpeed,360));
        
    }






}
