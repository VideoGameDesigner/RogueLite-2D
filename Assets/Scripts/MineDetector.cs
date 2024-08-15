using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineDetector : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] LayerMask layermask;
    //[SerializeField] float laserlength;
    [SerializeField] float Obstaclespeed = 3f;
    [SerializeField] float Radius = 1;
     
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * Obstaclespeed;       
    }

    // Update is called once per frame
    void Update()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, Radius,layermask);

        foreach (Collider2D col in colliders)
        {          
            GetPlayer();
        }

        if (FinalBossHealthSystem.FinalBossDied == true)
        {
            Destroy(gameObject);
        }


    }



    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, Radius);
                  
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

        if(other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("BackBullet"))
        {
            Destroy(gameObject);
        }

    }

    void GetPlayer ()
    {
               
      player = GameObject.FindGameObjectWithTag("Player");
      Vector3 direction = player.transform.position - transform.position;
      rb.velocity = new Vector2(direction.x, direction.y).normalized * Obstaclespeed;

      //float EnemyRotation = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
      //transform.rotation = Quaternion.Euler(0, 0, 0);
        
        
    }



}
