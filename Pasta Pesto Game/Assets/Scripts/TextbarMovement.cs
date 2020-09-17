using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts
{
    class TextbarMovement : MonoBehaviour
    {
        public GameObject SpacebarText;
        public GameObject EText;

        private void Start()
        {
            SpacebarText.SetActive(false);
            EText.SetActive(false);
        }


        private void Update()
        {
            Vector3 playerPos = gameObject.transform.position;
            float SpaceY = playerPos.y + 1.5f;
            Vector3 SpaceBarPos = new Vector3(playerPos.x, SpaceY, playerPos.z);
            SpacebarText.transform.position = SpaceBarPos;
            EText.transform.position = SpaceBarPos;
        }


        private void OnTriggerStay(Collider other)
        {
            Debug.Log("HIT");
            if (other.CompareTag("Enemy") && SpacebarText.name == "SpaceBar")
            {
                SpacebarText.SetActive(true);
            }
            else  if (other.CompareTag("Trashcan") && EText.name == "E")
            {
                EText.SetActive(true);
            }
         
        }

        private void OnTriggerExit(Collider other)
        {
            EText.SetActive(false);
            SpacebarText.SetActive(false);
        }

    }
}
