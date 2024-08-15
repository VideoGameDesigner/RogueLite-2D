using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static bool TimerActive = true;
    [SerializeField] private TextMeshProUGUI TimeText;
    [SerializeField] private float TimeValue = 90;  

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerRunner();
        
    }


    void TimerRunner()
    {

        if (TimerActive == true)
        {
            TimeValue -= Time.deltaTime;

            if (TimeValue <=0)
            {
                
                SceneSwitcher.Instance.NextScene();
                
            }

        }



        DisplayTime(TimeValue);
    }

    void DisplayTime(float TimeToDisplay)
    {
        if (TimeToDisplay < 0)
        {
            TimeToDisplay = 0;
        }

        else if (TimeToDisplay > 0)
        {
            TimeToDisplay += 1;
        }



        float minutes = Mathf.FloorToInt(TimeToDisplay / 60);
        float seconds = Mathf.FloorToInt(TimeToDisplay % 60);

        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        TimeText.text = "Time Left:  "+ formattedTime;
    }






}
