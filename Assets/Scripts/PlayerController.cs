using UnityEngine;

namespace TinyDungeon
{
    [RequireComponent(typeof(CharacterMovement), typeof(PlayerInput))]
    [RequireComponent(typeof(ProjectileThrower), typeof(DialogCloser))]
    public class PlayerController : MonoBehaviour
    {
        public bool hasWeapon;

        [SerializeField]
        private Transform northRef, southRef, eastRef, westRef;

        private bool canMove;
        private bool canAttack;

        private CharacterMovement characterMovement;
        private PlayerInput input;
        private ProjectileThrower projectileThrower;
        private DialogCloser dialogCloser;

        private void Awake()
        {
            input = GetComponent<PlayerInput>();
            characterMovement = GetComponent<CharacterMovement>();
            projectileThrower = GetComponent<ProjectileThrower>();
            dialogCloser = GetComponent<DialogCloser>();

            canMove = true;
            canAttack = false;
            projectileThrower.EnableProjectileRepresentation(false);

            if (hasWeapon)
                ReceiveWeapon();
        }

        public void ReceiveWeapon()
        {
            hasWeapon = true;
            canAttack = true;
            projectileThrower.EnableProjectileRepresentation(true);
        }

        private void FixedUpdate()
        {
            PlayerMove();
            PlayerAttack();
            CloseDialog();
        }

        private void CloseDialog()
        {
            if (input.InteractionInput)
            {
                dialogCloser.Close();
                input.InteractionInput = false; // garante que o input ficará falso e não ficará chamado CloseDialog() o tempo todo
            }

        }

        private void PlayerAttack()
        {
            if (!canAttack)
                return;


            if (input.AttackInput)
            {
                Vector2 direction = new(input.HorizontalInput, input.VerticalInput);
                projectileThrower.Throw(direction); // Arremessa o projétil na direção que o jogador estiver andando

                input.AttackInput = false; // Se não ficar "false", o projétil sempre ficará como "true" e será lançado a todo momento
            }
        }

        private void PlayerMove()
        {
            if (!canMove)
            {
                characterMovement.Stop();
                return;
            }

            characterMovement.Move(input.HorizontalInput, input.VerticalInput);
        }

        public void EnablePlayerMovementAndAttack(bool enable)
        {
            input.AttackInput = false;  // impede que o input ative o ataque (projétil é arremessado assim que o diálogo é fechado)

            canMove = enable;

            if (hasWeapon)
                canAttack = enable;
        }

        public void Spawn(DirectionEnum.Directions direction)
        {
            switch (direction)
            {
                case DirectionEnum.Directions.North:
                    transform.position = northRef.position;
                    break;
                case DirectionEnum.Directions.South:
                    transform.position = southRef.position;
                    break;
                case DirectionEnum.Directions.East:
                    transform.position = eastRef.position;
                    break;
                case DirectionEnum.Directions.West:
                    transform.position = westRef.position;
                    break;
            }
        }
    }
}