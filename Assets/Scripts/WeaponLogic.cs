using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLogic : MonoBehaviour
{
    Rigidbody2D rb;
    //Vector2 mousePos;
    GameObject player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //StartCoroutine(WeaponFlying());
        //player = 
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
            rb.AddForce(transform.up, ForceMode2D.Impulse);
        }
    }
}
