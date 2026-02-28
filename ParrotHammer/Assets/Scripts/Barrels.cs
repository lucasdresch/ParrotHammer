using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using UnityEngine;

public class Barrels : MonoBehaviour
{
    public void BateEsq() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(vel().x, vel().y);
        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().AddTorque(100.0f * rot());
        Invoke("BarrelDel", 2.0f);
    }

    public void BateDir() {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-vel().x, vel().y);
        GetComponent<Rigidbody2D>().isKinematic = false;
        GetComponent<Rigidbody2D>().AddTorque(-100.0f * rot());
        Invoke("BarrelDel", 2.0f);
    }

    public void BarrelDel() {
        Destroy(gameObject);
    }
    Vector2 vel() {
        float h = Random.Range(3, 9);
        float d = Random.Range(3, 6);
        return new Vector2(h, d);
    }
    int rot() {
        int r = 0;
        r = Random.Range(1, 10); Debug.Log($"r ={r}");
        if (r > 5f) { 
            r = 1; 
        } else { 
            r = -1; 
        }Debug.Log($"r={r}");
        return r; 
    }
}
