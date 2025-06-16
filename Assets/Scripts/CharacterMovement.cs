using UnityEngine;

namespace TinyDungeon
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField]
        private float speed = 5.0f;

        private new Rigidbody2D rigidbody;
        private void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Move(float horizontalInput, float verticalInput)
        {
            Vector2 direction = new(horizontalInput, verticalInput);
            rigidbody.linearVelocity = direction * speed;
        }

        public void Stop()
        {
            rigidbody.linearVelocity = Vector2.zero;
        }
    }
}