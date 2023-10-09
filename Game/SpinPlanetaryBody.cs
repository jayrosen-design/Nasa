using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPlanetaryBody : MonoBehaviour
{
    public float spin;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 lea = transform.localEulerAngles;
        transform.localEulerAngles = new Vector3(lea.x, lea.y + spin, lea.z);
    }
}
