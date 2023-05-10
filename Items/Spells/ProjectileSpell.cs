using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldsEnd
{
    [CreateAssetMenu(menuName = "Spells/Projectile Spell")]
    public class ProjectileSpell : SpellItem
    {
        [Header("Projectile Damage")]
        public float baseDamage;

        [Header("Projectile Physics")]
        public float projectileVelocity;
        public float projectileUp;
        public float projectileMass;
        public bool isAffectedByGravity;
        Rigidbody rigidBody;



        private void Awake()
        {
            
        }

        public override void AttemptToCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats, WeaponSlotManager weaponSlot)
        {
            base.AttemptToCastSpell(animatorHandler, playerStats, weaponSlot);
            GameObject instantiatedWarmUpSpellFX = Instantiate(spellWarmUpFX, weaponSlot.rightHandSlot.transform);
            //instantiatedWarmUpSpellFX.gameObject.transform.localScale = new Vector3(100, 100, 100);
            animatorHandler.PlayTargetAnimation(spellAnimation, true);
        }

        public override void SuccessfullyCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats, WeaponSlotManager weaponSlot, CameraHandler cameraHandler)
        {
            base.SuccessfullyCastSpell(animatorHandler, playerStats, weaponSlot, cameraHandler);
          //  GameObject instantiatedSpellFX = Instantiate(spellCastFX, weaponSlot.rightHandSlot.transform.position, cameraHandler.cameraPivotTransform.rotation);
            GameObject instantiatedSpellFX = Instantiate(spellCastFX, weaponSlot.rightHandSlot.spellProjectionOverride.transform.position, cameraHandler.cameraPivotTransform.rotation);

            rigidBody = instantiatedSpellFX.GetComponent<Rigidbody>();

            if(cameraHandler.currentLockOnTarget != null)
            {
                instantiatedSpellFX.transform.LookAt(cameraHandler.currentLockOnTarget.transform);
            }
            else
            {
                instantiatedSpellFX.transform.rotation = Quaternion.Euler(cameraHandler.cameraPivotTransform.eulerAngles.x, playerStats.transform.eulerAngles.y, 0);
            }

            rigidBody.AddForce(instantiatedSpellFX.transform.forward * projectileVelocity);
            rigidBody.AddForce(instantiatedSpellFX.transform.up * projectileUp);
            rigidBody.useGravity = isAffectedByGravity;
            rigidBody.mass = projectileMass;
            instantiatedSpellFX.transform.parent = null;
        }
    }
}
