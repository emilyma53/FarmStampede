using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private Text m_HighScore;
    #endregion

    #region Private Variables
    private string m_DefaultHighScoreText;
    #endregion 

    #region Initialization
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        m_DefaultHighScoreText = m_HighScore.text;
        UpdateHighScore();
    }
    #endregion

    #region Play Button Methods
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }
    #endregion

    #region Quit Button Methods
    public void Quit()
    {
        PlayerPrefs.SetInt("HS", 0);
        m_HighScore.text = m_DefaultHighScoreText.Replace("%S", "0");
        Application.Quit();
    }
    #endregion

    #region High Score Methods 
    private void UpdateHighScore()
    {
        if (PlayerPrefs.HasKey("HS"))
        {
            m_HighScore.text = m_DefaultHighScoreText.Replace("%S", PlayerPrefs.GetInt("HS").ToString());
        }
        else
        {
            PlayerPrefs.SetInt("HS", 0);
            m_HighScore.text = m_DefaultHighScoreText.Replace("%S", "0");
        }
    }

    #endregion
}