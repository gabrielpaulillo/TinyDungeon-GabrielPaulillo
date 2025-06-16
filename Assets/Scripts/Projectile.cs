using UnityEngine;
using UnityEngine.Events;

namespace TinyDungeon
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
    public class Projectile : MonoBehaviour
    {
        public UnityEvent OnDisableProjectile;
        // Por que utilizar "Transform"?
        // Porque é o Transform que armazena a posição, rotação e escala do objeto
        [SerializeField]
        private Transform initialPosition;

        [SerializeField]
        private float speed = 10.0f;

        [SerializeField]
        private Vector4 screenLimits;

        [SerializeField]
        private string tagToIgnore;

        private new Rigidbody2D rigidbody;
        private Vector2 direction;

        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            gameObject.SetActive(false); // Quando começar o jogo, o objeto desaparece (fica inativo)
        }

        private void OnEnable()
        {
            // Define a posição inicial do projétil
            // Impede o jogador de spammar a tecla de ataque, pois o projétil já está ativo.
            // O jogador só consegue atacar novamente quando o projétil for desabilitado
            gameObject.transform.position = initialPosition.position;
        }

        private void FixedUpdate()
        {
            rigidbody.linearVelocity = direction * speed;

            // Vector4 criará um "quadrado invisível" limitando os 4 lados da tela, verificando se o projétil está dentro dos limites da tela, sendo:
            // x (limite esquerdo do eixo X)
            // y (limite direito do eixo X)
            // z (limite de baixo do eixo Y)
            // w (limite de cima do eixo Y)
            if (transform.position.x < screenLimits.x ||
                transform.position.x > screenLimits.y ||
                transform.position.y < screenLimits.z ||
                transform.position.y > screenLimits.w)
            {
                DisableMe();
            }
        }

        private void DisableMe()
        {
            OnDisableProjectile?.Invoke();
            gameObject.SetActive(false);
        }

        void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(tagToIgnore))
                return;

            DisableMe();
        }

        public void Throw(Vector2 direction)
        {
            this.direction = direction;
            // Quando o método Throw() for chamado, a espada ficará visível
            gameObject.SetActive(true);
        }
    }
}