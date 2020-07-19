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
        StartCoroutine(WeaponFlying());
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnDestroy()
    {
        WeaponSystem.Instance.weaponAmount.Remove(this.gameObject);
    }
    IEnumerator WeaponFlying()
    {
        rb.AddForce(WeaponSystem.Instance.mousePos, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        rb.AddForce(player.transform.position*2, ForceMode2D.Impulse);
        StartCoroutine(DestroyWeapon());
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
