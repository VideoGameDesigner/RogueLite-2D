using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallShot : MonoBehaviour
{

    [SerializeField] private float CannonBallSpeed;
    private Rigidbody2D rb;
    //private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CannonBallFire();
    }

    // Update is called once per frame
    void Update()
    {
        if (FinalBossHealthSystem.FinalBossDied == true)
        {
            Destroy(gameObject);
        }
    }

    private void CannonBallFire()
    {
        rb.velocity = transform.up * CannonBallSpeed;

        /*if (player = GameObject.FindGameObjectWithTag("Player"))
        {
            Vector3 direction = player.transform.position - transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * CannonBallSpeed;

            float EnemyRotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, EnemyRotation);
        }

        else
        {
            rb.velocity = Vector2.left * CannonBallSpeed;
        }*/
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
    }




}
