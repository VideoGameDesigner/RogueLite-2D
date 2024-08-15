using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveMovement : MonoBehaviour
{
    float sinCenterY;

    [SerializeField] private float EnemySpeed = 15f;
    [SerializeField] private float Amplitude;
    [SerializeField] private float Frequency;

    [SerializeField] GameObject HealthPack, Power_Up, UpgradeMetal;
    private int CollectibleChance;


    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

        Amplitude = Random.Range(1f, 3f);
        Frequency = Random.Range(1f, 3f);
        sinCenterY = transform.position.y;
        rb = GetComponent<Rigidbody2D>();
        SetStraightVelocity();
        CollectibleChance = Random.Range(0, 3);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovementWave();
    }


    private void SetStraightVelocity()
    {
        rb.velocity = Vector2.left * EnemySpeed;
    }

    private void EnemyMovementWave()
    {
        Vector2 pos = transform.position;

        float sin = Mathf.Sin(pos.x* Frequency) * Amplitude;
        pos.y = sinCenterY + sin;

        transform.position = pos;
    }


    private void LateUpdate()
    {
        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            
            ItemDrops();
            Destroy(gameObject);
            if (GameObject.FindGameObjectWithTag("EnemyManager"))
            {
                EnemyCount.Instance.EnemiesLeft(1);
            }


        }


        if (other.gameObject.CompareTag("BackBullet"))
        {
           
            ItemDrops();
            Destroy(gameObject);
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


    private void ItemDrops()
    {

        if (CollectibleChance == 0)
        {
            Instantiate(HealthPack, new Vector2(transform.position.x, transform.position.y), HealthPack.transform.rotation);
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




}
