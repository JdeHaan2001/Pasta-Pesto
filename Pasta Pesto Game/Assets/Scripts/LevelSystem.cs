using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelSystem : MonoBehaviour
{
    private bool hasEnoughPoints;
    private bool dayHasEnded;
    private bool hasCompletedLevel;
    private bool hasProperStarted = false;

    private float COUNTDOWN_TIMER = 180f; // The length of the level => 1f = 1 second.
    private float DAY_IN_SECONDS;
    private float day;
    private float startTimer;
    private int currentLevel = 1;
    // Level scores - ADJUST WHERE NEEDED
    private int level1Goal = 30;
    private int level2Goal = 50;
    private int level3Goal = 100;
    private int level4Goal = 150;
    private int level5Goal = 500;

    private int currentGoal;
    private float currentScore;

    public GameObject DayNightCycle;
    public GameObject UI;
    public GameObject player;
    public Transform Panel;
    public GameObject TutorialScreen;
    private Transform clock;
    private Transform LevelCounter;
    private Transform hourHand;
    private Transform minuteHand;
    private ShopSystem shopSystem;
    private TextMeshProUGUI clockTime;

    private void Awake()
    {
        DAY_IN_SECONDS = (COUNTDOWN_TIMER * 2);
        day += 0.375f;

        shopSystem = UI.GetComponent<ShopSystem>();
        currentGoal = level1Goal;
        Panel = UI.transform.Find("Panel");
        clock = Panel.Find("Clock");
        hourHand = clock.Find("hourHand");
        minuteHand = clock.Find("minuteHand");
        clockTime = clock.Find("clockTime").GetComponent<TextMeshProUGUI>();
        LevelCounter = Panel.Find("currentLevel");

        LevelCounter.GetComponent<TextMeshProUGUI>().SetText("Level " + currentLevel.ToString());
    }

    private void Update()
    {
        if (!hasProperStarted)
        {
            startOfLevel();
        }


        //currentScore = shopScript.GetMoney();
        currentScore = shopSystem.GetTotalEarned();
        CheckScoreGoal();
        checkEndDay();
        setCurrentGoalAndLevel();

        UpdateClock();
        clockTime.SetText(COUNTDOWN_TIMER.ToString("0"));
    }

    private void setCurrentGoalAndLevel()
    {
        switch (currentLevel)
        {
            case 1:
                currentGoal = level1Goal;
                if(hasCompletedLevel)
                {
                    ChangeScene("Level_2");
                    resetSettings();
                    currentLevel = 2;
                }
                else if(dayHasEnded && !hasCompletedLevel)
                {
                    ChangeScene("_LoseScreen");
                    resetSettings();
                }
                break;
            case 2:
                currentGoal = level2Goal;
                if (hasCompletedLevel)
                {
                    ChangeScene("Level_3");
                    resetSettings();
                    currentLevel = 3;
                }
                else if (dayHasEnded && !hasCompletedLevel)
                {
                    ChangeScene("_LoseScreen");
                    resetSettings();
                }
                break;
            case 3:
                currentGoal = level3Goal;
                if (hasCompletedLevel)
                {
                    ChangeScene("Level_4");
                    resetSettings();
                    currentLevel = 4;
                }
                else if (dayHasEnded && !hasCompletedLevel)
                {
                    ChangeScene("_LoseScreen");
                    resetSettings();
                }
                break;
            case 4:
                currentGoal = level4Goal;
                if (hasCompletedLevel)
                {
                    ChangeScene("Level_5");
                    resetSettings();
                    currentLevel = 5;
                }
                else if (dayHasEnded && !hasCompletedLevel)
                {
                    ChangeScene("_LoseScreen");
                    resetSettings();
                }
                break;
            case 5:
                currentGoal = level5Goal;
                if (hasCompletedLevel)
                {
                    ChangeScene("_VictoryScreen");
                    resetSettings();
                }
                else if (dayHasEnded && !hasCompletedLevel)
                {
                    ChangeScene("_LoseScreen");
                    resetSettings();
                }
                break;
                
        };
    }

    private void CheckScoreGoal()
    {
        if (currentScore >= currentGoal) hasEnoughPoints = true;
        else if (currentScore < currentGoal) hasEnoughPoints = false;
    }

    private void resetSettings()
    {
        startTimer = 0f;
        startOfLevel();
        hasCompletedLevel = false;
        dayHasEnded = false;
        hasEnoughPoints = false;
        shopSystem.ResetMoney();
    }

    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    private void UpdateClock()
    {
        COUNTDOWN_TIMER -= Time.deltaTime;

        day += Time.deltaTime / DAY_IN_SECONDS;
        float dayNormalized = day % 1f;
        float dayHours = 24f;
        float rot12Hrs = 360f;
        float rot24Hrs = 720f;
        float cycleOffset = 50f;

        hourHand.eulerAngles = new Vector3(0, 0, -dayNormalized * rot24Hrs);
        minuteHand.eulerAngles = new Vector3(0, 0, -dayNormalized * rot12Hrs * dayHours);

        float daylightRot = (-dayNormalized * rot12Hrs) - cycleOffset;

        DayNightCycle.transform.eulerAngles = new Vector3(daylightRot, 90, 0);
    }

    private void checkEndDay()
    {
        if (day >= 0.875f) dayHasEnded = true;
        if (dayHasEnded && hasEnoughPoints) hasCompletedLevel = true;
    }

    public void SetDayTime(float pDay)
    {
        day = pDay;
    }

    public float GetDayTime()
    {
        return day;
    }


    public void SetCurrentGoal(int pGoal)
    {
        currentGoal = pGoal;
    }

    public int GetCurrentGoal()
    {
        return currentGoal;
    }

    public void SetClockTime(float pTime)
    {
        COUNTDOWN_TIMER = pTime;
    }

    public float GetClockTime()
    {
        return COUNTDOWN_TIMER;
    }

    private void startOfLevel()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TutorialScreen.SetActive(false);
            hasProperStarted = true;
        }
    }



}

