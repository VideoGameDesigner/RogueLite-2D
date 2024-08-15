using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BossHealthSystem : MonoBehaviour
{
    [SerializeField] Image Bosshealthbar;
    [SerializeField] float Bosshealthamount = 400;
    private float BossMaxHealth;
    [SerializeField] private TextMeshProUGUI BossHealthText;
    public static bool BossDied = false;
    public static bool BossChange = false;

    public static BossHealthSystem instance;


    private void Awake()
    {
        if(instance == null) 
        {
            instance = this;
        
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        BossMaxHealth = Bosshealthamount;
    }

    // Update is called once per frame
    void Update()
    {
        BossHealthText.text = "Boss HealthBar:  " + Bosshealthamount;

        StartCoroutine(BossDefeatDelay());

        if ((Bosshealthamount/BossMaxHealth) <= 0.5)
        {
            BossChange = true;
        }
        

    }

    public void BossTakeDamage(float Bossdamage)
    {
        Bosshealthamount -= Bossdamage;
        Bosshealthamount = Mathf.Clamp(Bosshealthamount, 0, BossMaxHealth);
        Bosshealthbar.fillAmount = Bosshealthamount/ BossMaxHealth;
        BossHealthText.text = "Boss HealthBar:  " + Bosshealthamount;
    }

    private IEnumerator BossDefeatDelay()
    {       
        if (Bosshealthamount <= 0)
        {
            BossDied = true;
            yield return new WaitForSeconds(6);            
            SceneSwitcher.Instance.NextScene();
        }
    }

}
