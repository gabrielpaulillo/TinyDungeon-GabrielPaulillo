using UnityEngine;

namespace TinyDungeon
{
    [RequireComponent(typeof(ParticleSystem))]
    public class DeathEffect : MonoBehaviour
    {
        private new ParticleSystem particleSystem;

        private void Start()
        {
            particleSystem = GetComponent<ParticleSystem>();
        }

        public void Play(AudioClip audioClip)
        {
            particleSystem.Play();
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
        }
    } 
}
