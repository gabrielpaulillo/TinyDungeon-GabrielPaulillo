using UnityEngine;

namespace TinyDungeon
{
    public class ObjectRotation : MonoBehaviour
    {
        [SerializeField]
        private float speed;

        private void Update()
        {
            Vector3 rotateSpeed = new Vector3(0, 0, speed) * Time.deltaTime;
            gameObject.transform.Rotate(rotateSpeed);
        }

    }
}