using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCount : MonoBehaviour
{
    [SerializeField] private int TotalEnemies = 10;
    [SerializeField] private TextMeshProUGUI Enemytext;
    

    public static EnemyCount Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

              
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemytext.text = "Enemies Left:   " + TotalEnemies;
        if (TotalEnemies <= 0)
        {           
            SceneSwitcher.Instance.NextScene();            
        }
    }


    public void EnemiesLeft(int enemyGone)
    {
        TotalEnemies -= enemyGone;
        Enemytext.text = "Enemies Left:   " + TotalEnemies;
    }


}
