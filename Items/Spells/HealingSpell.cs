using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldsEnd
{
    [CreateAssetMenu(menuName = "Spells/Healing Spell")]
    public class HealingSpell : SpellItem
    {
        public int healAmount;

        public override void AttemptToCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats, WeaponSlotManager weaponSlot)
        {
            base.AttemptToCastSpell(animatorHandler, playerStats, weaponSlot);
            GameObject instantiatedWarmUpSpellFX = Instantiate(spellWarmUpFX, animatorHandler.transform);
            animatorHandler.PlayTargetAnimation(spellAnimation, true);
            Debug.Log("Attempting to cast spell...");
        }
        
        public override void SuccessfullyCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats, WeaponSlotManager weaponSlot, CameraHandler cameraHandler)
        {
            base.SuccessfullyCastSpell(animatorHandler, playerStats, weaponSlot, cameraHandler);
            GameObject instantiatedSpellFX = Instantiate(spellCastFX, animatorHandler.transform);
            playerStats.HealPlayer(healAmount);
            Debug.Log("Spell cast successful");
        }

    }
}
