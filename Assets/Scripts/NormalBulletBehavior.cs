using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBulletBehavior : MonoBehaviour
{

    [SerializeField] private float BulletSpeed = 15f;
    

    private Rigidbody2D rb;
   

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetStraightVelocity();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("TrickyEnemy"))
        {
            Destroy(gameObject);
        }


        if (other.gameObject.CompareTag("1st_Boss"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Cannon"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("ToughEnemy"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("EyeBall"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Mine"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("FinalBoss"))
        {
            Destroy(gameObject);
        }

    }



    private void SetStraightVelocity()
    {
        rb.velocity = transform.right * BulletSpeed;
    }



    private void LateUpdate()
    {
        if (transform.position.x >= 10)
        {
            Destroy(gameObject);
        }
    }



}
