using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;
    private Rigidbody rigidBodyComponent;
    private Vector2 respawnPosition = new Vector2(0, 2);
    private bool jumpKeyPressed;
    private float horizontalInput;
    private int superJumps = 0;
    private bool doubleJump = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidBodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space pressed");
            jumpKeyPressed = true;
        }

        horizontalInput = Input.GetAxis("Horizontal") * 2;
    }

    // FixedUpdate is called once every physics update
    private void FixedUpdate()
    {
        rigidBodyComponent.velocity = new Vector3(horizontalInput, rigidBodyComponent.velocity.y, 0);

        if (jumpKeyPressed)
        {
            //the player is in the air
            if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
            {
                //the player has super jumps available and has only jumped once
                if (superJumps > 0 && !doubleJump)
                {
                    doubleJump = true;
                    superJumps--;
                }
                else
                {
                    return;
                }
            }
            else if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length > 0)
            {
                doubleJump = false;
            }

            rigidBodyComponent.AddForce(Vector3.up * 6, ForceMode.VelocityChange);
            jumpKeyPressed = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch(collision.gameObject.layer)
        {
            case 8: //the object is a moving object
                transform.parent = collision.transform;
                break;
            case 9: //the object is a respawn border (the player should die and respawn)
                gameObject.transform.position = respawnPosition;
                break;
            default: //do nothing
                return;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        transform.parent = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch(other.gameObject.layer)
        {
            case 7: //collect a coin
                superJumps++;
                Destroy(other.gameObject);
                break;
            case 10: //hit a checkpoint
                respawnPosition = other.transform.position;
                Destroy(other.gameObject);
                break;
            default:
                return;
        }
    }
}
