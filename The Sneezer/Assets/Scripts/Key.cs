using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool isPicked = false;
    private Rigidbody keyRb;

    // Start is called before the first frame update
    void Start()
    {
        keyRb = GetComponent<Rigidbody>();
        keyRb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPicked) {
            transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);
        }
    }

    public void Picked(Rigidbody player) {
        isPicked = true;
        keyRb.isKinematic = false;
        transform.rotation = new Quaternion(0, 180, 0, 1);
        GetComponent<ConfigurableJoint>().connectedBody = player;
        
    }
}
