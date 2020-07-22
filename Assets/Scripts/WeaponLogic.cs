using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLogic : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 mousePos;
    public Camera cam;
    GameObject player;

    private void Awake()
    {
        cam = Camera.main;
        //mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        StartCoroutine(WeaponFlying());
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnDestroy()
    {
        WeaponSystem.Instance.weaponAmount.Remove(this.gameObject);
    }
    IEnumerator WeaponFlying()
    {
        float t = 0;
        while (t < 1)
        {
            transform.Translate(mousePos * Time.deltaTime);
            t += Time.deltaTime;
            yield return null;
        }
        Debug.Log("While ended");
        t = 0;
        while (t < 1)
        {
            transform.Translate(player.transform.position - transform.position * Time.deltaTime);
            t += Time.deltaTime;
            yield return null;
        }
 
        StartCoroutine(DestroyWeapon());
    }
    private void Update()
    {
            //transform.Translate(mousePos * Time.deltaTime);
    }
    IEnumerator WeaponFlyingForward()
    {
        transform.Translate(mousePos * Time.deltaTime);
        yield return new WaitForSeconds(1f);
    }
    IEnumerator DestroyWeapon()
    {
        yield return new WaitForSeconds(3f);
        /*if (WeaponSystem.Instance.weaponAmount.Count != 5)
        {
            Destroy(WeaponSystem.Instance.weaponObject);
            weaponAmount.Remove(weaponObject);
        }*/
        Destroy(this.gameObject);
        //yield return null;
    }
}
