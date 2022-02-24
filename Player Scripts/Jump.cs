using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
public class Jump : MonoBehaviour
{
    public Vector3 jump;
    public float jForce = 2.0f;
    public bool playerGrounded;
    Rigidbody rigidb;

    void Start()
    {
        rigidb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }

    void OnCollisionStay()
    {
        playerGrounded = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerGrounded)
        {

            rigidb.AddForce(jump * jForce, ForceMode.Impulse);
            playerGrounded = false;
        }
    }
}