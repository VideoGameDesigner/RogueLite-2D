using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderFall : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] LayerMask layermask;
    [SerializeField] float laserlength = 10f;
    [SerializeField] float Obstaclespeed = 3f;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();       
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

    }



    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, laserlength, layermask);

        if (hit.collider != null)
        {
            rb.velocity = Vector2.down * Obstaclespeed;
            Debug.Log("Hitting: " + hit.collider.tag);
        }

        Debug.DrawRay(transform.position, Vector2.down * laserlength, Color.white);

        if (FinalBossHealthSystem.FinalBossDied == true)
        {
            Destroy(gameObject);
        }



    }

    private void LateUpdate()
    {
        if (transform.position.y <= -6)
        {
            Destroy(gameObject);
        }

    }



}
