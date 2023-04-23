using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sounds
{
    public class SoundScript : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip hurtSound;
        public AudioClip jumpSound;
        public AudioClip attackSound;

        void HurtSound()
        {
            audioSource.PlayOneShot(hurtSound);
        }

        void JumpSound()
        {
            audioSource.PlayOneShot(jumpSound);
        }

        void AttackSound()
        {
            audioSource.PlayOneShot(attackSound);
        }
    }
}