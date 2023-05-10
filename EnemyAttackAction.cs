using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldsEnd
{

    [CreateAssetMenu(menuName = "AI/Enemy Action/AttackAction")]
    public class EnemyAttackAction : EnemyAction
    {
        public int attackScore = 3;
        public float recoveryTime = 2;

        public float maximumAttackAngle = 35;
        public float minimumAttackAngle = -35;

        public float minDistanceToAttack = 0;
        public float maxDistanceToAttack = 3;
    }
}
