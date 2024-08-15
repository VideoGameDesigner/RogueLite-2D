using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float Rotationspeed;
    [SerializeField] private GameObject CannonBallPref;
    [SerializeField] private Transform CannonBallLocation;
    [SerializeField] float firerate;
    private float nextfire = 0;
    [SerializeField] private GameObject CannonBase;


    // Start is called before the first frame update
    void Start()
    {
        nextfire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        //CannonFollow();
        //CannonFire();
        StartCoroutine(CannonStartDelay());

    }
    

    void CannonFollow()
    { 
        if(player = GameObject.FindGameObjectWithTag("Player"))
        {
            Vector3 playerpos = player.transform.position;

            Vector2 direction = new Vector2(playerpos.x - transform.position.x, playerpos.y- transform.position.y);

            transform.up = direction * Rotationspeed;
        }
    
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Bullet"))
        {
            
            Destroy(gameObject);
            Destroy(CannonBase);
            if (GameObject.FindGameObjectWithTag("EnemyManager"))
            {
                EnemyCount.Instance.EnemiesLeft(1);
            }
        }

        if (other.gameObject.CompareTag("BackBullet"))
        {
            
            Destroy(gameObject);
            Destroy(CannonBase);

            if (GameObject.FindGameObjectWithTag("EnemyManager"))
            {
                EnemyCount.Instance.EnemiesLeft(1);
            }
        }



    }

    void CannonFire()
    {
        if (Time.time > nextfire)
        {
            Instantiate(CannonBallPref, CannonBallLocation.transform.position, CannonBallLocation.transform.rotation);
            nextfire = Time.time + firerate;

        }
    }
    private IEnumerator CannonStartDelay()
    {
        yield return new WaitForSeconds(1);
        CannonFollow();
        CannonFire();
    }

}
