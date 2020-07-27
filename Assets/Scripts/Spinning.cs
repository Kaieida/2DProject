using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinning : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //transform.Rotate(new Vector3(0,0,200) * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, 100) * Time.deltaTime * 0.75f);
    }
}
