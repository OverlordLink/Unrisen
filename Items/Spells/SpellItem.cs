using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldsEnd
{


    public class SpellItem : Item
    {
        public GameObject spellWarmUpFX;
        public GameObject spellCastFX;
        public string spellAnimation;

        [Header("Spell Type")]
        public bool isFaithSpell;
        public bool isMagicSpell;
        public bool isPyroSpell;

        [Header("Spell Description")]
        [TextArea]
        public string spellDescription;

        public virtual void AttemptToCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats, WeaponSlotManager weaponSlot)
        {
            Debug.Log("You attempt to cast a spell!");
        }

        public virtual void SuccessfullyCastSpell(AnimatorHandler animatorHandler, PlayerStats playerStats, WeaponSlotManager weaponSlot, CameraHandler cameraHandler)
        {
            Debug.Log("You successfully cast a spell!");
        }
    }
}
