using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sovereign
{
    public class LSManager : MonoBehaviour
    {
        public static LSManager lsManagerInstance;

        private void Awake()
        {
            lsManagerInstance = this;
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void LoadLevel()
        {
            StartCoroutine(LoadLevelCo());

        }

        IEnumerator LoadLevelCo()
        {


            LSUIManager.lsUIManagerInstance.FadeToBlack();
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(LSPlayer.lsPlayerInstance.currentPoint.levelToLoad);
        }
    }
}