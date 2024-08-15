using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawn : MonoBehaviour
{
    [SerializeField] GameObject obstacleSpawnPrefab;
    //[SerializeField] Transform obstacleSpawnTransform;
    [SerializeField] float firerate;
    private float nextfire = 0;


    // Start is called before the first frame update
    void Start()
    {
        nextfire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleSpawns();
    }

    void ObstacleSpawns()
    {
        if (Time.time > nextfire)
        {
            Instantiate(obstacleSpawnPrefab,transform.position,transform.rotation);
            nextfire = Time.time + firerate;
        }
    }
}
