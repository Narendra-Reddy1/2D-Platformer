using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Sovereign
{

    public class UI_Controller : MonoBehaviour
    {
        public static UI_Controller instance;

        public float fadeSpeed;
        private bool fadeToBlack, fadeFromBlack;

        public Image fadeScreen;
        public Image heart_1, heart_2, heart_3;
        public Sprite heartFull, heartEmpty, halfHart;
        public GameObject levelComplete;
        [SerializeField] private Text gemText;


        private void Awake()
        {
            instance = this;
            gemText = GetComponentInChildren<Text>();
        }


        void Start()
        {

        }


        void Update()
        {
            if (fadeToBlack)
            {
                fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1.0f, fadeSpeed * Time.deltaTime));
                if (fadeScreen.color.a == 1f)
                {
                    fadeToBlack = false;
                }

            }
            if (fadeFromBlack)
            {
                fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));
                if (fadeScreen.color.a == 0f)
                {
                    fadeFromBlack = false;
                }

            }

        }

        public void updateHealthUI()
        {
            switch (PlayerHealthController.instance.currentHealth)
            {

                case 6:
                    heart_1.sprite = heartFull;
                    heart_2.sprite = heartFull;
                    heart_3.sprite = heartFull;
                    break;
                case 5:
                    heart_1.sprite = heartFull;
                    heart_2.sprite = heartFull;
                    heart_3.sprite = halfHart;
                    break;


                case 4:
                    heart_1.sprite = heartFull;
                    heart_2.sprite = heartFull;
                    heart_3.sprite = heartEmpty;
                    break;
                case 3:
                    heart_1.sprite = heartFull;
                    heart_2.sprite = halfHart;
                    heart_3.sprite = heartEmpty;
                    break;

                case 2:
                    heart_1.sprite = heartFull;
                    heart_2.sprite = heartEmpty;
                    heart_3.sprite = heartEmpty;
                    break;

                case 1:
                    heart_1.sprite = halfHart;
                    heart_2.sprite = heartEmpty;
                    heart_3.sprite = heartEmpty;
                    break;

                case 0:
                    heart_1.sprite = heartEmpty;
                    heart_2.sprite = heartEmpty;
                    heart_3.sprite = heartEmpty;
                    break;

                default:
                    heart_1.sprite = heartEmpty;
                    heart_2.sprite = heartEmpty;
                    heart_3.sprite = heartEmpty;
                    break;

            }

        }

        public void UpdateGemsUI()
        {
            gemText.text = LevelManager.instance.gemsCollected.ToString();

        }
        public void FadeToBlack()
        {
            fadeToBlack = true;
            fadeFromBlack = false;
        }
        public void FadeFromBlack()
        {
            fadeFromBlack = true;
            fadeToBlack = false;
        }


    }

}