using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] Image healthbar;
    [SerializeField] float healthamount = 100;
    private float MaxHealth;
    [SerializeField] private TextMeshProUGUI HealthText;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject PauseScreen;
    public static bool isPaused;
    public static bool Dead;
    
    
    
    public static GameManager Instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
      
                             
    }

    private void Start()
    {
               
        MaxHealth = healthamount;
        GameOverScreen.SetActive(false);
        player.transform.position = new Vector3(-7, 0, 0);
        PauseScreen.SetActive(false);

    }


    private void Update()
    {
     
        HealthText.text = "Player HealthBar:  " + healthamount;

        if(healthamount <= 0& !Dead)
        {
           Dead = true;
           player.SetActive(false);        
           GameOverScreen.SetActive (true);
           healthamount = MaxHealth;
           healthbar.fillAmount = healthamount;
           player.transform.position = new Vector3(-7,0,0);
                                      
           Debug.Log("Gameover");
        }

        if(Keyboard.current.pKey.wasPressedThisFrame)
        {
            if(isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        
                              
       
    }

    public void TakeDamage(float damage)
    {
        healthamount -= damage;
        healthamount = Mathf.Clamp(healthamount, 0, MaxHealth);
        healthbar.fillAmount = healthamount /MaxHealth;
        HealthText.text = "HealthBar:  " + healthamount;
    }

    public void RegainHealh(float heal)
    { 
        healthamount += heal;
        healthamount = Mathf.Clamp(healthamount, 0, MaxHealth);
        healthbar.fillAmount = healthamount /MaxHealth;
        HealthText.text = "HealthBar:  " + healthamount;

    }

    public void IncreaseHealth(float morehealth)
    {
        healthamount += morehealth;
        MaxHealth += morehealth;
        healthamount = MaxHealth;
        healthbar.fillAmount = healthamount;

    }

    public void GameoverOff()
    {
        if(Dead == true)
        {
            Dead = false;
            player.SetActive(true);
            GameOverScreen.SetActive(false);
            SceneSwitcher.Instance.Restart();
        }
    }

    public void ResetStartPosition()
    {
        player.transform.position = new Vector3(-7, 0, 0);
    }

    public void PauseGame ()
    {
        PauseScreen.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        PauseScreen.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

}
