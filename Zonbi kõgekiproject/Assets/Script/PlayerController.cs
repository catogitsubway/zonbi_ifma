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

    [SerializeField] private float maxY;
    [SerializeField] private float rX;

    [SerializeField] private Transform camPivot;
    [SerializeField] private Transform cam;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

    }
    void Update()
    {
        dir = player.TransformVector(new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized);

        rX = Mathf.Lerp(rX, Input.GetAxisRaw("Mouse X") * 2, 100 * Time.deltaTime);
        maxY = Mathf.Clamp(maxY - (Input.GetAxisRaw("Mouse Y") * 2 * 100 * Time.deltaTime), -30, 30);

        player.Rotate(0, rX, 0, Space.World);

        cam.rotation = Quaternion.Lerp(cam.rotation, Quaternion.Euler(maxY * 2, player.eulerAngles.y, 0), 100 * Time.deltaTime);

        camPivot.position = Vector3.Lerp(camPivot.position, player.position, 10 * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && playerIsOnTheGround)
        {
            rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            playerIsOnTheGround = false; 
        }
        
        if(VidaPlayer <= 0)
        {
            SceneManager.LoadSceneAsync("GameOver");
            Cursor.lockState = CursorLockMode.None;
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            playerIsOnTheGround = true;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + dir * 10 * Time.fixedDeltaTime);

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "maoInimigo")
        {
            VidaPlayer -= 10f;
        }
    }
}