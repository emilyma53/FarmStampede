using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
  #region Editor Variables
  [SerializeField]
  [Tooltip("How fast the player can move.")]
  private float m_Speed;

  [SerializeField]
  private int m_MaxHealth;

  [SerializeField]
  private HudController m_HUD;
  #endregion

  #region Cached Components
  private Rigidbody cc_Rb;
  #endregion

  #region Cached References
  private Animator cr_Anim;

  private Renderer cr_Renderer;
  #endregion

  #region Private Variables
  // Current move direction of the player. Does NOT include magnitude
  private Vector2 p_Velocity;

  private float p_CurHealth;

  #endregion

  #region Initialization
  private void Awake() {
      p_Velocity = Vector2.zero;
      cc_Rb = GetComponent<Rigidbody>();
      cr_Anim = GetComponent<Animator>();
      cr_Renderer = GetComponentInChildren<Renderer>();
      p_CurHealth = m_MaxHealth;

  }

  private void Start() {
      Cursor.lockState = CursorLockMode.Locked;
  }
  #endregion

  #region Main Updates
  private void Update() {

      // Set how hard the player is pressing movement buttons
      float right = Input.GetAxis("Horizontal");

      cr_Anim.SetFloat("Speed", Mathf.Clamp01(Mathf.Abs(right))); //changed to this

      float moveThreshold = 0.3f;
      if (right > 0 && right < moveThreshold) {
          right = 0;
      }
      if (right < 0 && right > -moveThreshold) {
          right = 0;
      }
      p_Velocity.Set(right, 0); // changed forward field to 0
  }

  private void FixedUpdate() {
      // Update the position of the player
      if (p_Velocity[0] < 0) {
        cc_Rb.MovePosition(cc_Rb.position - m_Speed * Time.fixedDeltaTime * transform.right * p_Velocity.magnitude);
      } else {
        cc_Rb.MovePosition(cc_Rb.position + m_Speed * Time.fixedDeltaTime * transform.right * p_Velocity.magnitude);
      }
      cc_Rb.angularVelocity = Vector3.zero;
  }
  #endregion

  #region Health/Dying Methods
  public void DecreaseHealth(float amount) {
      p_CurHealth -= amount;
      m_HUD.UpdateHealth(1.0f * p_CurHealth / m_MaxHealth);

      if (p_CurHealth <= 0)
      {
          SceneManager.LoadScene("MainMenu");
      }
  }

  public void IncreaseHealth(float amount)
  {
      p_CurHealth += amount;
      if (p_CurHealth > m_MaxHealth)
      {
          p_CurHealth = m_MaxHealth;
      }
      m_HUD.UpdateHealth(1.0f * p_CurHealth / m_MaxHealth);
  }
  #endregion

}
