using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI nameInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartNew()
    {
        MenuManager.Instance.playerName = nameInput.text;
        MenuManager.Instance.playerScore = 0;
        Debug.Log("Player Name: " + MenuManager.Instance.playerName);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        MenuManager.Instance.SaveScore();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void ResetHighScore()
    {
        MenuManager.Instance.topScore = 0;
        MenuManager.Instance.topPlayerName = "none";
    }
}
