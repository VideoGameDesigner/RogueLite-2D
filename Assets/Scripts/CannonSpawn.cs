using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSpawn : MonoBehaviour
{

    [SerializeField] GameObject CannonPref;
    [SerializeField] float MinValue;
    [SerializeField] float MaxValue;
    private float CannonPositionX;
    [SerializeField] float firerate;
    Vector2 SpawnVector;
    private float nextfire = 0;


    // Start is called before the first frame update
    void Start()
    {
        nextfire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CannonSpawns();
    }

    void CannonSpawns()
    {
        if (Time.time > nextfire)
        {
            CannonPositionX = Random.Range(MinValue, MaxValue);

            SpawnVector = new Vector2 (CannonPositionX, transform.position.y);

            Instantiate(CannonPref,SpawnVector, Quaternion.identity);
            nextfire = Time.time + firerate;
        }
    }
}
