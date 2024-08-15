using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwiftEnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject SwiftEnemyPref;
    [SerializeField] float MinValue;
    [SerializeField] float MaxValue;
    private float EnemyPositionY;
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
        SwiftEnemySpawns();
        
    }

    void SwiftEnemySpawns()
    {
        if (Time.time > nextfire)
        {
            EnemyPositionY = Random.Range(MinValue, MaxValue);

            SpawnVector = new Vector2(transform.position.x, EnemyPositionY);

            Instantiate(SwiftEnemyPref, SpawnVector, Quaternion.identity);
            nextfire = Time.time + firerate;
        }
    }



}
