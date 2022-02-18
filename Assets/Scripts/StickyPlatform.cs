using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player"){
            collision.gameObject.transform.SetParent(transform);
        }

        if(collision.gameObject.name.Contains("Walking Enemy 2")){
            collision.gameObject.transform.SetParent(transform);
        }
    }

    void OnCollisionExit(Collision other)
    {
        if(other.gameObject.name == "Player"){
            other.gameObject.transform.SetParent(null);
        }
    }
}
