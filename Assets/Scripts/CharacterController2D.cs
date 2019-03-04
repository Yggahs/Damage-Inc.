using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class CharacterController2D : MonoBehaviour
{
    public int health = 20, selectedWeapon = 1, damage = 1;
    public GameObject life1, life2, life3, life4, life5;
    public float runSpeed = 40f;
    float horizontalMove = 0f, timer;
    bool jump = false, crouch = false, airborne = false, climbing = false;
    public bool invincible = false;
    public Image ActiveWeaponSprite;
    public Sprite BSprite1, BSprite2, BSprite3;




    [SerializeField] public float m_JumpForce = 200f;                          // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    [SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching
    [SerializeField] private Transform m_ClimbingCheck;

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    private bool m_Grounded;    
    
    // Whether or not the player is grounded.
    const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
    private Rigidbody2D m_Rigidbody2D;   

    public bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;
    public GameObject Enemy;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;

    private void Awake()
    {

        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
        ActiveWeaponSprite.sprite = BSprite1;
    }


    void Update()
    {
        timer += Time.deltaTime;
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;


        if (GetComponent<Rigidbody2D>().velocity.y != 0 && climbing == false)
        {

            airborne = true;
            if (climbing == true) airborne = false;

        }
        else airborne = false;

        WeaponSelect();
        Crouch();

    }

    private void FixedUpdate()
    {
        bool wasGrounded = m_Grounded;
        m_Grounded = false;

        // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                m_Grounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }

        // Move our character
        Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

        Jump();
        Dash();
        WallClimbing();
    }

    private void WallClimbing()
    {
        if (m_FacingRight == true)
        {
            RaycastHit2D hit1 = Physics2D.Raycast(m_ClimbingCheck.position, transform.right, 0.07f);
            Debug.DrawLine(m_ClimbingCheck.position, m_ClimbingCheck.position + transform.right * 0.07f, Color.yellow);
            if (hit1.distance != 0)
            {
                GetComponent<Rigidbody2D>().drag = 10;
            }
            else GetComponent<Rigidbody2D>().drag = 0;
        }
        else
        {
            RaycastHit2D hit1 = Physics2D.Raycast(m_ClimbingCheck.position, -transform.right, 0.07f);
            Debug.DrawLine(m_ClimbingCheck.position, m_ClimbingCheck.position + -transform.right * 0.07f, Color.yellow);
            print(hit1.distance);
            if (hit1.distance != 0)
            {
                GetComponent<Rigidbody2D>().drag = 10;
            }
            else GetComponent<Rigidbody2D>().drag = 0;


        }


    }

    public void Move(float move, bool crouch, bool jump)
    {
        // If crouching, check to see if the character can stand up
        if (!crouch)
        {
            // If the character has a ceiling preventing them from standing up, keep them crouching
            if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
            {
                crouch = true;
            }
        }

        //only control the player if grounded or airControl is turned on
        if (m_Grounded || m_AirControl)
        {

            // If crouching
            if (crouch)
            {
                if (!m_wasCrouching)
                {
                    m_wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }

                // Reduce the speed by the crouchSpeed multiplier
                move *= m_CrouchSpeed;

                // Disable one of the colliders when crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = false;
            }
            else
            {
                // Enable the collider when not crouching
                if (m_CrouchDisableCollider != null)
                    m_CrouchDisableCollider.enabled = true;

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }

            // Move the character by finding the target velocity
            Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
            // And then smoothing it out and applying it to the character
            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

            // If the input is moving the player right and the player is facing left...
            if (move > 0 && !m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
            // Otherwise if the input is moving the player left and the player is facing right...
            else if (move < 0 && m_FacingRight)
            {
                // ... flip the player.
                Flip();
            }
        }
        // If the player should jump...
        if (m_Grounded && jump)
        {
            // Add a vertical force to the player.
            m_Grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
        }
    }

    private void WeaponSelect()
    {
        var WeaponScriptVar = GetComponent<WeaponsScript>();

        //Weapon Select Logic
        if (Input.GetButtonDown("Select Weapon 1"))
        {
            selectedWeapon = 1;
            ActiveWeaponSprite.sprite = BSprite1;
            WeaponScriptVar.MagazineText.text = "∞";
        }

        if (Input.GetButtonDown("Select Weapon 2"))
        {
            selectedWeapon = 2;
            ActiveWeaponSprite.sprite = BSprite2;
            WeaponScriptVar.MagazineText.text = WeaponScriptVar.Weapon3MaxBullets.ToString() + "/" + WeaponScriptVar.Weapon2MaxBullets.ToString();
        }

        if (Input.GetButtonDown("Select Weapon 3"))
        {
            selectedWeapon = 3;
            ActiveWeaponSprite.sprite = BSprite3;
            WeaponScriptVar.MagazineText.text = WeaponScriptVar.Weapon3Bullets.ToString() + "/" + WeaponScriptVar.Weapon2MaxBullets.ToString();
        }

        //Weapon Selection

        switch (selectedWeapon)
        {
            case 1:
                WeaponScriptVar.Weapon1();

                break;
            case 2:
                WeaponScriptVar.Weapon2();

                break;
            case 3:
                WeaponScriptVar.Weapon3();

                break;
            default:
                WeaponScriptVar.Weapon1();
                

                break;
        }
    }

    private void Jump()
    {
        //Jump Command Logic
        if (Input.GetButtonDown("Jump"))
        {
            if (airborne == false)
            {
                if (climbing)
                {
                    if (m_FacingRight)
                    {
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(-250f, 0));
                    }
                    else
                    {
                        GetComponent<Rigidbody2D>().AddForce(new Vector2(250f, 0));
                    }
                }
                jump = true;
            }
        }
    }

    private void Dash()
    {
        //Dash Logic
        if (timer > 0.5)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (m_FacingRight == false)
                {

                    GetComponent<Rigidbody2D>().AddForce(new Vector2(-30, 0), ForceMode2D.Impulse);

                }
                else
                {
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(30, 0), ForceMode2D.Impulse);

                }

                timer = 0;
            }

        }
    }

    private void Crouch()
    {

        //Crounch Command Logic
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {

            if (invincible == false)
            {
                collision.transform.GetComponent<Enemy>().DealDamage();
                StartCoroutine(Invincible());
                print(health);
                if (health >= 16)
                {
                    life5.GetComponent<Image>().fillAmount -= 0.25f;
                }
                else if (health >= 12)
                {
                    life4.GetComponent<Image>().fillAmount -= 0.25f;
                }
                else if (health >= 8)
                {
                    life3.GetComponent<Image>().fillAmount -= 0.25f;
                }
                else if (health >= 4)
                {
                    life2.GetComponent<Image>().fillAmount -= 0.25f;
                }
                else
                {
                    life1.GetComponent<Image>().fillAmount -= 0.25f;
                }
            }
        }

    }


    private IEnumerator Invincible()
    {

        invincible = true;
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(.1f);
        GetComponent<SpriteRenderer>().enabled = true;
        invincible = false;
    }
}
