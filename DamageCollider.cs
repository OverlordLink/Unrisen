using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace WorldsEnd
{
    public class DamageCollider : MonoBehaviour
    {
        BoxCollider damageCollider;
        public bool enabledOnStartUp = false;

        public int currentWeaponDamage = 25;

        private void Awake()
        {
            damageCollider = GetComponent<BoxCollider>();
            damageCollider.gameObject.SetActive(true);
            damageCollider.isTrigger = true;
            damageCollider.enabled = enabledOnStartUp;
        }

        public void EnableDamageCollider()
        {
            damageCollider.enabled = true;

        }

        public void DisableDamageCollider()
        {
            damageCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.tag == "Player")
            {
                PlayerStats playerStats = collision.GetComponent<PlayerStats>();
                

                if(playerStats != null)
                {
                    playerStats.TakeDamage(currentWeaponDamage);
                }
            }

            if(collision.tag == "Enemy")
            {
                EnemyStats enemyStats = collision.GetComponent<EnemyStats>();


                if (enemyStats != null)
                {
                    enemyStats.TakeDamage(currentWeaponDamage);
                }
            }
        }
    }
}