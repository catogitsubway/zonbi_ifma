using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float VidaPlayer = 100f;
    [SerializeField] private Transform player;
    private Vector3 dir;
    private Rigidbody rb;
    public bool playerIsOnTheGround = true;

    public float speed;
    float originalSpeed;
    public float croushingSpeed;
    bool croush, croushing;
    bool isCrouching = false; // Variável para controlar se o jogador está agachado
    bool isRunning = false; // Variável para controlar se o jogador está correndo

    [SerializeField] private Transform camPivot;
    [SerializeField] private Transform cam;

    public Vector3 GetForwardDirection() => transform.forward;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        originalSpeed = speed;
    }

    void Update()
    {
        dir = player.TransformVector(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized);

        if (VidaPlayer <= 0)
        {
            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.None;
        }

        HandleInput();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            playerIsOnTheGround = true;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + dir * (isRunning ? speed * 2 : speed) * Time.fixedDeltaTime);
        HandleMoviment();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "maoInimigo")
        {
            VidaPlayer -= 10f;
        }
    }

    void HandleMoviment()
    {
        if (isCrouching)
        {
            speed = croushingSpeed;
            cam.localPosition = new Vector3(0, 1, 0);
        }
        else
        {
            speed = originalSpeed;
            cam.localPosition = new Vector3(0, 2, 0);
        }
    }

    void HandleInput()
    {
        if (Input.GetButtonDown("Jump") && playerIsOnTheGround)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            playerIsOnTheGround = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            isCrouching = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isRunning = false;
        }
    }
    
    public void AddVida(int amount)
    {
        VidaPlayer += amount;
    }

}
