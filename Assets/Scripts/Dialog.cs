using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace TinyDungeon
{
    public class Dialog : MonoBehaviour
    {
        public UnityEvent OnStartDialog;

        [SerializeField]
        protected GameObject dialogCanvas;

        [SerializeField]
        protected TextMeshProUGUI titleTxt, messageTxt;

        [SerializeField]
        protected Image image;

        [Space(10), SerializeField]
        protected string title;

        [SerializeField, TextArea]
        protected string message;

        [SerializeField]
        protected Sprite sprite;
    }
}