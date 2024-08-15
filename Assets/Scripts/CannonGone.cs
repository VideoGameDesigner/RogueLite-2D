using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonGone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FinalBossHealthSystem.FinalBossDied == true)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
                    
        }

        if (other.gameObject.CompareTag("BackBullet"))
        {
            Destroy(gameObject);
            
        }



    }



}
