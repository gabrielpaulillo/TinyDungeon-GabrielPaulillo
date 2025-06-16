using UnityEngine;
using UnityEngine.Events;

namespace TinyDungeon
{
    public class GhostMission : MonoBehaviour
    {
        public UnityEvent OnGhostMissionComplete; // informa que a missão foi concluída
        public UnityEvent OnUpdateAfterGhostMissionComplete; // altera o estado do jogo após a missão ter sido concluída
        public UnityEvent OnGhostMissionIncomplete;

        public static bool GhostMissionCompleted; // saber se a missão já foi completa ou não

        public static int GhostKills; // saber quantos fantasmas já matamos

        private const int ghostKillsTarget = 4; // n�mero de fantasmas necess�rios para finalizarmos a missão

        private void Start()
        {
            print("Ghost Mission Complete: " + GhostMissionCompleted);
            if (GhostMissionCompleted)
            {
                OnUpdateAfterGhostMissionComplete?.Invoke(); // quando a missão concluída, o estado do jogo será alterado
            }
            else
                OnGhostMissionIncomplete?.Invoke();
        }

        public void ResetGhostCount()
        {
            GhostKills = 0;
        }

        public void AddGhostKill()
        {
            GhostKills++; // acrescenta em 1 e atualiza o n�mero de fantasmas abatidos
            print("Ghostkills: " + GhostKills);

            if (GhostKills >= ghostKillsTarget)
            {
                GhostMissionCompleted = true;
                OnGhostMissionComplete?.Invoke(); // informa que a missão foi concluída
            }
        }
    }
}
