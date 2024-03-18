using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float x,y;
    private bool isFren;
    
    private float currentFrenForce;
    private float currentDonusAcisi;

    public float hiz_ayar;
    public float speed;

    private Rigidbody rb;


    [SerializeField] private float maxDonusAcisi;
    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;


    [SerializeField] private WheelCollider onSolCollider;
    [SerializeField] private WheelCollider onSagCollider;
    [SerializeField] private WheelCollider arkaSolCollider;
    [SerializeField] private WheelCollider arkaSagCollider;

    [SerializeField] private Transform onSolTransform;
    [SerializeField] private Transform onSagTransform;
    [SerializeField] private Transform arkaSolTransform;
    [SerializeField] private Transform arkaSagTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Time.timeScale = 1;
    }

    private void FixedUpdate()
    {
        if (Cursor.lockState == CursorLockMode.Locked & CarCharge.instance.sayac > 15)
        {
            motorForce = 800;
            getUserInput();
            moveCar();
            rotateCar();
            rotateWheels();
            Time.timeScale = 1;
        }
        else if (CarCharge.instance.sayac <= 15)
        {
            motorForce = 100;
            getUserInput();
            moveCar();
            rotateCar();
            rotateWheels();

            
            //rb.velocity =new Vector3(0, 0, Mathf.Lerp(rb.velocity.z, 0, 5 * Time.deltaTime));

        }
            
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            resetCarRotation();
        }
    }

    private void getUserInput()
    {
        y = Input.GetAxis("Horizontal");
        x = Input.GetAxis("Vertical");
        isFren = Input.GetKey(KeyCode.Space);

        speed = transform.InverseTransformDirection(rb.velocity).z * hiz_ayar;

    }

    private void resetCarRotation()
    {
        Quaternion rotation = transform.rotation;
        rotation.z = 0f;
        rotation.x = 0f;
        transform.rotation = rotation;
        transform.position = new Vector3(transform.position.x, 1, transform.position.z);
    }
    private void moveCar()
    {
        onSolCollider.motorTorque = x * motorForce;
        onSagCollider.motorTorque = x * motorForce;
        currentFrenForce = isFren ? breakForce : 0f;
        if (isFren)
        {
            onSolCollider.brakeTorque = currentFrenForce;
            onSagCollider.brakeTorque = currentFrenForce;
            arkaSolCollider.brakeTorque = currentFrenForce;
            arkaSagCollider.brakeTorque = currentFrenForce;
        }
        else
        {
            onSolCollider.brakeTorque = 0f;
            onSagCollider.brakeTorque = 0f;
            arkaSolCollider.brakeTorque = 0f;
            arkaSagCollider.brakeTorque = 0f;
        }
    }

    private void rotateCar()
    {
        currentDonusAcisi = maxDonusAcisi * y;
        onSolCollider.steerAngle = currentDonusAcisi;
        onSagCollider.steerAngle = currentDonusAcisi;
    }

    private void rotateWheels()
    {
        rotateWheel(onSolCollider, onSolTransform);
        rotateWheel(onSagCollider, onSagTransform);
        rotateWheel(arkaSolCollider, arkaSolTransform);
        rotateWheel(arkaSagCollider, arkaSagTransform);
       
    }

    private void rotateWheel(WheelCollider tekerlekCollider, Transform tekerlekTransform)
    {
        Vector3 position;
        Quaternion rotation;
        tekerlekCollider.GetWorldPose(out position, out rotation);
        tekerlekTransform.position = position;
        tekerlekTransform.rotation = rotation;


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            Score.instance.UpdateScore();
            other.gameObject.SetActive(false);
        }
    }

}
