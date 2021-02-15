using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoublePoints : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private int m_pointMultiplier;
    public int PointMultiplier
    {
        get
        {
            return m_pointMultiplier;
        }
    }

    [SerializeField]
    private int m_Duration;
    public int Duration
    {
        get
        {
            return m_Duration;
        }
    }

    #endregion
}
