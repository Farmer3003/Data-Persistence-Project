using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUIHandler : MonoBehaviour
{
    public TextMeshProUGUI highscore;
    public string playerName;
    private void Start()
    {
        // change the best score text
        highscore.text = "Best Score : " + Data.Instance.playerName + " : " + Data.Instance.point;
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
        Data.Instance.SaveplayerName();
    }
    public void ReadStringInput(string s)
    {
        playerName = s;
        Data.Instance.playerName = playerName;
        Data.Instance.SaveplayerName();
        Debug.Log(playerName);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
        Data.Instance.SavePoint();
    }
}
