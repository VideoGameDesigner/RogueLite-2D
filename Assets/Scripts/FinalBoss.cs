using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss : MonoBehaviour
{

    [SerializeField] private GameObject FinalBossBulletPref;
    [SerializeField] private Transform FinalBossBulletSpawn;
    [SerializeField] private GameObject [] ObjectsOnOrOff;
    [SerializeField] private GameObject Thunder;
    [SerializeField] private GameObject LastReward;
    [SerializeField] private Transform LastRewardSpawn;
    //private bool turnon = false;
    [SerializeField] float firerate;
    private float nextfire = 0;



    // Start is called before the first frame update
    void Start()
    {
        nextfire = Time.time;

       
       foreach (GameObject obj in ObjectsOnOrOff)
       {
         obj.SetActive(false);
       }
      

    }

    // Update is called once per frame
    void Update()
    {
             
        //RedEyeshot();
        StartCoroutine(BossMoveDelay());
        if (FinalBossHealthSystem.FinalBossDied == true)
        {
            gameObject.SetActive(false);
            Instantiate(LastReward, LastRewardSpawn.transform.position, LastRewardSpawn.transform.rotation);

        }

        if(FinalBossHealthSystem.FinalBossChange == true)
        {
            Thunder.SetActive(true);
        }


    }

    void RedEyeshot()
    {
        if (Time.time > nextfire)
        {
            Instantiate(FinalBossBulletPref, FinalBossBulletSpawn.transform.position, FinalBossBulletSpawn.transform.rotation);
            nextfire = Time.time + firerate;

        }

    }

    private IEnumerator BossMoveDelay()
    {
        yield return new WaitForSeconds(1);

        foreach (GameObject obj in ObjectsOnOrOff)
        {
            obj.SetActive(true);
        }


        RedEyeshot();
    }



}
