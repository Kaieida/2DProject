using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    /*private static WeaponSystem instance;
    public static Player Instance { get => instance; set => instance = value; }*/
    public GameObject weapon;
    public Camera cam;
    Vector2 mousePos;
    Vector2 playerPos;
    void Start()
    {
        StartCoroutine(Attacking());
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector2(transform.position.x, transform.position.y);
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    IEnumerator Attacking()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                //Instantiate(weapon, mousePos - playerPos, Quaternion.identity);
                Debug.Log(mousePos);
            }
            yield return null;
        }
    }
}
