using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sovereign
{
    public class PlayerHealthController : MonoBehaviour
    {
        public static PlayerHealthController instance;
        public GameObject deathEffect;

        public int currentHealth, MaxHealth;
        public float invincibleLength;
        private float invincibleCounter;

        private SpriteRenderer sr;

        private void Awake()
        {
            instance = this;
        }


        void Start()
        {
            sr = GetComponent<SpriteRenderer>();

            currentHealth = MaxHealth;
        }


        void Update()
        {
            if (invincibleCounter > 0)
            {
                invincibleCounter -= Time.deltaTime;
                if (invincibleCounter <= 0)
                {
                    sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
                }
            }
        }
        public void DealDamage()
        {
            if (invincibleCounter <= 0)
            {


                currentHealth--;

                if (currentHealth <= 0)
                {
                    Instantiate(deathEffect, transform.position, transform.rotation);
                    AudioManager.instance.playSFX(8);
                    LevelManager.instance.RespawnPlayer();
                }
                else
                {
                    AudioManager.instance.playSFX(9);
                    invincibleCounter = invincibleLength;
                    sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, .5f);
                    PlayerController.instance.KnockBack();
                }

                UI_Controller.instance.updateHealthUI();

            }

        }
        public void HealPlayer()
        {
            currentHealth++;

            if (currentHealth > MaxHealth)
            {
                currentHealth = MaxHealth;
            }

            UI_Controller.instance.updateHealthUI();
        }
    }
}