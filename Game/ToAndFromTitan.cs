using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ToAndFromTitan : MonoBehaviour
{
    public GameObject Player;
    public float speed;
    public GameObject moon, titan;
    public bool otw;
    public int missionNum;

    void Start()
    {
        otw = true;
        missionNum = 1;
    }

    void Update()
    {
        transform.GetChild(0).LookAt(Player.transform.position);
        transform.GetChild(1).LookAt(Player.transform.position);

        if (otw)
        {
            PointToward(titan, 1f);
            MoveToward(speed);
            if (Vector3.Distance(transform.position, titan.transform.position) < 10f) // Has Reached Titan
            {
                otw = false;
                StartCoroutine(DisplayGot());
                missionNum++;
                transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "Mission " + missionNum.ToString();
                Player.GetComponent<PlayerData>().MissionNumber++;
            }
        }
        else
        {
            PointToward(moon, 1f);
            MoveToward(speed);
            if (Vector3.Distance(transform.position, moon.transform.position) < 10f) // Has Reached Moon
            {
                otw = true;
                missionNum++;
                transform.GetChild(1).GetChild(0).GetComponent<TextMeshPro>().text = "Mission " + missionNum.ToString();
                Player.GetComponent<PlayerData>().MissionNumber++;
            }
        }
    }
    void PointToward(GameObject target, float speed)
    {
        Vector3 targetDirection = target.transform.position - transform.position;
        float singleStep = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
    void MoveToward(float speed)
    {
        //transform.Translate(transform.forward * speed);
        transform.position += transform.forward * speed;
    }
    IEnumerator DisplayGot()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
