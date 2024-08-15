using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirstBoss : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float BossSpeed;
    private int direction = 1;
    [SerializeField] float UpOrDown;
    [SerializeField] GameObject BossAmmoPref;
    [SerializeField] Transform[] BossBulletSpawns;
    [SerializeField] GameObject UpgradeMetal;
    [SerializeField] Transform[] UpgradesMetalSpawns;
    private float firerate = 0.3f;
    private float nextfire = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpOrDown = Random.value;
        nextfire = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

        if(BossHealthSystem.BossChange == true)
        {
            BossSpeed = 10;
        }
    

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Bullet"))
        {
            BossHealthSystem.instance.BossTakeDamage(20);

        }

    }

    private void BossMovemet()
    {
        if (UpOrDown < 0.5)

        {
            rb.velocity = Vector2.up * direction * BossSpeed;
            if (transform.position.y >= 1.36)
            {
                direction = -1;
            }

            else if (transform.position.y <= -3.57)
            {
                direction = 1;
            }
        }

        else
        {
            rb.velocity = Vector2.up * -direction * BossSpeed;

            if (transform.position.y <= -3.57)
            {
                direction = -1;
            }
            else if (transform.position.y >= 1.36)
            {
                direction = 1;
            }

        }

    }



    void BossWeaponFire()
    {
        if (Time.time > nextfire)
        {
            Instantiate(BossAmmoPref, BossBulletSpawns[0].transform.position, BossBulletSpawns[0].transform.rotation);
            Instantiate(BossAmmoPref, BossBulletSpawns[1].transform.position, BossBulletSpawns[1].transform.rotation);
            Instantiate(BossAmmoPref, BossBulletSpawns[2].transform.position, BossBulletSpawns[2].transform.rotation);
            nextfire = Time.time + firerate;
        }
    }

    private IEnumerator BossMoveDelay()
    {
        yield return new WaitForSeconds(1);
        BossWeaponFire();
        BossMovemet();
    }


}
