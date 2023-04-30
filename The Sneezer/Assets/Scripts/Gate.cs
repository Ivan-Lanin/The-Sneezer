using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Key")) {
            animator.SetBool("Unlocked", true);
            Destroy(other.gameObject);
        }
    }


    public void Close() {
        animator.SetBool("Unlocked", false);
    }
}
