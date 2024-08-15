using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] GameObject Enemy;

    private float SpawnPositionX;
    private float SpawnPositionY;
    [SerializeField] float firerate;
    private float nextfire = 0;

    Vector2 SpawnVector;


    // Start is called before the first frame update
    void Start()
    {
        nextfire = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnEnemy();
    }


    void SpawnEnemy()
    {
        if (Time.time > nextfire)
        {
            SpawnPositionX = Random.Range(1f, 7f);
            SpawnPositionY = Random.Range(3f, -4f);

            SpawnVector = new Vector2(SpawnPositionX, SpawnPositionY);

            Instantiate(Enemy, SpawnVector, Quaternion.identity);
            nextfire = Time.time + firerate;
        }
       

    }
}
