using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sovereign
{
    public class Pickups : MonoBehaviour
    {
        public GameObject collectEffect;
        private Animator Anim;

        public bool isGem, isHeal;
        private bool isCollected;
        // Start is called before the first frame update
        void Start()
        {

            Anim = GetComponent<Animator>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && !isCollected)
            {
                if (isGem)
                {
                    LevelManager.instance.gemsCollected++;
                    AudioManager.instance.playSFX(6);
                    Destroy(gameObject);
                    isCollected = true;
                    Instantiate(collectEffect, transform.position, transform.rotation);
                    UI_Controller.instance.UpdateGemsUI();
                }
                if (isHeal)
                {
                    if (PlayerHealthController.instance.currentHealth < PlayerHealthController.instance.MaxHealth)
                    {

                        PlayerHealthController.instance.HealPlayer();
                        AudioManager.instance.playSFX(7);
                        isCollected = true;
                        Destroy(gameObject);
                        Instantiate(collectEffect, transform.position, transform.rotation);
                    }
                }

            }

        }



    }
}