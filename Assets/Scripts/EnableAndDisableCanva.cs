using UnityEngine;

namespace TinyDungeon
{
    public class EnableAndDisableCanva : MonoBehaviour
    {
        [SerializeField]
        private bool isEnabled = true;

        private void Start()
        {
            gameObject.SetActive(isEnabled);
        }
    }
}