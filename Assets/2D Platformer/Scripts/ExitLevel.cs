using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sovereign
{
    public class ExitLevel : MonoBehaviour
    {


        void Start()
        {

        }


        void Update()
        {

        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                LevelManager.instance.LevelEnd();
            }
        }
    }
}