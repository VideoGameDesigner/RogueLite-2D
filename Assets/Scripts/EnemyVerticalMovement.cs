using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyVerticalMovement : MonoBehaviour
{   
    private Rigidbody2D rb;
    [SerializeField] private float EnemySpeed = 3f;
    private int direction = 1;
    [SerializeField] float UpOrDown;
    [SerializeField]private int EnemyHealth;
    [SerializeField] GameObject HealthPack, Power_Up, UpgradeMetal;
    private int CollectibleChance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpOrDown = Random.value;
        CollectibleChance = Random.Range(0,3);
        EnemyHealth = 2;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
        
       
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            EnemyHealth --;

            if(EnemyHealth <= 0)

            {
                EnemyHealth = 2;
                EnemyCount.Instance.EnemiesLeft(1);
                ItemDrops();
                Destroy(gameObject);
            }           

        }

        if (other.gameObject.CompareTag("BackBullet"))
        {
            EnemyHealth -= 2;

            if (EnemyHealth <= 0)

            {
                EnemyHealth = 2;
                EnemyCount.Instance.EnemiesLeft(1);
                ItemDrops();
                Destroy(gameObject);
            }

        }



    }


    private void ItemDrops()
    {

        if(CollectibleChance == 0)
        {
            Instantiate(HealthPack, transform.position, transform.rotation);
        }

        if(CollectibleChance == 1) 
        { 
            Instantiate(Power_Up, transform.position, transform.rotation);
                     
        }

        if(CollectibleChance == 2) 
        {
            Instantiate(UpgradeMetal, transform.position, transform.rotation);
                      
        }

    }



    private void EnemyMovement()
    {

        if (UpOrDown < 0.5)

        {
            rb.velocity = Vector2.up * direction * EnemySpeed;
            if (transform.position.y >= 3.18)
            {
                direction = -1;
            }

            else if (transform.position.y <= -4.66)
            {
                direction = 1;
            }
        }

        else
        {
            rb.velocity = Vector2.up * -direction * EnemySpeed;

            if (transform.position.y <= -4.66)
            {
                direction = -1;
            }
            else if (transform.position.y >= 3.18)
            {
                direction = 1;
            }

        }


    }
  

}
