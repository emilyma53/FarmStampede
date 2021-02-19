using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private int m_PointValue;
    public int PointValue
    {
        get
        {
            return m_PointValue;
        }
    }

    [SerializeField]
    private int m_DespawnTime;
    public int DespawnTime
    {
        get
        {
            return m_DespawnTime;
        }
    }

    [SerializeField]
    private int m_SpawnHeight;
    public int SpawnHeight
    {
        get
        {
            return m_SpawnHeight;
        }
    }
    #endregion

    #region Update
    public void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, 80 * Time.deltaTime);
    }
    #endregion
}
