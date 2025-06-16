namespace TinyDungeon
{
    public class LevelDialog : Dialog
    {
        public void Show()
        {
            OnStartDialog?.Invoke();

            titleTxt.text = title;
            messageTxt.text = message;
            image.sprite = sprite;

            dialogCanvas.SetActive(true);
        }
    }
}