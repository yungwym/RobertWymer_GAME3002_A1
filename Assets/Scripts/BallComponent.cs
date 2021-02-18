using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BallComponent : MonoBehaviour
{
    //Cache 
    [SerializeField]
    private Rigidbody m_rb = null;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    //Launch Variables 
    public Transform m_targetTransform;
    public float thetaAngle = 45.0f;

    //State
    private bool m_bIsGrounded;

    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
        Assert.IsNotNull(m_rb, "Houston, we've got a problem! Rigidbody is not attached!");

        m_bIsGrounded = true;
        initialPosition = transform.position;
        initialRotation = transform.rotation;

        
    }

    public void Update()
    {
        if (!m_bIsGrounded)
        {
            transform.rotation = Quaternion.LookRotation(m_rb.velocity);
        }
    }

    public void LaunchBall()
    {
        if (m_bIsGrounded)
        {
            //Set grounded to false, restricts from reshooting 
            m_bIsGrounded = false;

            //Get positions of Ball and Target, excluding Y 
            Vector3 ballXZPos = new Vector3(transform.position.x, 0.0f, transform.position.z);
            Vector3 targetXZPos = new Vector3(m_targetTransform.position.x, 0.0f, m_targetTransform.position.z);

            //Rotate ball towards target 
            transform.LookAt(targetXZPos);

            //Calculate Distance between Ball and Target
            float distance = Vector3.Distance(ballXZPos, targetXZPos);

            //Calculate the Tan of Theta and Heights
            float tanTheta = Mathf.Tan(thetaAngle * Mathf.Deg2Rad);
            float height = (m_targetTransform.position.y - transform.position.y);

            /*
            //Calculate Velocity 
            float ballVelocity = distance / (Mathf.Sin(2 * thetaAngle * Mathf.Deg2Rad) / gravity);

            //Calcualte X and Y component of velocity 
            float Vz = Mathf.Sqrt(ballVelocity) * Mathf.Cos(thetaAngle * Mathf.Deg2Rad);
            float Vy = Mathf.Sqrt(ballVelocity) * Mathf.Sin(thetaAngle * Mathf.Deg2Rad);
             */

            //Calculate x and Y Component of the velocity
            float Vz = Mathf.Sqrt(Physics.gravity.y * distance * distance / (2.0f * (height - distance * tanTheta)));
            float Vy = tanTheta * Vz;

            //Create velocity vector in local and global space
            Vector3 localVelocity = new Vector3(0, Vy, Vz);
            Vector3 globalVelocity = transform.TransformDirection(localVelocity);

            m_rb.velocity = globalVelocity;
        }
    }

    public void OnMoveLeft()
    {
        transform.Translate(Vector3.left * 5.0f * Time.deltaTime);
    }

    public void OnMoveRight()
    {
        transform.Translate(Vector3.right * 5.0f * Time.deltaTime);
    }

    public void OnBallReset()
    {
        //Reset the Velocity to zero, along with position and rotation 
        m_rb.velocity = Vector3.zero;
        transform.SetPositionAndRotation(initialPosition, initialRotation);
        m_bIsGrounded = true;
    }
}
