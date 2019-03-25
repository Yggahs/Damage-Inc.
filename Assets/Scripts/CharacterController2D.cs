using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
public class CharacterController2D : MonoBehaviour
{
    public int health = 12, maxHealth, selectedWeapon = 1, damage = 1, hearts = 3, maxHeartAmount = 9, healthPerHeart = 4;
    public float runSpeed = 40f;
    public bool invincible = false, pause = false, weapon2Unlocked = false, weapon3Unlocked = false;
    public Image ActiveWeaponSprite;
    public Sprite BSprite1, BSprite2, BSprite3;
    public GameObject PauseMenu, GameOverMenu;

    float horizontalMove = 0f, timer;
    private bool crouch = false, climbing = false, GameOver = false;
    private float closestCheckpointDistance;
    private int closestCheckpointIndex;

    //Arrays
    public Image[] healthImages;
    public Sprite[] healthSprites;
    public GameObject[] ConsumablesArray, EnemiesArray, CheckPointsArray;





    [SerializeField] public float m_JumpForce = 200f;                          // Amount of force added when the player jumps.
    [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    [SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
    [SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    [SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
    [SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    [SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching
    [SerializeField] private Transform m_ClimbingCheckRight;
    [SerializeField] private Transform m_ClimbingCheckLeft;

    const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
    public bool m_Grounded;    
    
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

    public Animator animator;

    private void Start()
    {
        maxHealth = hearts * healthPerHeart;
        health = maxHealth;
        Time.timeScale = 1;

    }
    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }


    void Update()
    {

        timer += Time.deltaTime;
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        Pause();
        EmptyHeartsManager();
        UpdateHearts();
        if (health < 0) health = 0;
        if (GameOver == false)
        {
            GameOverCheck();
        }


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

        // Control our character
        Move(horizontalMove * Time.fixedDeltaTime, crouch, m_Grounded);
        Dash();
        WeaponSelect();
        Crouch();
        WallClimbing();
        animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal"));
        animator.SetBool("IsFacingRight", m_FacingRight);

        if (horizontalMove > 0)
        {
            m_FacingRight = true;
        }
        else
        {
            m_FacingRight = false;
        }
    }

    private void GameOverCheck()
    {

        if (health <= 0)
        {
            GameOver = true;
            Time.timeScale = 0;
            GameOverMenu.SetActive(true);
        }
    }

    private void EmptyHeartsManager()
    {
        for (int i = 0; i < maxHeartAmount; i++)
        {
            if (hearts <= i)
            {
                healthImages[i].enabled = false;
            } else healthImages[i].enabled = true;
        }
    }

    private void UpdateHearts()
    {
        bool empty = false;
        int i = 0;

        foreach (Image image in healthImages)
        {
            if(empty)
            {
                image.sprite = healthSprites[0];
            } else
            {
                i++;
                if(health >= i * healthPerHeart)
                {
                    image.sprite = healthSprites[healthSprites.Length - 1];
                }
                else
                {
                    int currentHeartHealth = (int)(healthPerHeart - (healthPerHeart * i - health));
                    int healthPerImage = healthPerHeart / (healthSprites.Length - 1);
                    int imageIndex = currentHeartHealth / healthPerImage;
                    image.sprite = healthSprites[imageIndex];
                    empty = true;
                }
            }
        }
    }

    private void WallClimbing()
    {
        if (m_FacingRight)
        {
            RaycastHit2D hit1 = Physics2D.Raycast(m_ClimbingCheckRight.position, transform.right, 0.07f);
            Debug.DrawLine(m_ClimbingCheckRight.position, m_ClimbingCheckRight.position + transform.right * 0.07f, Color.yellow);
            if (hit1)
            {
                climbing = true;
                GetComponent<Rigidbody2D>().drag = 10;
                if (Input.GetButtonDown("Jump") && climbing &&!m_Grounded)
                {
                    m_Rigidbody2D.AddForce(new Vector2(-m_JumpForce, m_JumpForce));
                }
            }
            else
            {
                climbing = false;
                GetComponent<Rigidbody2D>().drag = 0;
            }
        }
        else
        {
            RaycastHit2D hit1 = Physics2D.Raycast(m_ClimbingCheckLeft.position, -transform.right, 0.07f);
            Debug.DrawLine(m_ClimbingCheckLeft.position, m_ClimbingCheckLeft.position + (-transform.right * 0.07f), Color.green);
            if (hit1)
            {
                climbing = true;
                GetComponent<Rigidbody2D>().drag = 10;
                if (Input.GetButtonDown("Jump") && climbing && !m_FacingRight && !m_Grounded)
                {
                    m_Rigidbody2D.AddForce(new Vector2(m_JumpForce, m_JumpForce));
                }

            }
            else
            {
               // Debug.Log("non va");
                climbing = false;
                GetComponent<Rigidbody2D>().drag = 0;
            }
        }


       

    }

    public void Move(float move, bool crouch, bool m_Grounded)
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

        }
        // If the player should jump...
        if (Input.GetButtonDown("Jump"))
        {
            if (m_Grounded)
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
        }

        //if (m_Rigidbody2D.velocity.x<0f)
        //{
        //    Flip();
        //}
        //else if (m_Rigidbody2D.velocity.x>0f)
        //{
        //    Flip();
        //}
    }

    public void WeaponSelect()
    {
        var WeaponScriptVar = GetComponent<WeaponsScript>();

        //Weapon Select Logic
        if (Input.GetButtonDown("Select Weapon 1"))
        {
            selectedWeapon = 1;
            ActiveWeaponSprite.sprite = BSprite1;
        }

        if (Input.GetButtonDown("Select Weapon 2"))
        {
            if (weapon2Unlocked)
            {
                selectedWeapon = 2;
                ActiveWeaponSprite.sprite = BSprite2;
            }
        }

        if (Input.GetButtonDown("Select Weapon 3"))
        {
            if (weapon3Unlocked)
            {
                selectedWeapon = 3;
                ActiveWeaponSprite.sprite = BSprite3;
            }
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

    private void Pause()
    {
        if(Input.GetButtonDown("Pause/Menu Button"))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                PauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                print("kek");
                PauseMenu.SetActive(false);
            }
        }
    }

    public void OnRespawn()
    {
        

        //Respawn Consumables
        for (var i = 0; i < ConsumablesArray.Length; i++)
        {
            ConsumablesArray[i].SetActive(true);
        }

        //Respawn Enemies
        for (var i = 0; i < EnemiesArray.Length; i++)
        {
            EnemiesArray[i].GetComponent<Enemy>().health = EnemiesArray[i].GetComponent<Enemy>().maxHealth;
            EnemiesArray[i].SetActive(true);
        }

        //Move the Player to the closest Checkpoint
        closestCheckpointDistance = 1000;
        for (var i = 0; i < CheckPointsArray.Length; i++)
        {

            if(Vector3.Distance(transform.position, CheckPointsArray[i].transform.position) < closestCheckpointDistance)
            {
                closestCheckpointDistance = Vector3.Distance(transform.position, CheckPointsArray[i].transform.position);
                closestCheckpointIndex = i;
            }

            
        }
        transform.position = CheckPointsArray[closestCheckpointIndex].transform.position;

        //Refill Player Health
        health = maxHealth;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {

            if (invincible == false)
            {
                StartCoroutine(Invincible());
            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {

            if (invincible == false)
            {
                StartCoroutine(Invincible());
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
