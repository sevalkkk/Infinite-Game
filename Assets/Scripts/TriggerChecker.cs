using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    private Rigidbody rb;
    
    private void Start()
    {
        
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag== "player")
        {
            Invoke("FallDown", 1f);
           
        }
    }

    private void FallDown()
    {
        rb = GetComponentInParent<Rigidbody>();
        rb.useGravity = true;
        rb.isKinematic = false;
        StartCoroutine(c());
        
        
        //StartCoroutine(DestroyAfterTime());
        //Destroy(gameObject);
    }

    private IEnumerator c()
    {
        yield return new WaitForSeconds(1f);
        transform.parent.gameObject.SetActive(false);
    }

    // private IEnumerator DestroyAfterTime()
    // {
    //     yield return new WaitForSeconds(1f);

    // }
}
