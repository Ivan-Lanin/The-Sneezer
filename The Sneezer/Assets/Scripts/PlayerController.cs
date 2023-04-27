using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private float jumpAmount;
    private Rigidbody playerRb;
    private float horizontalInput;
    [SerializeField] List<Collider> groundCollisions = new List<Collider>();

    private enum JumpOptions {
        Fart,
        Sneeze
    }


    // Start is called before the first frame update
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        
        //InvokeRepeating("JumpSneeze", 3, 3);
    }

    // Update is called once per frame
    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        MovePlayer(horizontalInput);

        if (Input.GetMouseButtonDown(0) && IsTouchingAnyGround()) {
        //if (Input.GetKeyDown(KeyCode.Space) && IsTouchingAnyGround()) {
            Jump(JumpOptions.Sneeze);
        }

        if (Input.GetMouseButtonDown(1) && IsTouchingAnyGround()) {
        //if (Input.GetKeyDown(KeyCode.LeftShift) && IsTouchingAnyGround()) {
            Jump(JumpOptions.Fart);
        }

        IsTouchingAnyGround();
    }

    
    private void Jump(JumpOptions action) {
        Vector3 direction = Vector3.zero;
        if (action == JumpOptions.Sneeze) {
            direction = Vector3.up;
        }
        else if (action == JumpOptions.Fart) {
            direction = Vector3.down;
        }
        playerRb.AddRelativeForce(direction * jumpAmount, ForceMode.Impulse);
    }


    private void MovePlayer(float direction) {
        playerRb.AddTorque(Vector3.back * speed * direction);
        if (IsTouchingAnyGround()) {
            playerRb.AddForce(Vector3.right * speed * direction);
        }
    }

    private bool IsTouchingAnyGround() {
        return groundCollisions.Count != 0;
    }


    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.CompareTag("Ground")) {
            groundCollisions.Add(collision.collider);
            Debug.Log(collision.collider.name + "Enter");
        }
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.collider.CompareTag("Ground")) {
            groundCollisions.Remove(collision.collider);
        }
        Debug.Log(collision.collider.name + "Exit");
    }
}
