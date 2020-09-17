using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    class TextbarMovement : MonoBehaviour
    {
        public GameObject player;



        private void Start()
        {
            
        }

        private void Update()
        {
            Vector3 playerPos = player.transform.position;
            float SpaceY = playerPos.y + 1.5f;
            Vector3 SpaceBarPos = new Vector3(playerPos.x, SpaceY, playerPos.z);
            gameObject.transform.position = SpaceBarPos;
            gameObject.SetActive(false);
        }


        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Enemy") && gameObject.name == "SpaceBar")
            {
                gameObject.SetActive(true);
            }
            if (other.CompareTag("Trashcan") && gameObject.name == "E") 
            {
                gameObject.SetActive(true);
            }
        }

    }
}
