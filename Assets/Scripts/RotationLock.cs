
using UnityEngine;

public class RotationLock : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    Vector3 m_YAxis;
    float m_Speed;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        //Set up vector for moving the Rigidbody in the y axis
        m_YAxis = new Vector3(0, 5, 0);
        m_Speed = 20.0f;
    }

    void Update()
    {
        //Press space to add constraints on the RigidBody (freeze all rotations)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Freeze all rotations
            m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
        }

        //Press the up arrow key to move positively in the y axis
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //The Rigidbody moves along the y axis
            m_Rigidbody.velocity = m_YAxis;
        }

        //Press the down arrow key to move negatively in the y axis
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            m_Rigidbody.velocity = -m_YAxis;
        }

        //Press the A key to rotate the GameObject (if there are no rotation constraints)
        if (Input.GetKey(KeyCode.A))
        {
            m_Rigidbody.angularVelocity = Vector3.right * m_Speed * Time.deltaTime;
        }
    }
}