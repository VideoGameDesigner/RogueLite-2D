using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyRam : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    [SerializeField] private float EnemySpeed;
    [SerializeField] GameObject HealthPack, Power_Up, UpgradeMetal;
    private int CollectibleChance;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();      
        StartCoroutine(MoveDelay());
        CollectibleChance = Random.Range(0, 3);

    }

    // Update is called once per frame
    void Update()
    {
        
             
    }

    private void ItemDrops()
    {

        if (CollectibleChance == 0)
        {
            Instantiate(HealthPack, new Vector2(transform.position.x,transform.position.y),HealthPack.transform.rotation);
        }

        if (CollectibleChance == 1)
        {
            Instantiate(Power_Up, new Vector2(transform.position.x, transform.position.y), HealthPack.transform.rotation);

        }

        if (CollectibleChance == 2)
        {
            Instantiate(UpgradeMetal, new Vector2(transform.position.x, transform.position.y), HealthPack.transform.rotation);

        }

    }




    private void LateUpdate()
    {
        if (transform.position.x <= -13)
        {

            Destroy(gameObject);
        }
    }


    private void EnemyMoveTowards()
    {
        
        if (player = GameObject.FindGameObjectWithTag("Player"))
        {
            Vector3 direction = player.transform.position - transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * EnemySpeed;

            float EnemyRotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, EnemyRotation);
        }
        
        else
        {
            rb.velocity = Vector2.left * EnemySpeed;
        }
             
    }


    private IEnumerator MoveDelay ()
    {
        yield return new WaitForSeconds(1);        
        EnemyMoveTowards();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {

            Destroy(gameObject);
            ItemDrops();
            
            if(GameObject.FindGameObjectWithTag("EnemyManager"))
            {
                EnemyCount.Instance.EnemiesLeft(1);
            }
                         
            
        }

        if (other.gameObject.CompareTag("BackBullet"))
        {


            Destroy(gameObject);
            ItemDrops();
            if (GameObject.FindGameObjectWithTag("EnemyManager"))
            {
                EnemyCount.Instance.EnemiesLeft(1);
            }
        }





        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }


}
