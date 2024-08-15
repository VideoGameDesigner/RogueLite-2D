using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Up_Down_Bullet : MonoBehaviour
{
    [SerializeField] private float BulletSpeed = 10f;   
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpandDownVelocity();      
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

        if (other.gameObject.CompareTag("1st_Boss"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Cannon"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("EyeBall"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("TrickyEnemy"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("ToughEnemy"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Mine"))
        {
            Destroy(gameObject);
        }

    }




    private void LateUpdate()
    {
        if (transform.position.y <= -6|| transform.position.y >= 6)
        {
            Destroy(gameObject);
        }
    }
 

    private void UpandDownVelocity()
    {
        rb.velocity = transform.right * BulletSpeed;
    }


}
