using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpAndHealthPack : MonoBehaviour
{
    [SerializeField] float ObjectSpeed = 7f;
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

    private void SetStraightVelocity()
    {
        rb.velocity = Vector2.left * ObjectSpeed;
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

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }


}
