using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace SpaceBattle.UI
{

    [RequireComponent(typeof(Image))]
    public class Healthbar : MonoBehaviour
    {
        [Inject] private ShipHealth _shipHealth;

        private Image _healthDisplay;

        #region Initialization

        private void Start() => AssignHealthDisplay();

        private void AssignHealthDisplay() => _healthDisplay = gameObject.GetComponentWithException<Image>();


        private void OnEnable()
        {
            _shipHealth.OnHealthChanged += UpdateHealthDisplay;
        }

        private void OnDestroy()
        {
            _shipHealth.OnHealthChanged -= UpdateHealthDisplay;
        }

        #endregion

        private void UpdateHealthDisplay(int health, int maxHealth) => _healthDisplay.fillAmount = (float)health / (float)maxHealth;
    }
}
