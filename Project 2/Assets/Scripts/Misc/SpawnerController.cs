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

    [SerializeField]
    private GameObject m_Coin;

    [SerializeField]
    private GameObject m_Player;
    #endregion

    #region Private Variables
    private GameObject[] coinsList; 
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
        StartCoroutine(SpawnAnimals());
        StartCoroutine(SpawnCoins());
    }
    #endregion

    #region Coroutines
    private IEnumerator SpawnAnimals()
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

    private IEnumerator SpawnCoins()
    {   
        yield return new WaitForSeconds(5);
        while (true)
        {
            Vector3 coinSpawnPos = new Vector3(Random.Range(-m_Xbound, m_Xbound), transform.position.y + m_Coin.GetComponent<Coin>().SpawnHeight, m_Player.transform.position.z);
            GameObject newCoin = Instantiate(m_Coin, coinSpawnPos, Quaternion.identity * Quaternion.Euler(0, 0, 90f));
            yield return new WaitForSeconds(m_Coin.GetComponent<Coin>().DespawnTime);
            if (newCoin != null)
            {
                Destroy(newCoin);
            }
        }
        
    }
    #endregion
}
