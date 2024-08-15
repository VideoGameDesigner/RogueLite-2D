using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBallshot : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb;
    [SerializeField] private float EyeBulletSpeed;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        EnemyMoveTowards();
    }

    // Update is called once per frame
    void Update()
    {
        if (BossHealthSystem.BossDied == true)
        {
            Destroy(gameObject);
        }
    }

    private void EnemyMoveTowards()
    {

        rb.velocity = transform.up * EyeBulletSpeed;


        /*player = GameObject.FindGameObjectWithTag("Player");      
       Vector3 direction = player.transform.position - transform.position;
       rb.velocity = new Vector2(direction.x, direction.y).normalized * EyeBulletSpeed;
       */
    }

    private void LateUpdate()
    {
        if (transform.position.y <= -6 || transform.position.y >= 6 || transform.position.x <= -10 || transform.position.x >= 10)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("ForceField"))
        {
            Destroy(gameObject);
        }

    }





}
