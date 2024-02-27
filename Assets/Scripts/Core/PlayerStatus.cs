using UnityEngine;

[CreateAssetMenu(menuName = "Sriptable Objects/Player Status")]
public class PlayerStatus : ScriptableObject
{
    [SerializeField]
    private float baseMovementSpeed;

    public float MovementSpeed => baseMovementSpeed;
}
