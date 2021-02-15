using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  #region Editor Variables
 
  [SerializeField]
  private float m_Speed;

  [SerializeField]
  private float m_Damage;

  [SerializeField]
  private int m_Score;
  #endregion

  #region Cached Components
  private Rigidbody cc_Rb;
  #endregion

  #region Cached Region
  private Transform cr_Player;
  #endregion

  #region Initalization
  private void Awake() {

      cc_Rb = GetComponent<Rigidbody>();
  }

  private void Start() {
      cr_Player = FindObjectOfType<PlayerController>().transform;
  }
  #endregion

  #region Main Update
  private void FixedUpdate() {
      Vector3 dir = new Vector3(0,0,-1);
      cc_Rb.MovePosition(cc_Rb.position + dir * m_Speed * Time.fixedDeltaTime);
  }
  #endregion

  #region Collision Methods
  private void OnCollisionEnter(Collision collision) {
      GameObject other = collision.collider.gameObject;
      if (other.CompareTag("Player")) {
          Destroy(gameObject);
          other.GetComponent<PlayerController>().DecreaseHealth(m_Damage);
      }
  }
  #endregion
}
