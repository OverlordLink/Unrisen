using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace WorldsEnd
{
    public class EnemyManager : CharacterManager
    {
        EnemyLocomotionManager enemyLocomotionManager;
        EnemyAnimatorManager enemyAnimationManager;
        EnemyStats enemyStats;

        public NavMeshAgent navMeshAgent;
        public CharacterStats currentTarget;
        public State currentState;

        public bool isPerformingAction;
        public bool isInteracting;
        public Rigidbody enemyRigidbody;

        public float rotationSpeed = 15f;
        
        public float maximumAttackRange = 2f;

        [Header ("AI Settings")]
        public float detectionRadius = 20;

        public float maximumDetectionAngle = 50;
        public float minimumDetectionAngle = -50;
 

        public float currentRecoveryTime = 0;

        private void Start()
        {

            enemyRigidbody.isKinematic = false;
        }

        private void Awake()
        {
            enemyLocomotionManager = GetComponent<EnemyLocomotionManager>();
            enemyAnimationManager = GetComponentInChildren<EnemyAnimatorManager>();
            enemyStats = GetComponent<EnemyStats>();
            navMeshAgent = GetComponentInChildren<NavMeshAgent>();
            navMeshAgent.enabled = false;
            enemyRigidbody = GetComponent<Rigidbody>();
        }
       
        private void FixedUpdate()
        {
            HandleStateMachine();
        }

        private void Update()
        {
            HandleRecoveryTimer();

            isInteracting = enemyAnimationManager.anim.GetBool("isInteracting");
        }

        private void HandleStateMachine()
        {
           if(currentState != null)
            {
                State nextState = currentState.Tick(this, enemyStats, enemyAnimationManager);

                if(nextState != null)
                {
                    SwitchToNextState(nextState);
                }
            }
        }

        private void SwitchToNextState(State state)
        {
            currentState = state;
        }

        private void HandleRecoveryTimer()
        {
            if (currentRecoveryTime > 0)
            {
                currentRecoveryTime -= Time.deltaTime;
            }

            if(isPerformingAction)
            {
                if(currentRecoveryTime <= 0)
                {
                    isPerformingAction = false;
                }
            }
        }

        #region Attacks

        #endregion
    }
}