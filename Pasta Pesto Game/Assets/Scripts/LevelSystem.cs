using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    private bool hasEnoughPoints;
    private bool dayHasEnded;
    private bool hasCompletedLevel;

    private const float DAY_IN_SECONDS = 15f;
    private float day;
    private float rotateSpeed = 30f;
    private float dayTimer = 0f;
    private int currentLevel = 1;
    private int dayLength = 12000;
    // Level scores - ADJUST WHERE NEEDED
    private int level1Goal = 50;
    private int level2Goal = 125;
    private int level3Goal = 250;
    private int level4Goal = 750;
    private int level5Goal = 1250;

    private int currentGoal;

    private float currentScore;

    public GameObject DayNightCycle;
    public GameObject UI;
    public GameObject Clock;
    private ShopSystem shopScript;
    private Transform hourHand;
    private Transform minuteHand;

    private void Awake()
    {
        shopScript = UI.GetComponent<ShopSystem>();
        currentGoal = level1Goal;

        hourHand = Clock.transform.Find("hourHand");
        minuteHand = Clock.transform.Find("minuteHand");
    }

    private void Update()
    {
        currentScore = shopScript.GetMoney();
        CheckScoreGoal();
        addTime();
        setCurrentGoalAndLevel();

        UpdateClock();
    }

    private void addTime()
    {
        if(!dayHasEnded) dayTimer += (1f * Time.deltaTime);
        if(dayTimer >= dayLength) dayHasEnded = true;
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
        dayTimer = 0f;
    }

    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    private void setTimeToGoal()
    {
        Debug.Log("Set time to: 17500");
        if (Input.GetKeyDown(KeyCode.N)) dayTimer = 18500;
    }

    private void UpdateClock()
    {
        day += Time.deltaTime / DAY_IN_SECONDS;
        float dayNormalized = day % 1f;
        float dayHours = 24f;
        float dayRotation = 360f;
        float cycleOffset = 50f;

        hourHand.eulerAngles = new Vector3(0, 0, -dayNormalized * (dayRotation*2));
        minuteHand.eulerAngles = new Vector3(0, 0, -dayNormalized * dayRotation * dayHours);
        DayNightCycle.transform.eulerAngles = new Vector3((-dayNormalized * dayRotation) -cycleOffset, 90, 0);
    }
}
