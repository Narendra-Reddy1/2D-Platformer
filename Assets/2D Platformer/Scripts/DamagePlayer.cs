﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Sovereign
{
    public class DamagePlayer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {

                PlayerHealthController.instance.DealDamage();
            }
        }
    }
}