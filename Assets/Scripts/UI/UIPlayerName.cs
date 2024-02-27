using UnityEngine;
using TMPro;

public class UIPlayerName : MonoBehaviour
{
    [SerializeField]
    private int playerId;
    [SerializeField]
    private TMP_InputField inputField;

    private void Start()
    {
        inputField.onValueChanged.AddListener(OnTextChanged);
    }

    private void OnTextChanged(string text)
    {
        GameManager.Instance.ChangePlayerName(text, playerId);
    }
}
