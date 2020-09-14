using UnityEngine;
using System.Collections.Generic;

public class ObjectSpawner : MonoBehaviour
{
    public const int maxObjectAmount = 10;

    public List<GameObject> SpawnList;

    [SerializeField]
    private int _currentObjectAmount = 0;
    [SerializeField]
    private float _timer = 0f;
    private Animator anim;
    private AIMovement AIMove;

    public float WaitTime = 5f;

    //private GameObject SpawnObject;

    // Start is called before the first frame update
    void Start()
    {
        AIMove = GetComponent<AIMovement>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= WaitTime)
        {
            _timer = 0f;
            if (_currentObjectAmount < maxObjectAmount)
            {
                anim.Play("Throw", 0, 0.5f);
                spawnTrash();
                AIMove.SetMoveDirection(Vector3.zero);
                if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("Walking"))
                {
                    AIMove.SetMoveDirection(new Vector3(Random.Range(-1, 2) * AIMove.Speed, 0, Random.Range(-1, 2) * AIMove.Speed));
                }
            }
        }
    }

    /// <summary>
    /// Setter for _currentObjectAmound. Paramater is the amound that is subtracted from the curren value
    /// </summary>
    /// <param name="pAmound"></param>
    public void SetObjectAmount(int pAmound)
    {
        _currentObjectAmount -= pAmound;
    }

    private void spawnTrash()
    {
        GameObject SpawnObject = SpawnList[Random.Range(0, SpawnList.Count - 1)];
        float pX = gameObject.transform.position.x;
        //float pY = SpawnObject.transform.localScale.y / 2;
        float pY = 0.08f;
        float pZ = gameObject.transform.position.z;

        float distance = Vector3.Distance(SpawnObject.transform.position, gameObject.transform.position);

        if (distance < pY)
        {
            if (distance > 0)
            {
                pX += pY;
                pZ += pY;
            }
            else
            {
                pX -= pY;
                pZ -= pY;
            }
        }

        Instantiate(SpawnObject, new Vector3(pX, pY, pZ), Quaternion.identity);
        _currentObjectAmount++;
        WaitTime = Random.Range(5f, 10f);
    }
}
