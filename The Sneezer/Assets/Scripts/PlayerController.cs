using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float jumpAmount;
    private Rigidbody playerRb;
    private float horizontalInput;
    [SerializeField] List<Collider> groundCollisions = new List<Collider>();
    private Animator animator;
    private GameObject key;
    private bool isInWater = false;
    private float rotationBoost = 1;

    private enum JumpOptions {
        Fart,
        Sneeze
    }


    // Start is called before the first frame update
    private void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        //InvokeRepeating("JumpSneeze", 3, 3);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && (IsTouchingAnyGround() || isInWater)) {
        //if (Input.GetKeyDown(KeyCode.Space) && IsTouchingAnyGround()) {
            //Jump(JumpOptions.Sneeze);
            StartCoroutine(Jump(JumpOptions.Sneeze));
        }

        if (Input.GetMouseButtonDown(1) && (IsTouchingAnyGround() || isInWater)) {
        //if (Input.GetKeyDown(KeyCode.LeftShift) && IsTouchingAnyGround()) {
            StartCoroutine(Jump(JumpOptions.Fart));
        }
    }


    private void FixedUpdate() {
        horizontalInput = Input.GetAxis("Horizontal");

        MovePlayer(horizontalInput);
    }


    IEnumerator Jump(JumpOptions action) {
        Vector3 direction = Vector3.zero;
        if (action == JumpOptions.Sneeze) {
            animator.SetTrigger("Sneeze");
            yield return new WaitForSeconds(0.15f);
            direction = Vector3.up;
        }
        else if (action == JumpOptions.Fart) {
            animator.SetTrigger("Fart");
            yield return new WaitForSeconds(0.15f);
            direction = Vector3.down;
        }
        playerRb.AddRelativeForce(direction * jumpAmount, ForceMode.Impulse);
    }


    private void MovePlayer(float direction) {
        playerRb.AddTorque(Vector3.back * (rotationSpeed * rotationBoost) * direction * Time.deltaTime, ForceMode.Acceleration);
        if (IsTouchingAnyGround()) {
            playerRb.AddForce(Vector3.right * speed * direction * Time.deltaTime);
        }
    }

    private bool IsTouchingAnyGround() {
        return groundCollisions.Count > 0;
    }


    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            groundCollisions.Add(collision.collider);
            //Debug.Log(collision.collider.name + "Enter");
        }

        
    }

    private void OnCollisionExit(Collision collision) {
        if (collision.collider.CompareTag("Ground")) {
            groundCollisions.Remove(collision.collider);
        }

        if (collision.gameObject.CompareTag("Water")) {
            isInWater = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Key")) {
            key = other.gameObject;
            other.gameObject.GetComponent<Key>().Picked(playerRb);
        }

        if (other.gameObject.CompareTag("Level entrance")) {
            playerRb.velocity = Vector3.zero;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Water")) {
            isInWater = true;
            rotationBoost = 1;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Water")) {
            isInWater = false;
            rotationBoost = 1;
        }
    }
}
