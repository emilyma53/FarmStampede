using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private RectTransform m_HealthBar;

    [SerializeField]
    private Text m_Score;

    [SerializeField]
    private ScoreManager m_ScoreManager;
    #endregion

    #region Private Variables
    private float p_HealthBarOrigWidth;
    #endregion

    #region Initialization
    private void Awake()
    {
        p_HealthBarOrigWidth = m_HealthBar.sizeDelta.x;
        StartCoroutine(watchScore());
    }
    #endregion

    #region Update Score
    private IEnumerator watchScore()
    {
        while (true)
        {
            UpdateScore();
            yield return null;
        }
    }

    public void UpdateScore()
    {
        m_Score.text = m_ScoreManager.CurScore.ToString();
    }

    #endregion

    #region Update Health Bar
    public void UpdateHealth(float percent)
    {
        m_HealthBar.sizeDelta = new Vector2(p_HealthBarOrigWidth * percent, m_HealthBar.sizeDelta.y);
    }
    #endregion
}
