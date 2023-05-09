using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player) {
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Acceleration);
            Debug.Log("Player is in the water");
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        if (other.gameObject.CompareTag("Player")) {
            player = other.gameObject;
        }
    }


    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            player = null;
        }
    }
}
