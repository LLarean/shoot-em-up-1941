using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Shmup1941
{
    public class PlayerHUD : MonoBehaviour
    {
        [SerializeField] private Image _health;
        [SerializeField] private Image _fuel;
        [SerializeField] private TextMeshProUGUI _score;

        private void Update()
        {
            _health.fillAmount = GameManager.Instance.PlayerPlane.GetHealthNormilized();
            _fuel.fillAmount = GameManager.Instance.PlayerPlane.GetFuelNormolized();
            _score.text = $"ОЧКИ: {GameManager.Instance.Score}";
        }
    }
}