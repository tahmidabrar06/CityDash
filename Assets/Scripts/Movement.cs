using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public CapsuleCollider playerCollider;
    public Transform playerTransform;
    public Animator anim;
    public DeathMenu deathMenu;
    public PauseMenu pauseMenu;
    public ConfigureControls controls;
    private GameObject pickUpEffect;
    public GameObject coinBundleUI;
    public GameObject soundManager;
    public TMP_Text coinBundleAmount;
    public VideoSettings videoSettings;
    public float gravStrength;
    public float gravity;
    public float jumpStrength;
    public float dropStrength;
    public float moveSpeed;
    public float runSpeed;
    public float maxSlideDur;
    public float currentSlideDur;
    public float deathdistance;
    public float deathAnimTime;
    public float deathAnimTimeLimit;
    private float timer = 0f;
    public int coinsCollected;
    private Vector3 jumpDir;
    private Vector3 gravDir;
    private Vector3 moveDir;
    public bool isJumping = true;
    public bool isFalling = false;
    public bool isSliding;
    public bool isDropping;
    public bool isDead;
    public bool isHit = false;
    public bool inPauseMenu = false;
    public bool invincibilityPowerUp;
    public bool coinMultiplierPowerUp;
    public bool coinBundlePickedUp;
    public KeyCode jumpKey;
    public KeyCode rollKey;
    public KeyCode moveLeftKey;
    public KeyCode moveRightKey;
    private void Start()
    {
        pickUpEffect = GameObject.Find("pickUpEffect");
        videoSettings.GetResolution();
        videoSettings.SetResolution(PlayerPrefs.GetInt("ResolutionIndex"));
        pickUpEffect.SetActive(false);
        coinBundleUI.SetActive(false);
        LoadSettings();
    }
    void Update()
    {
        if (isDead == true)
        {
            DeathState();
            deathAnimTime += Time.deltaTime;
            deathMenu.ToggleEndMenu();
            return;
        }
        PlayerPrefs.SetInt("CoinsCollected", coinsCollected);
        Gravity();
        Jump();
        HorizontalMovement();
        Forward();
        Roll();
        Drop();
        Pause();
        PowerUpLayer();
        if(coinBundlePickedUp == true)
        {
            coinBundleAmount.text = "+" + ((PlayerPrefs.GetInt("CoinBundleLevel") * 50) + 50).ToString();
            pickUpEffect.SetActive(true);
            coinBundleUI.SetActive(true);
            timer += Time.deltaTime;
            if (timer >= 1.2f)
            {
                coinBundleUI.SetActive(false);
                pickUpEffect.SetActive(false);
                coinBundlePickedUp = false;
                timer = 0f;
            }
        }
        
        //FOR TESTING
        if(Input.GetKeyDown(KeyCode.I))
        {
            invincibilityPowerUp = true;
        }
        if(Input.GetKeyDown(KeyCode.G))
        {
            coinsCollected += 1000;
        }
        if(Input.GetKeyDown(KeyCode.O))
        {
            coinMultiplierPowerUp = true;
        }
        //TETS
    }
    void Gravity()
    {
        if (!controller.isGrounded && isJumping == true || !controller.isGrounded && isFalling == true)
        {
            gravDir = new Vector3(0, 1, 0);
            gravity += (Time.deltaTime * gravStrength);
            controller.Move(gravDir * gravity * Time.deltaTime);
            //Debug.Log("not grounded");
        }
        else
        {
            gravity = -0.5f;
            controller.Move(gravDir * gravity * Time.deltaTime);
        }
    }
    void Jump()
    {
        if (controller.isGrounded && isSliding == false && Input.GetKeyDown(jumpKey))
        {
            isJumping = true;
            jumpDir = new Vector3(0, 1, 0);
            gravity += jumpStrength;
            controller.Move(jumpDir * gravity * Time.deltaTime);
            anim.SetBool("isJumping", true);
            anim.SetBool("isGrounded", false);
        }
        else if (controller.isGrounded)
        {
            isJumping = false;
            isFalling = false;
            anim.SetBool("isJumping", false);
            anim.SetBool("isGrounded", true);
            //Debug.Log("grounded");
        }
        else if (!controller.isGrounded && isJumping == false)
        {
            isFalling = true;
        }

    }
    void HorizontalMovement()
    {
        if (Input.GetKey(moveLeftKey))
        {
            moveDir = new Vector3(-1, 0, 0);
            controller.Move(moveDir * moveSpeed * Time.deltaTime);
            if (isJumping == false)
            {
                anim.SetFloat("Speed", 0.25f, 0.1f, Time.deltaTime);
            }
        }
        else if (Input.GetKey(moveRightKey))
        {
            moveDir = new Vector3(1, 0, 0);
            controller.Move(moveDir * moveSpeed * Time.deltaTime);
            if (isJumping == false)
            {
                anim.SetFloat("Speed", 0.75f, 0.1f, Time.deltaTime);
            }
        }
        else if (isJumping == false)
        {
            anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
        }
    }
    void Forward()
    {
        moveDir = new Vector3(0, 0, 1);
        controller.Move(runSpeed * moveDir * Time.deltaTime);
    }
    void Roll()
    {
        if (isJumping == false && isDropping == false && isFalling == false && Input.GetKeyDown(rollKey))
        {
            controller.height = 1.5f;
            controller.center = new Vector3(0, 0.75f, 0);
            playerCollider.height = 1.5f;
            playerCollider.center = new Vector3(0, 0.75f, 0);

            isSliding = true;
            anim.SetBool("isRolling", true);
        }
        else if (currentSlideDur > maxSlideDur)
        {
            controller.height = 3;
            controller.center = new Vector3(0, 1.5f, 0);
            playerCollider.height = 3;
            playerCollider.center = new Vector3(0, 1.5f, 0);

            isSliding = false;
            anim.SetBool("isRolling", false);
        }
        if (isSliding == true)
        {
            currentSlideDur += Time.deltaTime;
        }
        else
        {
            currentSlideDur = 0;
        }
    }
    
    void Drop()
    {
        if (!controller.isGrounded && isDropping == false && Input.GetKeyDown(rollKey))
        {
            gravity += -dropStrength;
            isDropping = true;
        }
        else if (isJumping == false || isFalling == true)
        {
            isDropping = false;
        }

    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        GameObject collidedObject = hit.gameObject;
        Collider collidedCollider = collidedObject.GetComponent<Collider>();
        if (hit.point.z > transform.position.z + 0.5f && !hit.gameObject.CompareTag("Ground") && !hit.gameObject.CompareTag("Ground2") && invincibilityPowerUp == false || hit.gameObject.CompareTag("InstaDeath") && invincibilityPowerUp == false || Input.GetKey(KeyCode.K))
        {
            Death();
        }
    }
    void Death()
    {
        //Debug.Log("DEAAAAAAAAAAAAAAAAAAD");          
        isDead = true;
    }
    void DeathState()
    {
        if (deathAnimTime <= deathAnimTimeLimit)
        {
            gravity = -2;
            controller.Move(gravDir * gravity * Time.deltaTime);
            anim.speed = 0.1f;
            runSpeed = 1;
            controller.Move(runSpeed * moveDir * Time.deltaTime);
        }
        else
        {
            return;
        }
    }
    void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            LoadSettings();
            if (Time.timeScale == 0f)
            {
                Time.timeScale = 1f;
                pauseMenu.DesSpawnPauseMenu();
                inPauseMenu = false;
            }
            else
            {
                Time.timeScale = 0f;
                pauseMenu.SpawnPauseMenu();
                inPauseMenu = true;
            }
        }
    }
    void PowerUpLayer()
    {
        if(invincibilityPowerUp == true)
        {
            int targetLayer = LayerMask.NameToLayer("PowerUpLayer");
            gameObject.layer = targetLayer;
        }
        else
        {
            int targetLayer = LayerMask.NameToLayer("Player");
            gameObject.layer = targetLayer;
        }
    }
    
    public void LoadSettings()
    {
        jumpKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("jumpKey", "Space"));
        rollKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("rollKey", "S"));
        moveLeftKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("moveLeftKey", "A"));
        moveRightKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("moveRightKey", "D"));
        coinsCollected = PlayerPrefs.GetInt("CoinsCollected", coinsCollected);
        soundManager.GetComponent<SoundManager>().LoadVolumeLevels();
    }
}