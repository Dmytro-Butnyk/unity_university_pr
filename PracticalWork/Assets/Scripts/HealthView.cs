using UnityEngine;
using TMPro;

public class HealthView : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;

    public void UpdateHealthDisplay(int currentHealth)
    {
        _healthText.text = $"HP: {currentHealth}";
    }
}