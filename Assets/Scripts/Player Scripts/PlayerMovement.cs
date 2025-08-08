using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D myRigidbody2D;
    BoxCollider2D myFeetCollider2D;
    public PlayerTakeDamage playerTakeDamage;
    public SpriteRenderer barrierSpriteRenderer;

    Animator animator;

    [SerializeField] float runSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float climbSpeed;
    [SerializeField] float swimSpeed;
    [SerializeField] float dashSpeed;
    [SerializeField] float stompSpeed;
    [SerializeField] float grappleSpeed;
    [SerializeField] float launchSpeed;

    [SerializeField] GameObject arrow;
    [SerializeField] GameObject swap;

    Z grapplePoint;
    Z brazzierPoint;
    Transform grappleRadius;
    SpriteRenderer grappleSpriteRenderer;

    SpriteMask spriteMask;
    BrazzierLight brazzier;

    private TextMeshProUGUI zText;

    float normalGravity;

    public bool canDash = true;
    public bool canTeleport = false;

    public string destinationName;

    public bool isDashing = false;
    bool isStomping = false;
    bool isBreaking = false;
    bool isMelting = false;
    bool isExtinguishing = false;
    bool isBlocking = false;
    bool isJumping = false;
    bool isInWater = false;

    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;
    private bool hasAirDashed = false;

    private int jumpCount = 0;
    [SerializeField] private int maxJumps = 2;
    public bool wasGroundedLastFrame = false;

    private bool isGrappling = false;
    private Vector2 grappleStart;
    private Vector2 grappleEnd;
    private float grappleDuration = 2f;
    private float grappleTimer = 0f;

    [SerializeField] private float fallGravityMultiplier = 2f;

    bool resistCurrent = false;
    bool canClimb = false;

    Vector2 originalVelocity;
    Vector2 originalMoveInput;

    int artifact = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody2D = GetComponent<Rigidbody2D>();
        myFeetCollider2D = GetComponent<BoxCollider2D>();
        normalGravity = myRigidbody2D.gravityScale;
        barrierSpriteRenderer.enabled = false;
        transform.position = GameManager.Instance.returnToTemplePosition;

        if (GameManager.Instance.pressedContinue)
        {
            transform.position = GameManager.Instance.lastCheckpointPosition;
            Debug.Log(transform.position);
            GameManager.Instance.pressedContinue = false;
        }
    }

    void Update()
    {
        Run();
        if (myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ladder")) || (canClimb && myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbable Terrain"))))
        {
            animator.SetBool("isRunning", false);
            myRigidbody2D.gravityScale = 0;
            Climb();
            animator.SetBool("isClimbing", true);
        }
        else if (myRigidbody2D.IsTouchingLayers(LayerMask.GetMask("Water")))
        {   
            animator.SetBool("isRunning", false);
            myRigidbody2D.gravityScale = 0;
            Swim();
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                animator.SetBool("isSwimmingAD", true);
            }
            else
            {
                animator.SetBool("isSwimmingAD", false);
            }
            if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("isSwimmingW", true);
            }
            else
            {
                animator.SetBool("isSwimmingW", false);
            }
            if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isSwimmingS", true);
            }
            else
            {
                animator.SetBool("isSwimmingS", false);
            }
        }
        else if (isDashing)
        {
            myRigidbody2D.gravityScale = 0;
        }
        else
        {
            myRigidbody2D.gravityScale = normalGravity;
        }

        if (myRigidbody2D.IsTouchingLayers(LayerMask.GetMask("Water")))
        {
            if(!isInWater)
            {
                AudioManager.instance.PlayMusic("Swimming");
                isInWater = true;
            }
        }
        else
        {
            if(isInWater)
            {
                AudioManager.instance.PlayMusic("Background");
                isInWater = false;
            }
            animator.SetBool("isSwimmingS", false);
            animator.SetBool("isSwimmingW", false);
            animator.SetBool("isSwimmingAD", false);
        }

        if (myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Terrain")))
        {
            if (!wasGroundedLastFrame)
            {
                animator.SetBool("isJumping", false);
                isJumping = false;
                jumpCount = 0;
            }

            hasAirDashed = false;
        }

        wasGroundedLastFrame = myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Terrain"));

        if (myRigidbody2D.linearVelocity.y < 0)
        {
            myRigidbody2D.gravityScale = normalGravity * fallGravityMultiplier;
        }
        else
        {
            myRigidbody2D.gravityScale = normalGravity;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            artifact = 0;
            resistCurrent = false;
            canClimb = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && GameManager.Instance.hammerUnlocked)
        {
            artifact = 1;
            resistCurrent = true;
            canClimb = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && GameManager.Instance.bowUnlocked)
        {
            artifact = 2;
            resistCurrent = false;
            canClimb = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && GameManager.Instance.wingsUnlocked)
        {
            artifact = 3;
            resistCurrent = false;
            canClimb = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && GameManager.Instance.torchUnlocked)
        {
            artifact = 4;
            resistCurrent = false;
            canClimb = false;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && GameManager.Instance.tridentUnlocked)
        {
            artifact = 5;
            resistCurrent = false;
            canClimb = false;

        }

        if (zText)
        {
            if (grapplePoint.canUse && grapplePoint.artifact == artifact)
            {
                zText.gameObject.SetActive(true);
            }
            else
            {
                zText.gameObject.SetActive(false);
            }

        }

        if (barrierSpriteRenderer.enabled && artifact != 5)
        {
            barrierSpriteRenderer.enabled = false;
        }

        if (canTeleport)
        {
            GameManager.Instance.lastGameScene = destinationName;
            SceneManager.LoadScene(destinationName);
            canTeleport = false;
        }

        if (isGrappling)
        {
            grappleTimer += Time.fixedDeltaTime;
            float t = grappleTimer / grappleDuration;
            t = Mathf.Clamp01(t);

            Vector2 newPos = Vector2.Lerp(grappleStart, grappleEnd, t);
            myRigidbody2D.MovePosition(newPos);

            if (t >= 1f)
            {
                isGrappling = false;
                myRigidbody2D.position = grappleEnd;
                myRigidbody2D.linearVelocity = Vector2.zero;

            }
        }

        if (!(myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ladder")) || (canClimb && myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbable Terrain")))))
        {
            animator.SetBool("isClimbing", false);
        }

        if (!(myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ladder")) || (canClimb && myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbable Terrain"))) || myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Water"))))
            animator.SetBool("isRunning", Input.GetAxis("Horizontal") != 0 && !isDashing && !isJumping);

    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if(!value.isPressed) return;
        animator.SetBool("isJumping", true);
        isJumping = true;

        if (jumpCount < maxJumps)
        {
            myRigidbody2D.linearVelocity = new Vector2(myRigidbody2D.linearVelocity.x, 0f);
            myRigidbody2D.linearVelocity += new Vector2(0f, jumpSpeed);

            jumpCount++;
        }
    }

    void OnDash(InputValue value)
    {
        if (!value.isPressed || !canDash || isDashing) return;

        if (myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Terrain")))
        {
            hasAirDashed = false;
            StartCoroutine(DashRoutine());
        }
        else if (!hasAirDashed && artifact == 3)
        {
            hasAirDashed = true;
            StartCoroutine(DashRoutine());
        }

    }

    IEnumerator DashRoutine()
    {
        isDashing = true;
        canDash = false;
        animator.SetBool("isDashing", true);

        float direction = Mathf.Sign(transform.localScale.x);
        Vector2 dashVelocity = new Vector2(direction * dashSpeed, 0f);

        float elapsed = 0f;
        while (elapsed < dashDuration)
        {
            GetComponent<Rigidbody2D>().linearVelocity = dashVelocity;
            elapsed += Time.deltaTime;
            yield return null;
        }

        isDashing = false;
        animator.SetBool("isDashing", false);

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;

    }

    void OnRightClickSkill(InputValue value)
    {
        // HAMMER
        if (artifact == 1)
        {
            if (value.isPressed)
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isBreaking", true);

                isBreaking = true;
                Invoke("StopBreak", 0.5f);
            }
        }
        // BOW
        else if (artifact == 2)
        {

            if (value.isPressed)
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isShooting", true);
                AudioManager.instance.PlaySFX("Arrow Shoot", 0.5f);

                Vector3 arrowPosition = transform.position + new Vector3(0, 0.18f, 0);
                GameObject arrowInstance = Instantiate(arrow, arrowPosition, arrow.transform.rotation);
                arrowInstance.transform.localScale = new Vector3(0.5f * transform.localScale.x, transform.localScale.x, arrowInstance.transform.localScale.z);

                Invoke("StopShooting", 0.25f);
            }

        }
        // WINGS
        else if (artifact == 3)
        {
            if (value.isPressed && myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Terrain")))
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isLaunching", true);
                AudioManager.instance.PlaySFX("Launch", 1f);

                originalVelocity = myRigidbody2D.linearVelocity;
                myRigidbody2D.linearVelocity = new Vector2(0, transform.localScale.y * launchSpeed);
                originalMoveInput = moveInput;
                moveInput = new Vector2(myRigidbody2D.linearVelocity.x, myRigidbody2D.linearVelocity.y);
                Invoke("StopLaunch", 0.5f);
            }
        }
        // TORCH
        else if (artifact == 4)
        {
            if (value.isPressed)
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isBurning", true);
                AudioManager.instance.PlaySFX("Melt Web", 0.5f);

                isMelting = true;
                Invoke("StopMelt", 0.5f);
            }
        }
        // TRIDENT
        else if (artifact == 5)
        {
            if (value.isPressed && !isBlocking)
            {
                playerTakeDamage.canTakeDamageArrow = false;
                barrierSpriteRenderer.enabled = true;
                isBlocking = true;
                Invoke("StopBlock", 3f);
            }
        }
    }

    void StopShooting()
    {
        animator.SetBool("isShooting", false);
    }

    void OnZSkill(InputValue value)
    {
        // HAMMER
        if (artifact == 1)
        {

            if (value.isPressed)
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isSmashing", true);
                isStomping = true;
                Invoke("StopStomp", 0.5f);
            }
        }

        // BOW
        else if (artifact == 2)
        {
            if (value.isPressed && grapplePoint && grapplePoint.canUse && !isGrappling)
            {
                AudioManager.instance.PlaySFX("Grapple", 0.5f);
                grappleStart = transform.position;
                grappleEnd = grapplePoint.transform.position;
                grappleTimer = 0f;
                isGrappling = true;
                myRigidbody2D.linearVelocity = Vector2.zero;
            }
        }
        // WINGS
        else if (artifact == 3)
        {
            if (value.isPressed)
            {
                GameObject swapInstance = Instantiate(swap, transform.position, transform.rotation);
            }
        }
        // TORCH
        else if (artifact == 4)
        {
            if (value.isPressed && brazzier)
            {
                AudioManager.instance.PlaySFX("Ignite Brazier", 1f);
                brazzier.spriteMask.enabled = true;
                brazzier.spriteRenderer.enabled = true;

            }
        }
        // TRIDENT
        else if (artifact == 5)
        {
            if (value.isPressed)
            {
                animator.SetBool("isRunning", false);
                animator.SetBool("isExtinguishing", true);
                AudioManager.instance.PlaySFX("Extinguish Flame", 0.5f);

                isExtinguishing = true;
                Invoke("StopExtinguish", 0.5f);
            }
        }
    }

    void Run()
    {
        if (isDashing) return;

        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody2D.linearVelocity.y);
        myRigidbody2D.linearVelocity = playerVelocity;

        bool isMovingHorizontally = myRigidbody2D.linearVelocity.x != 0;

        if (isMovingHorizontally)
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody2D.linearVelocity.x) * 0.9f, 0.9f);
        }
    }

    void Climb()
    {
        Vector2 playerVelocity;

        if (Mathf.Abs(moveInput.y) > 0.01f)
        {
            playerVelocity = new Vector2(moveInput.x * climbSpeed, moveInput.y * climbSpeed);
        }
        else
        {
            playerVelocity = new Vector2(moveInput.x * climbSpeed, 0f);
        }

        myRigidbody2D.linearVelocity = playerVelocity;

        myRigidbody2D.position = new Vector2(myRigidbody2D.position.x, Mathf.Round(myRigidbody2D.position.y * 100f) / 100f);

    }

    void Swim()
    {

        Vector2 playerVelocity = new Vector2(moveInput.x * swimSpeed, moveInput.y * swimSpeed);
        myRigidbody2D.linearVelocity = playerVelocity;

    }

    void StopStomp()
    {
        isStomping = false;
        animator.SetBool("isSmashing", false);
    }

    void StopBreak()
    {
        isBreaking = false;
        animator.SetBool("isBreaking", false);

    }

    void StopMelt()
    {
        isMelting = false;
        animator.SetBool("isBurning", false);
    }

    void StopExtinguish()
    {
        isExtinguishing = false;
        animator.SetBool("isExtinguishing", false);
    }

    void StopBlock()
    {
        playerTakeDamage.canTakeDamageArrow = true;
        barrierSpriteRenderer.enabled = false;
        isBlocking = false;
    }

    void StopLaunch()
    {
        animator.SetBool("isLaunching", false);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Air Current"))
        {
            if (!resistCurrent)
            {
                myRigidbody2D.gravityScale = 0;
                myRigidbody2D.AddForce(other.GetComponent<AirCurrent>().forceDirection * other.GetComponent<AirCurrent>().forceStrength, ForceMode2D.Force);
            }
        }
        if (isStomping)
        {
            if (other.CompareTag("Stompable Wall"))
            {
                AudioManager.instance.PlaySFX("Smash Wall", 0.1f);
                Destroy(other.gameObject);
            }
        }

        if (isBreaking)
        {
            if (other.CompareTag("Crushable Wall"))
            {
                AudioManager.instance.PlaySFX("Break Wall", 0.1f);
                Destroy(other.gameObject);
            }
        }

        if (isMelting)
        {
            if (other.CompareTag("Moss Wall"))
            {
                Destroy(other.gameObject);
            }
        }

        if (isExtinguishing)
        {
            if (other.CompareTag("Flame Wall"))
            {
                Destroy(other.transform.parent.gameObject);
            }
        }

        if (other.CompareTag("Grapple"))
        {
            grapplePoint = other.GetComponentInParent<Z>();
            grapplePoint.canUse = true;
            grappleRadius = other.transform.Find("Circle");
            SpriteRenderer spriteRenderer = grappleRadius.GetComponent<SpriteRenderer>();
            if(artifact == 2)
                spriteRenderer.enabled = true;

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Grapple"))
        {
            grapplePoint = other.GetComponentInParent<Z>();
            grapplePoint.canUse = true;
            grappleRadius = other.transform.Find("Circle");
            grappleSpriteRenderer = grappleRadius.GetComponent<SpriteRenderer>();
            if (artifact == 2)
                grappleSpriteRenderer.enabled = true;

        }
        if (other.CompareTag("Brazzier"))
        {
            brazzierPoint = other.GetComponentInParent<Z>();
            GameObject brazzierObj = other.transform.gameObject;
            brazzier = brazzierObj.GetComponentInChildren<BrazzierLight>();
            if (brazzierPoint.oneTimeUse)
            {
                brazzierPoint.canUse = true;
            }
        }
        if (other.CompareTag("Water"))
        {
            myRigidbody2D.gravityScale = 0;
            Vector2 playerVelocity = new Vector2(moveInput.x * swimSpeed, moveInput.y * swimSpeed);
            myRigidbody2D.linearVelocity = playerVelocity;
        }
        if (other.CompareTag("Colletible"))
        {
            AudioManager.instance.PlaySFX("Collectible", 1f);
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Checkpoint"))
        {
            GameManager.Instance.lastCheckpointPosition = other.transform.position;
            AudioManager.instance.PlaySFX("Checkpoint", 0.2f);
        }
        if(other.CompareTag("Air Current"))
            AudioManager.instance.PlaySFX("Air Current", 0.2f);
        if(other.CompareTag("Tutorial"))
            AudioManager.instance.PlaySFX("Tutorial", 0.2f);


    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Grapple"))
        {
            grapplePoint = null;
            grappleSpriteRenderer.enabled = false;
        }
        if (other.CompareTag("Brazzier"))
        {
            brazzierPoint = null;
        }
        if (other.CompareTag("Water"))
        {
            myRigidbody2D.gravityScale = normalGravity;
            myRigidbody2D.linearVelocity = new Vector2(myRigidbody2D.linearVelocity.x, 0);
        }
    }
}