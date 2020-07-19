using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    private static WeaponSystem instance;
    public static WeaponSystem Instance { get => instance; set => instance = value; }
    public GameObject weapon;
    public Camera cam;
    public Vector2 mousePos;
    public GameObject weaponObject;
    Vector2 playerPos;
    public List<GameObject> weaponAmount = new List<GameObject>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
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
            if (Input.GetKeyDown(KeyCode.Mouse0) && weaponAmount.Count <= 5)
            {
                weaponObject = Instantiate(weapon, playerPos + new Vector2(0, 0.5f), Quaternion.identity);
                weaponAmount.Add(weaponObject);
                //yield return new WaitForSeconds(3f);
            }
            yield return null;
        }
    }
}
