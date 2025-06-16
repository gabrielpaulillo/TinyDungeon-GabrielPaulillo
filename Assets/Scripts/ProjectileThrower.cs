using UnityEngine;

namespace TinyDungeon
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class ProjectileThrower : MonoBehaviour
    {
        [SerializeField]
        private GameObject projectileRepresentation; // para fazer a representação sumir, temos que referenciá-la

        [SerializeField]
        private Projectile projectile;

        [SerializeField]
        private AudioClip audioClip;

        private Vector2 lastValidDirection;

        private void Start()
        {
            lastValidDirection = Vector2.right; // define a direção inicial da variável
        }

        public void Throw(Vector2 direction) // O param permite alterar a direção que o projétil é arremessado
        {
            if (projectile.isActiveAndEnabled)
                return; // impede redirecionar a trajetória do projétil quando esse estiver ativo

            // ".magnitude" representa o tamanho do vetor
            if (direction.magnitude == 0) // caso o jogador esteja parado, a trajetória do projétil será igual à última trajetória válida
                direction = lastValidDirection;
            else
                lastValidDirection = direction; // atualiza "lastValidDirection" sempre que o projétil for arremessado e o vetor de movimento do jogado for maior que zero.

            projectile.Throw(direction.normalized); // define a trajetória do projétil e normaliza o vetor, para que o número não "quebrado"

            if (projectileRepresentation != null) // quando o método é chamado, verifica se a representação não é nula
                projectileRepresentation.SetActive(false);

            if (audioClip != null)
                AudioSource.PlayClipAtPoint(audioClip, transform.position);
        }

        public void EnableProjectileRepresentation(bool enable)
        {
            if (projectileRepresentation == null)
                return;

            projectileRepresentation.SetActive(enable);
        }
    }
}