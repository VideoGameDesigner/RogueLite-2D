using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{

    [SerializeField] private GameObject FirstBoss;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(BossHealthSystem.BossDied == false)
        {
            FirstBoss.SetActive(true);
        }
    }

   

}
