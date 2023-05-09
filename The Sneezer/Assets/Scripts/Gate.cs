using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    private Animator _animator;
    private bool _isPassedByPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Key") && !_isPassedByPlayer) {
            _animator.SetBool("Unlocked", true);
            Destroy(other.gameObject);
        }
    }


    public void Close() {
        _animator.SetBool("Unlocked", false);
        _isPassedByPlayer = true;
    }
}
