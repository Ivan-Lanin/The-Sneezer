using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEnterTrigger : MonoBehaviour
{
    [SerializeField] private GameObject cameraFollowMarker;
    [SerializeField] private GameObject firstGate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        if (other.gameObject.CompareTag("Player")) {
            cameraFollowMarker.transform.position = new Vector3(cameraFollowMarker.transform.position.x + 29.7f, cameraFollowMarker.transform.position.y, cameraFollowMarker.transform.position.z);
            firstGate.GetComponent<Gate>().Close();
        }
    }
}
