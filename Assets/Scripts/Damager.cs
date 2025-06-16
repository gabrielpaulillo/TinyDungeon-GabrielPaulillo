using UnityEngine;

namespace TinyDungeon
{
    [RequireComponent(typeof(Collider2D))]
    public class Damager : MonoBehaviour
    {
        [SerializeField]
        private int damage = 1;

        [SerializeField]
        private string tagToIgnore;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(tagToIgnore))
                return;

            // O morcego bateu no jogador.
            // O jogador tem o componente Damageable? Tem.
            // Então, chama o "damageable" que chama seu método "Hit(int value)"
            // E aplicamos o valor do dano do morcego como parâmetro.
            if (collision.TryGetComponent<Damageable>(out Damageable damageable))
            {
                damageable.Hit(damage);
            }
        }
    }
}