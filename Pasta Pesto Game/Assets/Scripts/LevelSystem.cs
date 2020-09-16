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

    private const float DAY_IN_SECONDS = 360f;
    private float day;
    private int currentLevel = 1;
    private float COUNTDOWN_TIMER = 180f;
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
    public GameObject Clock;
    private ShopSystem shopScript;
    private Transform hourHand;
    private Transform minuteHand;
    private TextMeshProUGUI clockTime;

    private void Awake()
    {
        day += 0.375f;

        shopScript = UI.GetComponent<ShopSystem>();
        currentGoal = level1Goal;

        hourHand = Clock.transform.Find("hourHand");
        minuteHand = Clock.transform.Find("minuteHand");
        clockTime = Clock.transform.Find("clockTime").GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        currentScore = shopScript.GetMoney();
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
        hasCompletedLevel = false;
        dayHasEnded = false;
        hasEnoughPoints = false;
        shopScript.ResetMoney();
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

    public void SetClockTime(float pTime)
    {
        COUNTDOWN_TIMER = pTime;
    }

    public float GetClockTime()
    {
        return COUNTDOWN_TIMER;
    }
}
