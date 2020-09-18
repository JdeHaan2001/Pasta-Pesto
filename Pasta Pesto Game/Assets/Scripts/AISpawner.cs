using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    private List<GameObject> enemyList = new List<GameObject>();
    private List<GameObject> goodGuyList = new List<GameObject>();
    [SerializeField]
    private float waitAmount;
    [SerializeField]
    private float timer;
    [SerializeField]
    private int enemyTotal = 0;

    public GameObject EnemyObj;
    public GameObject GoodGuyObj;

    public int MinEnemyAmount = 3;
    public int MaxEnemyAmount = 5;

    public float MapBoundXMin = -13.2f;
    public float MapBoundXMax = 13.2f;
    public float MapBoundZMin = -450f;
    public float MapBoundZMax = 450f;
    public float MinWaitTime = 5f;
    public float MaxWaitTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        waitAmount = Random.Range(MinWaitTime, MaxWaitTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTotal < MaxEnemyAmount)
        {
            timer += Time.deltaTime;
            if (timer >= waitAmount)
            {
                spawnEnemy();
                timer = 0f;
            }
        }
        else if (enemyTotal < MinEnemyAmount)
        {
            spawnEnemy();
        }
    }

    private void spawnEnemy()
    {
        enemyList.Add(Instantiate(EnemyObj, new Vector3(Random.Range(MapBoundXMin, MapBoundXMax), 0, Random.Range(MapBoundZMin, MapBoundZMax)), Quaternion.identity));
        enemyTotal++;
    }

    public void spawnGoodGuy()
    {
        goodGuyList.Add(Instantiate(GoodGuyObj, new Vector3(Random.Range(MapBoundXMin, MapBoundXMax), 0, Random.Range(MapBoundZMin, MapBoundZMax)), Quaternion.identity));
    }

    public void RemoveEnemyFromList(GameObject pEnemy)
    {
        enemyList.Remove(pEnemy);
    }

    public void SetEnemyTotal(int pAmount = -1)
    {
        enemyTotal += pAmount;
    }
}
