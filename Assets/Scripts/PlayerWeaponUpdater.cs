using UnityEngine;

namespace TinyDungeon
{
    public class PlayerWeaponUpdater : MonoBehaviour
    {
        // Classe que garante que o jogo lembrará que o jogador já recebeu a arma
        public static bool WeaponReceived;

        [SerializeField]
        private PlayerController playerController;

        private void Start()
        {
            if (WeaponReceived)
                playerController.ReceiveWeapon();
        }

        public void ReceiveWeapon()
        {
            WeaponReceived = true;
        }
    }
}