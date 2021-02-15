using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager singleton;

    #region Private Variables
    private int m_CurScore;
    public int CurScore
    {
        get
        {
            return m_CurScore;
        }
    }

    // private int m_Multiplier;
    private float m_timer;
    #endregion

    #region Initialization
    private void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        } else if (singleton != this)
        {
            Destroy(gameObject);
        }
        m_timer = 0;
        // m_Multiplier = 1;
        m_CurScore = 0;
    }
    #endregion

    // #region Point Multiplier
    // public void activateMultiplier(DoublePoints multiplier)
    // {
    //     m_Multiplier = multiplier.PointMultiplier;
    //     StartCoroutine(counter(multiplier.Duration));
    // }

    // private IEnumerator counter(int sec)
    // {
    //     yield return new WaitForSeconds(sec);
    //     m_Multiplier = 1;
    // }
    //
    // #endregion

    #region Update
    private void Update()
    {
        IncreaseScore();
        UpdateHighScore();
    }
    #endregion

    #region High Score Methods
    public void IncreaseScore()
    {
        // m_CurScore += (amount * m_Multiplier);
        m_timer += Time.deltaTime;
        if (m_timer > 1) {
          m_CurScore += (int) Mathf.Floor(m_timer);
          m_timer -= (int) Mathf.Floor(m_timer);
        }

    }

    private void UpdateHighScore()
    {
        if (!PlayerPrefs.HasKey("HS"))
        {
            PlayerPrefs.SetInt("HS", m_CurScore);
            return;
        }
        int hs = PlayerPrefs.GetInt("HS");
        if (hs < m_CurScore)
        {
            PlayerPrefs.SetInt("HS", m_CurScore);
        }

    }
    #endregion

    #region Destruction
    private void OnDisable()
    {
        UpdateHighScore();
    }
    #endregion

}
