using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLogic : MonoBehaviour
{
    Vector2 mousePos;
    public Camera cam;
    GameObject position;
    bool isInPosition;
    private void Awake()
    {
        cam = Camera.main;
    }
    void Start()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        StartCoroutine(WeaponFlying());
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
        t = 0;
        while (t < 5)
        {
            transform.Translate((position.transform.position - transform.position) * Time.deltaTime * 3);
            t += Time.deltaTime;
            yield return null;
        }
        if (WeaponSystem.Instance.weaponAmount.Count != 4)
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
        //transform.parent = position.transform;
        float t = 0;
        while (t < 5)
        {
            //position.transform.RotateAround(player.transform.position, new Vector3(0, 0, 1), 200 * Time.deltaTime);
            t += Time.deltaTime;
            yield return null;
        }
        //yield return new WaitForSeconds(1f);
        StartCoroutine(DestroyWeapon());
    }
    IEnumerator DestroyWeapon()
    {
        Destroy(this.gameObject);
        yield return null;
    }
    IEnumerator HUJNJA()
    {
        foreach (GameObject obj in WeaponSystem.Instance.weaponAmount)
        {
            if (obj.GetComponent<WeaponLogic>().isInPosition)
            {

            }
            else
            {

            }
        }
        yield return null;
    }
}
