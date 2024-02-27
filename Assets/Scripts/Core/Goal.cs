using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField]
    private int player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            ScoreManager.Instance.IncreasePlayerScore(player);
            GameManager.Instance.OnGoal();
        }
    }
}
