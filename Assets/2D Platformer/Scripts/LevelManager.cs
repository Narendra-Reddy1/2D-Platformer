using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sovereign{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager instance;

        public GameObject respawnEffect;

        public string nextLevel;
        public float waitToRespawn;
        public int gemsCollected;

        private void Awake()
        {
            instance = this;
        }



        public void RespawnPlayer()
        {
            StartCoroutine(RespawnCo());
        }

        private IEnumerator RespawnCo()
        {
            PlayerController.instance.gameObject.SetActive(false);
            UI_Controller.instance.FadeToBlack();
            yield return new WaitForSeconds(waitToRespawn - (1 / UI_Controller.instance.fadeSpeed) + .2f);
            UI_Controller.instance.FadeFromBlack();

            PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
            Instantiate(respawnEffect, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);
            PlayerController.instance.gameObject.SetActive(true);
            PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.MaxHealth;
            UI_Controller.instance.updateHealthUI();

        }



        public void LevelEnd()
        {
            StartCoroutine(EndLevelCo());

        }


        private IEnumerator EndLevelCo()
        {

            FollowPlayer.instance.stopFollow = true;
            UI_Controller.instance.levelComplete.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            UI_Controller.instance.FadeToBlack();
            yield return new WaitForSeconds(1.5f);
            SceneManager.LoadScene(nextLevel);
        }
    }
}