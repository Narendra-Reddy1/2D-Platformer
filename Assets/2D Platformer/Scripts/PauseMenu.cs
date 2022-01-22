using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Sovereign
{
    public class PauseMenu : MonoBehaviour
    {
        public static PauseMenu instance;

        public string levelSelect, mainMenu;
        public bool isPaused;

        [SerializeField] private GameObject pauseMenu;

        private void Awake()
        {
            instance = this;

        }
        void Start()
        {

        }



        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) ResumeGame();
        }

        public void ResumeGame()
        {
            if (isPaused)
            {
                pauseMenu.SetActive(false);
                isPaused = false;
                Time.timeScale = 1.0f;
            }
            else
            {
                isPaused = true;
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        public void SelectLevel()
        {
            SceneManager.LoadScene(levelSelect);
            Time.timeScale = 1.0f;
        }

        public void MainMenu()
        {
            SceneManager.LoadScene(mainMenu);
            Time.timeScale = 1.0f;
        }

    }
}