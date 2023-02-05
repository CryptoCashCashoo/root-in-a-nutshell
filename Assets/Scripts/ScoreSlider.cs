using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Slider))]
public class ScoreSlider : MonoBehaviour
{
    Slider _thisSlider;
    [SerializeField] TextMeshProUGUI _nameLevel;

    void Awake()
    {
        _thisSlider = GetComponent<Slider>();
        _thisSlider.value = GameManager.Get.GetScore();
        _nameLevel.text = GameManager.Get.GetLevelName();
        GameManager.Get._onChangeScore += UpdateScore;
        GameManager.Get._onChangeLevelName += ChangeName;
    }

    void UpdateScore(float f)
    {
        _thisSlider.value = f;
    }

    void ChangeName(string s)
    {
        _nameLevel.text = s;
    }

}
