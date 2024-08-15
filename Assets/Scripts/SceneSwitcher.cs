using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public static SceneSwitcher Instance;
   


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
        
    }

    public void Restart()
    {
        FinalBossHealthSystem.FinalBossDied = false;
        BossHealthSystem.BossDied = false;
        GameManager.Instance.ResetStartPosition();
        SceneManager.LoadScene("Level_1");                 
    }

    public void NextScene()
    {
        FinalBossHealthSystem.FinalBossDied = false;
        BossHealthSystem.BossDied = false;
        GameManager.Instance.ResetStartPosition();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }





}
