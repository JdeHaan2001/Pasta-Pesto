using UnityEngine;

public class MenuSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Music");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            FindObjectOfType<AudioManager>().Play("MouseClick");
    }
}
