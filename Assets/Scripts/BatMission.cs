using UnityEngine;
using UnityEngine.Events;

namespace TinyDungeon
{
    // para cada nova missão, deverá ser criado um novo script seguindo esse formato (é possível fazer de outras formas)
    public class BatMission : MonoBehaviour
    {
        public UnityEvent OnMissionComplete; // informa que a missão foi concluída
        public UnityEvent OnUpdateAfterMissionComplete; // altera o estado do jogo após a missão ter sido concluída
        public UnityEvent OnMissionIncomplete;
        
        public static bool BatMissionCompleted; // saber se a missão já foi completa ou não

        public static int BatKills; // saber quantos morcegos já matamos

        private const int batKillsTarget = 5; // número de morcegos necessários para finalizarmos a missão

        private void Start()
        {

            print("BatMission Complete: " + BatMissionCompleted);
            if (BatMissionCompleted)
                OnUpdateAfterMissionComplete?.Invoke(); // quando a missão é concluída, o estado do jogo será alterado
            else
                OnMissionIncomplete?.Invoke();
        }

        public void ResetBatCount()
        {
            BatKills = 0;
        }

        public void AddBatKill()
        {
            BatKills++; // acrescenta em 1 e atualiza o número de morcegos abatidos

            if (BatKills >= batKillsTarget)
            {
                BatMissionCompleted = true;
                OnMissionComplete?.Invoke(); // informa que a missão foi concluída
            }
        }
    }
}