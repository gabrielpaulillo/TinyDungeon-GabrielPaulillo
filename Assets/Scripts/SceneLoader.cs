using UnityEngine;
using UnityEngine.SceneManagement;

namespace TinyDungeon
{
    [RequireComponent(typeof(Collider2D))]
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField]
        private string sceneToLoad;

        [SerializeField]
        private string tagToInteract; // garante que a tag que irá interagir é a "Player" e não a da espada, por exemplo.

        [SerializeField]
        private DirectionEnum.Directions nextSpawnPosition; // posição da próximo level/cena

        [SerializeField]
        private PlayerPositionUpdater playerPositionUpdater; // chama o método que configura a posição do próximo level/cena

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(tagToInteract))
            {
                playerPositionUpdater.ConfigureNextSpawn(nextSpawnPosition);
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}