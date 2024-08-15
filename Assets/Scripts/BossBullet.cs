using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    [SerializeField] private float BossBulletSpeed = 20f;


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
        if(BossHealthSystem.BossDied == true)
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

    private void SetStraightVelocity()
    {
        rb.velocity = Vector2.left * BossBulletSpeed;
    }



    private void LateUpdate()
    {
        if (transform.position.x <= -10)
        {
            Destroy(gameObject);
        }
    }


}
