using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Material_Magnet : MonoBehaviour
{

    private GameObject player;
    private Rigidbody2D rb;
    [SerializeField] private float CollectibleSpeed;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        CollectibleMovement();
    }

    private void CollectibleMovement()
    {
        
        if(player = GameObject.FindGameObjectWithTag("Player"))
        {
            Vector3 direction = player.transform.position - transform.position;
            rb.velocity = new Vector2(direction.x, direction.y).normalized * CollectibleSpeed;
        }
        
        else
        {
            rb.velocity = Vector2.left * CollectibleSpeed;
        }
           
        
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject,0.01f);
        }
    }


}
