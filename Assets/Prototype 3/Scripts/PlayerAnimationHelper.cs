using UnityEngine;

namespace Prototype_3.Scripts
{
    public class PlayerAnimationHelper : MonoBehaviour
    {
        public GameObject rightFootPointer;
        public GameObject leftFootPointer;
        
        public AudioClip[] footstepClips;
        
        public GameObject stepParticleEffect;
        
        public PlayerController playerController;
        
        //! 0 is right 1 is left
        public void Step(int step)
        {
            if (!playerController.isOnGround || playerController.gameOver)
            {
                return;
            }
            if (step == 0)
            {
                int index = Random.Range(0, footstepClips.Length);
                AudioSource.PlayClipAtPoint(footstepClips[index], rightFootPointer.transform.position);
                Instantiate(stepParticleEffect, rightFootPointer.transform.position, stepParticleEffect.transform.rotation);
            }
            else
            {
                int index = Random.Range(0, footstepClips.Length);
                AudioSource.PlayClipAtPoint(footstepClips[index], leftFootPointer.transform.position);
                Instantiate(stepParticleEffect, leftFootPointer.transform.position, stepParticleEffect.transform.rotation);
            }
        }
    }
}
