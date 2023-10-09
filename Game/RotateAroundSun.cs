using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundSun : MonoBehaviour
{
    public float distance, period, speed;


    void Start()
    {
        distance = Vector3.Distance(transform.position, Vector3.zero);
        float adjustedDistance = distance / 100f;
        period = Mathf.Sqrt(Mathf.Pow(adjustedDistance, 3f));
        speed = 1f / period;
    }

    void Update()
    {
        transform.RotateAround(Vector3.zero, Vector3.up, -speed * Time.deltaTime);
        
        // Fix Wobble
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
}
