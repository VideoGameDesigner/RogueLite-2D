using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTurret : MonoBehaviour
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

            transform.right = - direction * Rotationspeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            FinalBossHealthSystem.instance.FinalBossTakeDamage(20);
        }

    }

}
