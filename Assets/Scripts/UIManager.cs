using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _score;

    public void UpdateScoreText(int newScore)
    {
        _score.text = $"Score:\n{newScore}";
    }
}
