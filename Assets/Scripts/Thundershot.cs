using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thundershot : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float EnemySpeed = 3f;
    private int direction = 1;
    [SerializeField] GameObject EnemyBulletPref;
    [SerializeField] Transform EnemyBulletSpawn;
    [SerializeField] private float firerate = 1f;
    private float nextfire = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //BossMovement();
        //BossFire();
        StartCoroutine(ThunderMoveDelay());
    }

    void BossMovement()
    {
        rb.velocity = Vector2.left * direction * EnemySpeed;
        if (transform.position.x <= -8)
        {
            direction = -1;
        }

        else if (transform.position.x >= -1)
        {
            direction = 1;
        }
    }

    void BossFire()
    {
        if (Time.time > nextfire)
        {
            Instantiate(EnemyBulletPref, EnemyBulletSpawn.transform.position, EnemyBulletSpawn.transform.rotation);
            nextfire = Time.time + firerate;
        }

    }

    private IEnumerator ThunderMoveDelay()
    {
        yield return new WaitForSeconds(1);
        BossMovement();
        BossFire();

    }





}
