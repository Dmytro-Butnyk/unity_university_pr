using UnityEngine;
using UnityEngine.UI; // Нужно для Button

public class RestartView : MonoBehaviour
{
    // Сюда перетянешь свой Текст (но на нём должен быть компонент Button, см. инструкцию ниже)
    [SerializeField] private Button _restartTextButton; 

    private void Start()
    {
        // Скрываем текст при старте
        Hide();
    }

    public void Show()
    {
        if (_restartTextButton != null)
            _restartTextButton.gameObject.SetActive(true);
    }

    public void Hide()
    {
        if (_restartTextButton != null)
            _restartTextButton.gameObject.SetActive(false);
    }

    public Button GetRestartButton()
    {
        return _restartTextButton;
    }
}