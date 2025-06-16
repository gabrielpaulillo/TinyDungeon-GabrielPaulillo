using UnityEngine;
using UnityEngine.Events;

namespace TinyDungeon
{
    [RequireComponent(typeof(Collider2D))]
    public class Damageable : MonoBehaviour
    {
        public UnityEvent OnHit;
        public UnityEvent OnDeath;

        [SerializeField]
        private int life = 1;

        // O jogador tem "life" igual 1
        // O método "Hit()" foi chamado tendo como parâmetro 1 (dano do morcego)
        // 1-1 = 0
        // Logo, o UnityEvent OnDeath() é invocado, e sua ação é definida no Editor/Inspector. 
        // Ex.: No OnDeath do jogador, o gameObject do jogador SetActive(false).
        public void Hit(int value)
        {
            life -= value;

            if (life > 0)
                OnHit?.Invoke();
            else
                OnDeath?.Invoke();
        }
    }
}