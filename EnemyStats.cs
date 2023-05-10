using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldsEnd
{
    public class EnemyStats : CharacterStats
    {
      //  public int healthLevel;
      //  public int maxHealth;
      //  public int currentHealth;

        public HealthBar healthbar;

        public UIEnemyHealthBar enemyHealthBar;

        public AudioSource fleshHit;

        Animator animator;

        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();

        }

        void Start()
        {
            maxHealth = SetMaxHealthFromHealthLevel();
            currentHealth = maxHealth;
            enemyHealthBar.SetMaxHealth(maxHealth);
          
        }

        private int SetMaxHealthFromHealthLevel()
        {
            maxHealth = healthLevel * 10;
            return maxHealth;
        }

        public void TakeDamage(int damage)
        {
            if(isDead)
                return;
            currentHealth = currentHealth - damage;
            

            enemyHealthBar.SetHealth(currentHealth);


            animator.Play("Damage_01");

            fleshHit.Play();

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animator.Play("Dead_01");
            }
        }

    }
}