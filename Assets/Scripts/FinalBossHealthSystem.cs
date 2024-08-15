using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class FinalBossHealthSystem : MonoBehaviour
{

    [SerializeField] Image FinalBosshealthbar;
    [SerializeField] float FinalBosshealthamount = 1000;
    private float FinalBossMaxHealth;
    [SerializeField] private TextMeshProUGUI FinalBossHealthText;
    //public static bool VictoryON = false;
    [SerializeField] private GameObject VictoryScreen;
    public static bool FinalBossDied = false;
    public static bool FinalBossChange = false;


    public static FinalBossHealthSystem instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        VictoryScreen.SetActive(false);
        FinalBossMaxHealth = FinalBosshealthamount;
    }

    // Update is called once per frame
    void Update()
    {
        FinalBossHealthText.text = "Final Boss HealthBar:  " + FinalBosshealthamount;

        if ((FinalBosshealthamount / FinalBossMaxHealth) <= 0.5)
        {
            FinalBossChange = true;
        }

        StartCoroutine(BossDefeatDelay());

    }

    public void FinalBossTakeDamage(float FinalBossdamage)
    {
        FinalBosshealthamount -= FinalBossdamage;
        FinalBosshealthamount = Mathf.Clamp(FinalBosshealthamount, 0, FinalBossMaxHealth);
        FinalBosshealthbar.fillAmount = FinalBosshealthamount / FinalBossMaxHealth;
        FinalBossHealthText.text = "Final Boss HealthBar:  " + FinalBosshealthamount;
    }


    private IEnumerator BossDefeatDelay()
    {
        if (FinalBosshealthamount <= 0)
        {
            FinalBossDied = true;
            yield return new WaitForSeconds(6);
            VictoryScreen.SetActive(true);
            
        }
    }

    public void StartOver()
    {
        if (FinalBossDied == true)
        {                       
            SceneSwitcher.Instance.Restart();

        }
    }




}
