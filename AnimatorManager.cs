using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorldsEnd 
{
    public class AnimatorManager : MonoBehaviour
    {
        public Animator anim;
        public void PlayTargetAnimation(string targetAnim, bool isInteracting)
        {
            anim.SetBool("isInteracting", isInteracting);
            anim.applyRootMotion = isInteracting;
            anim.CrossFade(targetAnim, 0.2f);

        }
    }
}
