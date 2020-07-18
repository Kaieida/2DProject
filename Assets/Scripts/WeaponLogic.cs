using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLogic : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //StartCoroutine(WeaponFlying());
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(transform.up,ForceMode2D.Force);
    }
    IEnumerator WeaponFlying()
    {
        while (true)
        {
            rb.AddForce(transform.forward);
        }
    }
}
