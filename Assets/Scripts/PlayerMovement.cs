
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float movementSpeed = 6f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask ground;
    Vector3 newPosition;

    public LayerMask whatCanBeClickOn;
    private NavMeshAgent meshAgent;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        newPosition = transform.position;
        meshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector3(horizontalInput * movementSpeed, rb.velocity.y, verticalInput * movementSpeed);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }

        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100, whatCanBeClickOn))
            {
                meshAgent.SetDestination(hit.point);
            }

        }

        // if(Input.GetKey("up")){
        //     rb.velocity = new UnityEngine.Vector3(rb.velocity.x,rb.velocity.y,5f);
        // }

        // if(Input.GetKey("right")){
        //     rb.velocity = new UnityEngine.Vector3(5f,rb.velocity.y,rb.velocity.z);
        // }

        // if(Input.GetKey("left")){
        //     rb.velocity = new UnityEngine.Vector3(-5f,rb.velocity.y,rb.velocity.z);
        // }

        //  if(Input.GetKey("down")){
        //     rb.velocity = new UnityEngine.Vector3(rb.velocity.x,rb.velocity.y,-5f);
        // }
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            Jump();
        }
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, .1f, ground);
    }


}
