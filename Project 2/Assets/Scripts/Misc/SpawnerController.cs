using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    private EnemySpawnInfo[] m_Animals;

    [SerializeField]
    private float m_Xbound;
    #endregion

    #region Initialization
    private void Awake()
    {
        StartSpawning();
    }
    #endregion

    #region Spawn Methods
    public void StartSpawning()
    {
        StartCoroutine(Spawn());
    }
    #endregion
    private IEnumerator Spawn()
    {
        while (true)
        {
        EnemySpawnInfo info = m_Animals[Random.Range(0, m_Animals.Length)];
        float xBound = Random.Range(-m_Xbound, m_Xbound);
        Vector3 spawnPos = new Vector3(xBound, transform.position.y + info.SpawnHeight, transform.position.z);
        Instantiate(info.EnemyGO, spawnPos, Quaternion.identity * Quaternion.Euler(0, 180f, 0));
        float waitTime = info.TimeToNextSpawn;
        yield return new WaitForSeconds(waitTime);
        }
    }

}
