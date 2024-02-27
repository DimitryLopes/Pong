using UnityEngine;
using TMPro;

public class UIScreen : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private TextMeshProUGUI p1Name;
    [SerializeField]
    private TextMeshProUGUI p2Name;

    public void Show(string text)
    {
        this.text.text = text;
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }

    public void ResetScores()
    {
        GameManager.Instance.ResetScores();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ChangePlayerName(string text, int playerId)
    {
        if (playerId == 0)
        {
            p1Name.text = text;

        }
        else
        {
            p2Name.text = text;
        }
    }
}
