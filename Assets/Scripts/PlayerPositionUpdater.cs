using UnityEngine;

namespace TinyDungeon
{
    public class PlayerPositionUpdater : MonoBehaviour
    {
        // Por ser "static" o elemento irá perdurar entre as cenas
        public static DirectionEnum.Directions spawnPosition;

        [SerializeField]
        private PlayerController playerController;

        [SerializeField]
        private DirectionEnum.Directions firstSpawnPosition; // configuração no inspector

        private static bool hasSpawnedBefore;

        private void Start()
        {
            if (hasSpawnedBefore)
                playerController.Spawn(spawnPosition);
            else
                playerController.Spawn(firstSpawnPosition); // configuramos o valor dessa variável no inspector como "South"
        }

        public void ConfigureNextSpawn(DirectionEnum.Directions position)
        {
            hasSpawnedBefore = true; // deixamos como 'true', porque quando esse método é chamado, quer dizer que o personagem já foi spawnado anteriormente.
            spawnPosition = position;
        }
    }
}