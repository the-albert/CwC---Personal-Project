using System;
using System.Numerics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Player movement
    private float horizontalInput;
    private float verticalInput;
    public float movementSpeed;
    // Camera movement
    private GameObject camera;
    private float mouseInputX;
    private float mouseInputY;
    private float rotationX;
    public float cameraSensitivity;
    // Jumping
    private Rigidbody playerRB;
    public float jumpForce;
    // Boundaries
    public float boundRangeX;
    public float boundRangeZ;
    public float boundRangeY;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("Main Camera");

        playerRB = GetComponent<Rigidbody>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Player movement
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(UnityEngine.Vector3.forward * Time.deltaTime * verticalInput * movementSpeed);
        transform.Translate(UnityEngine.Vector3.right * Time.deltaTime * horizontalInput * movementSpeed);

        // Camera Movement
        mouseInputX = Input.GetAxis("Mouse X");
        mouseInputY = Input.GetAxis("Mouse Y");
        rotationX -= mouseInputY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        
        transform.Rotate(UnityEngine.Vector3.up * mouseInputX * cameraSensitivity * Time.deltaTime);
        camera.transform.localRotation = UnityEngine.Quaternion.Euler(rotationX, 0f, 0f);

        // Jumping
        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(UnityEngine.Vector3.up * jumpForce, ForceMode.Impulse);
        }

        // Checking if Player doesn't move out of boundaries
        if (transform.position.x > boundRangeX)
            transform.position = new UnityEngine.Vector3(boundRangeX, transform.position.y, transform.position.z);
        else if (transform.position.x < -boundRangeX)
            transform.position = new UnityEngine.Vector3(-boundRangeX, transform.position.y, transform.position.z);
        if (transform.position.z > boundRangeZ)
            transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y, boundRangeZ);
        else if (transform.position.z < -boundRangeZ)
            transform.position = new UnityEngine.Vector3(transform.position.x, transform.position.y, -boundRangeZ);
        if (transform.position.y > boundRangeY)
            playerRB.AddForce(UnityEngine.Vector3.down * jumpForce, ForceMode.Impulse);
    }
}
