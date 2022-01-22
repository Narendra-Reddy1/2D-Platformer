using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sovereign
{
    public class MainMenu : MonoBehaviour
    {

        public string sceneName;

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void StartGame()
        {
            SceneManager.LoadScene(sceneName);
        }
        public void QuitGame()
        {
            Application.Quit();
            Debug.Log("Qutting Game");
        }
    }
}