using TMPro;
using UnityEngine;

public class UIScoreCounter : MonoBehaviour
{
    public const string HIGH_SCORE_FORMAT = "Fastest win: {0}";

    [SerializeField]
    private TextMeshProUGUI text;
    public void SetScore(int score)
    {
        text.text = score.ToString();
    }

    public void ShowHighestScore(float time)
    {
        if(time == 0)
        {
            text.text = "Never won!";
            return;
        }
        float roundedValue = Mathf.Round(time * 100f) / 100f;
        text.text = string.Format(HIGH_SCORE_FORMAT, roundedValue);
    }
}
