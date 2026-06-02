using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Gravity")]

    public float gravityScaleByDefault = 4.0f;
    public float gravityScaleByFallingAfterJump = 7.0f;
    public float gravityScaleByFallingGrapplingMode = 1.5f;

    [Header("Speed Of")]

    public float moveSpeed;
    public float jumpForce;
    public float speedBoost = 900;
    public float speedSlide = 1500;
    public float wallSlidingSpeed = 2f;
    public float horizontalMovement;

    [HideInInspector] public Vector3 velocity = Vector3.zero;
    [HideInInspector] public bool isJumping = false;
    [HideInInspector] public bool isGrounded = false;
    [HideInInspector] public bool isSliding = false;
    [HideInInspector] public bool isWallSliding;

    //wall jump

    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    public Vector2 wallJumpingPower = new Vector2(12f, 16f);

    [Header("Others")]

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public CapsuleCollider2D playerCollider;

    [SerializeField] private Transform wallCheckRight;
    [SerializeField] private Transform wallCheckLeft;
    [SerializeField] private LayerMask wallLayer;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionsLayers;

    public static PlayerMovement instance;

    private void Awake()
    {
        //permet de garder une seule instance commune pour tous les niveaux et de ne pas en créer pour chaque
        if (instance != null)
        {
            Debug.LogWarning("LUIGIIIIIIII");
            return;
        }
        instance = this;
    }

    private void Update()
    {
        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isJumping = true;
        }

        // Le slide, mais bug du coup à intégrer plus tard
        if (Input.GetKeyDown(KeyCode.LeftShift) && isGrounded)
        {
            if(isSliding == false) 
            {
                isSliding = true;
                this.moveSpeed += speedSlide;
                StaminaWheel.instance.stamina += StaminaWheel.instance.staminaGain;
                StartCoroutine(SlideCoroutine());
            }      
        }

        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);

        WallSlide();
        WallJump();

        if(!isWallJumping) 
        {
            // check le sens de direction et non pas la velocité
            Flip(Input.GetAxis("Horizontal"));
        }
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionsLayers);
        MovePlayer(horizontalMovement);
        SetGravity();
    }

    // le _ avant un nom correspond à la convention de nommage concernant les paramètres ayant comme nom le même qu'une variable
    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        if (isGrounded == true || isJumping == true)
        {
            rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        }
        else
        {
            rb.velocity = Vector3.Lerp(rb.velocity, targetVelocity, .05f);
        }


        if (isJumping == true)
        {
            audioManager.instance.PlaySfx(4);
            rb.AddForce(new Vector2(0f, jumpForce));
            if (isGrounded)
            {
                isJumping = false;
            }   
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            if (_velocity < -0.1f)
            {
                spriteRenderer.flipX = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    public IEnumerator SlideCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        this.moveSpeed -= speedSlide;
        isSliding = false;
    }

    private bool IsWalledRight()
    {
        return Physics2D.OverlapCircle(wallCheckRight.position, 0.2f, wallLayer);
    }

    private bool IsWalledLeft()
    {
        return Physics2D.OverlapCircle(wallCheckLeft.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (IsWalledRight() && !isGrounded && horizontalMovement != 0f || IsWalledLeft() && !isGrounded && horizontalMovement != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
            wallJumpingCounter = wallJumpingTime;
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallJumping)
        {
            isWallJumping = false;
            spriteRenderer.flipX = !spriteRenderer.flipX;
            wallJumpingDirection = spriteRenderer.flipX ? -1 : 1;

            // Réinitialiser la vélocité horizontale
            rb.velocity = new Vector2(0f, rb.velocity.y);

            // Appliquer la force d'impulsion
            Vector2 jumpForce = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            rb.AddForce(jumpForce, ForceMode2D.Impulse);

            wallJumpingCounter = 0f;
            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            StaminaWheel.instance.stamina += StaminaWheel.instance.staminaGain;
            wallJumpingCounter = 0f;
        }
    }

    private void SetGravity()
    {  
        // retombée après un saut normal
        if (isJumping && rb.velocity.y < -4.0f)
        {
            rb.gravityScale = gravityScaleByFallingAfterJump;
        }
        // montée de saut normal
        else if (isJumping)
        {
            rb.gravityScale = gravityScaleByDefault;
        }
        else
        {
            rb.gravityScale = gravityScaleByFallingGrapplingMode;
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }
}
