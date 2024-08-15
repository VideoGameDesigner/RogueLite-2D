using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBoss : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float EnemySpeed = 3f;
    private int direction = 1;
    [SerializeField] GameObject EnemyBulletPref;
    [SerializeField] Transform EnemyBulletSpawn;
    [SerializeField] private float firerate = 1f;
    [SerializeField] GameObject UpgradeMetal;
    [SerializeField] Transform[] UpgradesMetalSpawns;
    private float nextfire = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //BossMovement();
        //BossFire();
        StartCoroutine(BossMoveDelay());
        if (BossHealthSystem.BossDied == true)
        {
            gameObject.SetActive(false);
            Instantiate(UpgradeMetal, UpgradesMetalSpawns[0].transform.position, UpgradesMetalSpawns[0].transform.rotation);
            Instantiate(UpgradeMetal, UpgradesMetalSpawns[1].transform.position, UpgradesMetalSpawns[1].transform.rotation);
            Instantiate(UpgradeMetal, UpgradesMetalSpawns[2].transform.position, UpgradesMetalSpawns[2].transform.rotation);
            Instantiate(UpgradeMetal, UpgradesMetalSpawns[3].transform.position, UpgradesMetalSpawns[3].transform.rotation);
            Instantiate(UpgradeMetal, UpgradesMetalSpawns[4].transform.position, UpgradesMetalSpawns[4].transform.rotation);
            Instantiate(UpgradeMetal, UpgradesMetalSpawns[5].transform.position, UpgradesMetalSpawns[5].transform.rotation);
            Instantiate(UpgradeMetal, UpgradesMetalSpawns[6].transform.position, UpgradesMetalSpawns[6].transform.rotation);
            Instantiate(UpgradeMetal, UpgradesMetalSpawns[7].transform.position, UpgradesMetalSpawns[7].transform.rotation);
            Instantiate(UpgradeMetal, UpgradesMetalSpawns[8].transform.position, UpgradesMetalSpawns[8].transform.rotation);
            Instantiate(UpgradeMetal, UpgradesMetalSpawns[9].transform.position, UpgradesMetalSpawns[9].transform.rotation);
            
            Debug.Log("Level Complete");
        }


        if (BossHealthSystem.BossChange == true)
        {
            EnemySpeed = 6;
        }
    }


    void BossMovement()
    {
        rb.velocity = Vector2.left * direction * EnemySpeed;
        if(transform.position.x <= - 5.21)
        {
            direction = -1;
        }

        else if(transform.position.x >= 5.3)
        {
            direction = 1;
        }
    }

    void BossFire()
    {
        if (Time.time > nextfire)
        {
            Instantiate(EnemyBulletPref, EnemyBulletSpawn.transform.position, EnemyBulletSpawn.transform.rotation);
            nextfire = Time.time + firerate;
        }

    }

    private IEnumerator BossMoveDelay()
    {
        yield return new WaitForSeconds(1);
        BossFire();
        BossMovement();
    }


}
