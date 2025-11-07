using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    private Slider slider;
    [SerializeField] private TextMeshProUGUI hpText;

    private void Start()
    {
        slider = GetComponentInChildren<Slider>();
        GetComponentInParent<IHealth>().OnHPPctChanged += HandleHPPctChanged;
    }

    private void HandleHPPctChanged(float newHp, float totalHp)
    {
        float roundedHp = (float)System.Math.Round(newHp, 2);
        slider.value = newHp / totalHp;
        UpdateText(roundedHp.ToString() + "/" + totalHp.ToString());
    }

    public void UpdateText(string text)
    {
        hpText.SetText(text);
    }
}
