using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private int Levelup = 0;
    private bool shielded = false;
    [SerializeField] GameObject shield;
    private int shieledCounter;
   

    // Start is called before the first frame update
    void Start()
    {       
        shieledCounter = 3;
    }

    // Update is called once per frame
    void Update()
    {
        MaximumHealtIncrease();
                            
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Spinner"))
        {
            GameManager.Instance.TakeDamage(2);
        }

        /*if (collision.gameObject.CompareTag("Metal"))
        {
            Levelup++;
        }
        */

        if (collision.gameObject.CompareTag("HotIron"))
        {
            GameManager.Instance.TakeDamage(2);
        }


    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            
            if (!shielded)
            {
                GameManager.Instance.TakeDamage(20);
            }

            if (shielded)
            {
                shieledCounter--;
            }

            if(shieledCounter <= 0)
            {
                shielded = false;
                shield.SetActive(false);
                shieledCounter = 3;
            }
            
        }

        if (other.gameObject.CompareTag("ToughEnemy"))
        {

            if (!shielded)
            {
                GameManager.Instance.TakeDamage(30);
            }

            if (shielded)
            {
                shieledCounter--;
            }

            if (shieledCounter <= 0)
            {
                shielded = false;
                shield.SetActive(false);
                shieledCounter = 3;
            }

        }


        if (other.gameObject.CompareTag("TrickyEnemy"))
        {

            if (!shielded)
            {
                GameManager.Instance.TakeDamage(30);
            }

            if (shielded)
            {
                shieledCounter--;
            }

            if (shieledCounter <= 0)
            {
                shielded = false;
                shield.SetActive(false);
                shieledCounter = 3;
            }

        }





        if (other.gameObject.CompareTag("Obstacle"))
        {

            if (!shielded)
            {
                GameManager.Instance.TakeDamage(10);
            }

            if (shielded)
            {
                shieledCounter--;
            }

            if (shieledCounter <= 0)
            {
                shielded = false;
                shield.SetActive(false);
                shieledCounter = 3;
            }

        }

        if (other.gameObject.CompareTag("Mine"))
        {

            if (!shielded)
            {
                GameManager.Instance.TakeDamage(20);
            }

            if (shielded)
            {
                shieledCounter--;
            }

            if (shieledCounter <= 0)
            {
                shielded = false;
                shield.SetActive(false);
                shieledCounter = 3;
            }

        }






        if (other.gameObject.CompareTag("Thunder"))
        {

            if (!shielded)
            {
                GameManager.Instance.TakeDamage(10);
            }

            if (shielded)
            {
                shieledCounter--;
            }

            if (shieledCounter <= 0)
            {
                shielded = false;
                shield.SetActive(false);
                shieledCounter = 3;
            }

        }



        if (other.gameObject.CompareTag("CannonBalls"))
        {

            if (!shielded)
            {
                GameManager.Instance.TakeDamage(10);
            }

            if (shielded)
            {
                shieledCounter--;
            }

            if (shieledCounter <= 0)
            {
                shielded = false;
                shield.SetActive(false);
                shieledCounter = 3;
            }

        }



        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            if (!shielded)
            {
                GameManager.Instance.TakeDamage(20);
            }

            if (shielded)
            {
                shieledCounter--;
            }

            if (shieledCounter <= 0)
            {
                shielded = false;
                shield.SetActive(false);
                shieledCounter = 3;
            }

        }

        if (other.gameObject.CompareTag("ToughEnemyBullet"))
        {
            if (!shielded)
            {
                GameManager.Instance.TakeDamage(40);
            }

            if (shielded)
            {
                shieledCounter--;
            }

            if (shieledCounter <= 0)
            {
                shielded = false;
                shield.SetActive(false);
                shieledCounter = 3;
            }

        }




        if (other.gameObject.CompareTag("BossBullets"))
        {
            if (!shielded)
            {
                GameManager.Instance.TakeDamage(20);
            }

            if (shielded)
            {
                shieledCounter--;
            }

            if (shieledCounter <= 0)
            {
                shielded = false;
                shield.SetActive(false);
                shieledCounter = 3;
            }

        }

        if (other.gameObject.CompareTag("FinalBossBullet"))
        {
            if (!shielded)
            {
                GameManager.Instance.TakeDamage(50);
            }

            if (shielded)
            {
                shieledCounter--;
            }

            if (shieledCounter <= 0)
            {
                shielded = false;
                shield.SetActive(false);
                shieledCounter = 3;
            }

        }

        if (other.gameObject.CompareTag("EyeBallBullet"))
        {
            if (!shielded)
            {
                GameManager.Instance.TakeDamage(30);
            }

            if (shielded)
            {
                shieledCounter--;
            }

            if (shieledCounter <= 0)
            {
                shielded = false;
                shield.SetActive(false);
                shieledCounter = 3;
            }

        }



        if (other.gameObject.CompareTag("Healing"))
        {
            GameManager.Instance.RegainHealh(20);
        }

        if (other.gameObject.CompareTag("Metal"))
        {
            Levelup++;
        }

        if (other.gameObject.CompareTag("HugeUpgrade"))
        {
            GameManager.Instance.IncreaseHealth(200);
        }



        if (other.gameObject.CompareTag("Shield") && !shielded)
        {
            shield.SetActive(true);
            shielded = true;
        }
      

    }



    private void MaximumHealtIncrease()
    {
        if(Levelup >= 2)
        {
            Levelup = 0;
            GameManager.Instance.IncreaseHealth(10);
            
        }

    }

    


}
