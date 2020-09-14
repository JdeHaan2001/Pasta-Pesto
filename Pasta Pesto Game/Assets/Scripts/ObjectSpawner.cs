using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public const int maxObjectAmount = 10;
    [SerializeField]
    private int _currentObjectAmount = 0;
    [SerializeField]
    private float _timer = 0f;
    private Animator anim;

    public float WaitTime = 5f;



    public GameObject SpawnObject;

    // Start is called before the first frame update
    void Start()
    {
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
                anim.Play("ThrowTrash", 0, 0.5f);
                spawnTrash();
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

        float pX = gameObject.transform.position.x + Random.Range(-2, 2);
        //float pY = SpawnObject.transform.localScale.y / 2;
        float pY = 0.08f;
        float pZ = gameObject.transform.position.z + Random.Range(-2, 2);

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
        SpawnObject.tag = "PickUp";
        _currentObjectAmount++;
        WaitTime = Random.Range(5f, 10f);
    }
}
