using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBossBullet : MonoBehaviour
{

    [SerializeField] private float FinalBossBulletSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FinalBossBulletMovement();
    }

    // Update is called once per frame
    void Update()
    {
       if(FinalBossHealthSystem.FinalBossDied == true)
        {
            Destroy(gameObject);
        }
    }

    void FinalBossBulletMovement()
    {
        rb.velocity = -transform.right * FinalBossBulletSpeed;
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
