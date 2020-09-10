using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSystem : MonoBehaviour
{
    private bool hasEnoughPoints;
    private bool dayHasEnded;
    private bool hasCompletedLevel;

<<<<<<< Updated upstream
    private float rotateSpeed = 30f;
=======
    private const float DAY_IN_SECONDS = 30f;
    private const float START_DAY_AT = 0.375f;
    private float day;
>>>>>>> Stashed changes
    private float dayTimer = 0f;
    private int currentTime;
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
    private ShopSystem shopScript;

    private void Awake()
    {
        day = START_DAY_AT;
        shopScript = UI.GetComponent<ShopSystem>();
        currentGoal = level1Goal;
    }

    private void Update()
    {
        currentScore = shopScript.GetMoney();
        CheckScoreGoal();
        addTime();
        setCurrentGoalAndLevel();
        UpdateDayCycle();
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
        shopScript.SetMoney(0);
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

    private void UpdateDayCycle()
    {
<<<<<<< Updated upstream
        DayNightCycle.transform.RotateAround(Vector3.zero, Vector3.back, rotateSpeed * Time.deltaTime);
        DayNightCycle.transform.LookAt(Vector3.zero);
=======
        day += Time.deltaTime / DAY_IN_SECONDS;
        float dayNormalized = day % 1f;
        float dayHours = 24f;
        float rot24Hrs = 360f;
        float rot12Hrs = 2 * rot24Hrs;
        float cycleOffset = 50f;


        hourHand.eulerAngles = new Vector3(0, 0, -dayNormalized * rot12Hrs);
        minuteHand.eulerAngles = new Vector3(0, 0, -dayNormalized * rot24Hrs * dayHours);

        float sunRotation = (-dayNormalized * rot24Hrs) - cycleOffset;

        DayNightCycle.transform.eulerAngles = new Vector3(sunRotation, 90, 0);

        if (sunRotation > 180f && sunRotation < 135f) currentTime = 1;
        if (sunRotation > 135f && sunRotation < 90f) currentTime = 2;
        if (sunRotation > 90f && sunRotation < 45f) currentTime = 3;
        if (sunRotation > 90f && sunRotation < 0f) currentTime = 4;
    }

    public float SetSpawnrate(float pValue)
    {
        pValue = currentTime;
        return pValue;
>>>>>>> Stashed changes
    }
}
