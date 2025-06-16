using UnityEngine;

namespace TinyDungeon
{
    public class PlayerDeathEffect : MonoBehaviour
    {
        [SerializeField]
        private DeathEffect deathFx;

        [SerializeField]
        private AudioClip audioClip;

        public void Play()
        {
            deathFx.transform.position = transform.position;
            deathFx.Play(audioClip);
        }
    }
}