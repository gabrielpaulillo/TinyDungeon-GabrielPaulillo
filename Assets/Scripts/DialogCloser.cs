using UnityEngine;

namespace TinyDungeon
{
    [RequireComponent(typeof(PlayerController))]
    public class DialogCloser : MonoBehaviour
    {
        [SerializeField]
        private GameObject dialogCanvas;

        private PlayerController playerController;

        private void Start()
        {
            playerController = GetComponent<PlayerController>();
        }

        public void Close()
        {
            if (dialogCanvas.activeSelf == false)
                return;

            dialogCanvas.SetActive(false);
            playerController.EnablePlayerMovementAndAttack(true);
        }
    }
}