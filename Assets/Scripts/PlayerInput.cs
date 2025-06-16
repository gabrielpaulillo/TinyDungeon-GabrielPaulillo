using UnityEngine;

namespace TinyDungeon
{
    public class PlayerInput : MonoBehaviour
    {
        public float HorizontalInput { get; private set; }
        public float VerticalInput { get; private set; }

        public bool AttackInput { get; set; }
        public bool InteractionInput { get; set; }


        private void Update()
        {
            HorizontalInput = Input.GetAxis("Horizontal");
            VerticalInput = Input.GetAxis("Vertical");

            if (Input.GetButtonDown("Fire1"))
            {
                AttackInput = true;
            }

            if (Input.GetButtonDown("Fire2"))
            {
                InteractionInput = true;
            }
        }
    }
}