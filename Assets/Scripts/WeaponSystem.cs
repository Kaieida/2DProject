using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    public GameObject weapon;
    void Start()
    {
        StartCoroutine(Attacking());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Attacking()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Instantiate(weapon, transform.forward, Quaternion.identity);
            }
            yield return null;
        }
    }
}
