using System;
using UnityEngine;

namespace TinyDungeon
{
    [RequireComponent(typeof(CharacterMovement))]
    public class EnemyController : MonoBehaviour
    {
        [SerializeField]
        private Transform targetA, targetB;

        private CharacterMovement characterMovement;
        private Transform currentTarget;

        private void Start()
        {
            characterMovement = GetComponent<CharacterMovement>();
            currentTarget = targetA;
        }

        private void Update()
        {
            // A subtração é utilizada para descobrirmos qual é a direção do personagem
            // O Vetor "direction" está sendo normalizado (a distância permanece sempre a mesma "1") e se importa apenas com a direção do inimigo

            // Quanto mais longe o inimigo está do target, maior é o vetor e mais rápido o inimigo fica.
            // O "normalized" normaliza o tamanho do vetor, logo, o tamanho sempre será o mesmo e a velocidade do inimigo será constante. 
            Vector3 direction = (currentTarget.position - transform.position).normalized;
            characterMovement.Move(direction.x, direction.y);

            float distance = Vector2.Distance(currentTarget.position, transform.position);
            CheckAndChangeDirection(distance);
        }

        private void CheckAndChangeDirection(float distance)
        {
            if (distance < .1f)
            {
                if (currentTarget == targetA)
                    currentTarget = targetB;
                else
                    currentTarget = targetA;
            }
        }
    }
}