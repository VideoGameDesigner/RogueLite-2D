using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBall : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float Rotationspeed;
    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
        
    }


    public void FollowPlayer()
    {
        if (player = GameObject.FindGameObjectWithTag("Player"))
        {
            Vector3 playerpos = player.transform.position;

            Vector2 direction = new Vector2(playerpos.x - transform.position.x, playerpos.y - transform.position.y);

            transform.up = direction * Rotationspeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            BossHealthSystem.instance.BossTakeDamage(20);
        }

        if (other.gameObject.CompareTag("BackBullet"))
        {
            BossHealthSystem.instance.BossTakeDamage(40);
        }

    }


}
