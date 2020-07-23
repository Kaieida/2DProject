using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLogic : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 mousePos;
    public Camera cam;
    GameObject player;
    GameObject position;

    private void Awake()
    {
        cam = Camera.main;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        StartCoroutine(WeaponFlying());
        player = GameObject.FindGameObjectWithTag("Player");
        position = GameObject.Find(WeaponSystem.Instance.weaponAmount.Count.ToString());
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
        float distance = 5;
        t = 0;
        while (distance > 1.5)
        {
            distance = Vector3.Distance(player.transform.position, transform.position);
            transform.Translate((position.transform.position - transform.position) * Time.deltaTime);
            Debug.Log(distance);
            t += Time.deltaTime;
            yield return null;
        }
        if (WeaponSystem.Instance.weaponAmount.Count != 6)
        {
            StartCoroutine(DestroyWeapon());
        }
        else
        {
            StartCoroutine(WeaponRotation());
        }
    }
    IEnumerator WeaponRotation()
    {
        float t = 0;
        while (t < 5)
        {
            transform.RotateAround(player.transform.position, new Vector3(0, 0, 1), 200 * Time.deltaTime);
            Debug.Log("Rotating");
            t += Time.deltaTime;
            yield return null;
        }
        //yield return new WaitForSeconds(1f);
        StartCoroutine(DestroyWeapon());
    }
    IEnumerator DestroyWeapon()
    {
        //yield return new WaitForSeconds(3f);
        /*if (WeaponSystem.Instance.weaponAmount.Count != 5)
        {
            Destroy(WeaponSystem.Instance.weaponObject);
            weaponAmount.Remove(weaponObject);
        }*/
        Destroy(this.gameObject);
        yield return null;
    }
}
