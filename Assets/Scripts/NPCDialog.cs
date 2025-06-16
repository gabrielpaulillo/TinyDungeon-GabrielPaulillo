using UnityEngine;

namespace TinyDungeon
{
    [RequireComponent(typeof(Collider2D))]
    public class NPCDialog : Dialog
    {
        [Space(10), SerializeField]
        protected string tagToInteract;

        [SerializeField]
        private AudioClip audioClip;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(tagToInteract))
            {
                OnStartDialog?.Invoke();

                titleTxt.text = title;
                messageTxt.text = message;
                image.sprite = sprite;

                dialogCanvas.SetActive(true);

                if (audioClip != null)
                    AudioSource.PlayClipAtPoint(audioClip, transform.position);
            }
        }
    }
}