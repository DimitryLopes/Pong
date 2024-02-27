using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const string SAVE_NAME_FORMAT = "Player_{0}_Name";
    private const string SAVE_SCORE_FORMAT = "Player_{0}_Score";

    [SerializeField]
    private UIScreen theVeryOnlyScreen;
    [SerializeField]
    private Player player1;
    [SerializeField]
    private Player player2;
    [SerializeField]
    private Ball ball;
    [SerializeField]
    private Transform p1Spawn;
    [SerializeField]
    private Transform p2Spawn;
    [SerializeField]
    private Transform ballSpawnPoint;

    public static GameManager Instance;

    private float timer;
    private bool isGameGoing;

    private void Awake()
    {
        Instance = this;
    }

    public void Start()
    {
        theVeryOnlyScreen.Show(string.Empty);
        ChangePlayerName(GetSavedPlayerName(0), 0);
        ChangePlayerName(GetSavedPlayerName(1), 1); 
        ShowHighScore();
    }

    public void StartGame()
    {
        isGameGoing = true;
        ScoreManager.Instance.ResetScore();
        TogglePlayerActing(true);
        theVeryOnlyScreen.Hide();
        ball.gameObject.SetActive(true);
        ball.ResetPosition();
    }

    private void ResetPlayerPosition()
    {
        player1.transform.position = p1Spawn.position;
        player2.transform.position = p2Spawn.position;
    }

    public void OnGoal()
    {
        ball.ResetPosition();
        ResetPlayerPosition();
    }

    public void Finish(int player)
    {
        TogglePlayerActing(false);
        ball.gameObject.SetActive(false);
        theVeryOnlyScreen.Show(GetSavedPlayerName(player) + " wins!");
        SavePlayerTime(player, timer);
        ShowHighScore();
        isGameGoing = false;
        timer = 0;
    }

    private void TogglePlayerActing(bool toggle)
    {
        player1.CanAct = toggle;
        player2.CanAct = toggle;
    }

    private void ShowHighScore()
    {
        ScoreManager.Instance.ShowHighScore(GetPlayerTime(0), GetPlayerTime(1));
    }

    #region Save

    #region Player Name
    private void SavePlayerName(string text, int playerId)
    {
        string key = GetPlayerNameSaveKey(playerId);
        PlayerPrefs.SetString(key, text);
    }

    private string GetSavedPlayerName(int playerId)
    {
        string key = GetPlayerNameSaveKey(playerId);
        int playerIdPlusOne = playerId + 1;
        string name = PlayerPrefs.GetString(key, "Player " + playerIdPlusOne);
        return name;
    }

    private string GetPlayerNameSaveKey(int player)
    {
        string saveKey = string.Format(SAVE_NAME_FORMAT, player);
        return saveKey;
    }

    public void ChangePlayerName(string text, int playerId)
    {
        theVeryOnlyScreen.ChangePlayerName(text, playerId);
        SavePlayerName(text, playerId);
    }
    #endregion

    #region HighScore
    private void SavePlayerTime(int player, float time)
    {
        float minTime = GetPlayerTime(player);
        if (time < minTime || minTime == 0)
        {
            string key = GetPlayerHighScoreKey(player);
            PlayerPrefs.SetFloat(key, time);
        }
    }

        private float GetPlayerTime(int player)
    {
        string key = GetPlayerHighScoreKey(player);
        float time = PlayerPrefs.GetFloat(key, 0f);
        return time;
    }

    private string GetPlayerHighScoreKey(int player)
    {
        string key = string.Format(SAVE_SCORE_FORMAT, player);
        return key;
    }

    public void ResetScores()
    {
        SavePlayerTime(0, 0);
        SavePlayerTime(1, 0);
        ShowHighScore();
    }

    #endregion

    #endregion

    private void Update()
    {
        if (isGameGoing)
        {
            timer += Time.deltaTime;
        }
    }
}
