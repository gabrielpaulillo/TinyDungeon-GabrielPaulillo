using UnityEngine;
using UnityEngine.SceneManagement;

namespace TinyDungeon
{
    public class ReloadScene : MonoBehaviour
    {

        [SerializeField]
        private int secondsToReload;
        
        public void Reload()
        {
            Invoke(nameof(LoadSameScene), secondsToReload);
        }

        private void LoadSameScene()
        {
            int currentScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
    } 
}
