using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sovereign
{


    public class StompBox : MonoBehaviour
    {

        [SerializeField] [Range(1, 50)] private int chanceToGet;

        public GameObject deathEffect;
        public GameObject collectible;

        void Start()
        {

        }


        void Update()
        {

        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.transform.parent.gameObject.SetActive(false);
                AudioManager.instance.playSFX(3);
                Instantiate(deathEffect, other.transform.position, other.transform.rotation);

                float randChance = Random.Range(0, 100f);
                if (randChance <= chanceToGet)
                {
                    Instantiate(collectible, other.transform.position, other.transform.rotation);
                }
                AudioManager.instance.playSFX(10);
                PlayerController.instance.Bounce();


            }
        }
    }
}