using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField] GameObject EnemyBulletPref;
    [SerializeField] Transform EnemyBulletSpawn;
    [SerializeField]private float firerate = 2f;
    private float nextfire = 0;



    // Start is called before the first frame update
    void Start()
    {
        nextfire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyFire();
    }

    void EnemyFire()
    {
        if(Time.time > nextfire)
        {
            Instantiate(EnemyBulletPref,EnemyBulletSpawn.transform.position,EnemyBulletSpawn.transform.rotation);
            nextfire = Time.time + firerate;
        }

    }
}
