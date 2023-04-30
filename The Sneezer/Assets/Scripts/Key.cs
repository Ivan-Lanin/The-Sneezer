using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private bool isPicked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPicked) {
            transform.Rotate(new Vector3(0, 20, 0) * Time.deltaTime);
        }
    }

    public void Picked() {
        isPicked = true;
        transform.rotation = new Quaternion(0, 180, 0, 1);
    }
}
