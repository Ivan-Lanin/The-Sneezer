using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private GameObject cameraFollowMarker;
    private Vector3 cameraFollowMarkerRoomPosition;

    // Start is called before the first frame update
    void Start()
    {
        cameraFollowMarkerRoomPosition = cameraFollowMarker.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player) {
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * 7, ForceMode.Acceleration);
            cameraFollowMarker.transform.position = new Vector3(cameraFollowMarker.transform.position.x, player.transform.position.y + 6.43f, cameraFollowMarker.transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        if (other.gameObject.CompareTag("Player")) {
            cameraFollowMarkerRoomPosition = cameraFollowMarker.transform.position;
            player = other.gameObject;
        }
    }


    private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            player = null;
            cameraFollowMarker.transform.position = cameraFollowMarkerRoomPosition;
        }
    }
}
