using UnityEngine;
using UnityEngine.UI ;

public class UIColorChanger : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private Button button;
    [SerializeField]
    private SpriteRenderer playerPallet;

    private Color color;

    private void Start()
    {
        color = image.color;
        button.onClick.AddListener(ChangeColor);
    }

    public void ChangeColor()
    {
        playerPallet.color = color;
    }
}
