using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonRotation : MonoBehaviour
{
    public GameObject planet;
    public float distance, period, speed;

    void Start()
    {
        distance = Vector3.Distance(transform.position, planet.transform.position);
        float adjustedDistance = distance / 100f;
        period = Mathf.Sqrt(Mathf.Pow(adjustedDistance, 3f));
        speed = 1f / period;
    }

    void Update()
    {
        transform.RotateAround(planet.transform.position, Vector3.up, -speed * Time.deltaTime);
    }
}
