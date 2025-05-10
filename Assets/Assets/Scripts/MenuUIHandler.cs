using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.IO;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TextMeshProUGUI highScoreText;

    private string playerName;
    private int highScore;

    private void Start()
    {
        LoadData();
        highScoreText.text = $"Best Score: {playerName} - {highScore}";
    }
    public void QuitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }

    public void StartGame()
    {
        // Salva nome pra usar no jogo depois
        MainManager.playerNameTemp = nameInputField.text;
        SceneManager.LoadScene("main");
    }

    private void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            highScore = data.highScore;
        }
    }
}

