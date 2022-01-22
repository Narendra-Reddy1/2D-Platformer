using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sovereign
{
    public class LevelSelect : MonoBehaviour
    {
        public static LevelSelect levelSelectInstance;

        public LevelSelect up, down, left, right;
        public bool isLevel;
        public string levelToLoad;


        private void Awake()
        {
            levelSelectInstance = this;
        }
        void Start()
        {

        }


        void Update()
        {

        }
    }
}