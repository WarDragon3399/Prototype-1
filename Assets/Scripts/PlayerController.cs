using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //GameObject Variables
    [SerializeField] private float speed;
    [SerializeField] TextMeshProUGUI speedoMeterText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] private float turnSpeed = 25.0f;
    [SerializeField] private float horsePower = 0;
    [SerializeField] float rpm;
    private float horizontalInput;
    private float forwardInput;
    public Camera mainCamera;
    public Camera secCamera;
    public KeyCode switchKey;
    //Local Multiplayer Id
    public string inputID;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Players Inputes
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);
        bool ck = IsOnGround();
       if (ck == true)
        {
            
           // Debug.Log(ck);
            //Move the vehicle forward
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);

            //Turn roatation efffects
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

            rpm = Mathf.Round((speed % 30) * 40);
            speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
            speedoMeterText.SetText("Speed : " + speed + "/kph");
            rpmText.SetText("RPM : " + rpm);

        }

        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            secCamera.enabled = !secCamera.enabled;
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if (wheelsOnGround > 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
