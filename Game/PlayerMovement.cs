using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Vector2 lastMousePosition;
    public bool rightClick, middleClick, onTitan;
    public float zoomSpeed = 3f;
    //public GameObject Moon, Titan;
    void Start()
    {
        lastMousePosition = Input.mousePosition;
    }
    void Update()
    {
        ArrowKeys();
        MiddleClickDragMovement();

        if (!onTitan)
        {
            Zoom(50f, 150f);
            RightClickCamRotation();
        }
        else
        {
            Zoom(80f, 100f);
            PlayerFence();
        }
    }
    public void TeleportPlayer(GameObject body)
    {
        transform.position = new Vector3(body.transform.position.x, transform.position.y, body.transform.position.z);
        transform.position -= transform.forward * 100f;
    }
    void MiddleClickDragMovement()
    {
        if (Input.GetMouseButton(2))
        {
            Vector2 mousePos = Input.mousePosition;
            if (!middleClick)
            {
                middleClick = true;
                lastMousePosition = mousePos;
            }
            Vector2 diff = mousePos - lastMousePosition;

            transform.Translate(-transform.right * diff.x * 2f, Space.World);
            transform.Translate(-transform.forward * diff.y * 2f, Space.World);

            //transform.Translate(transform.right * diff.x * Time.deltaTime, Space.World);
            //transform.Translate(transform.forward * diff.y * Time.deltaTime, Space.World);
            // without below, moves while holding if not where click started (kind of nice actually)
            lastMousePosition = mousePos;
        }
        else
        {
            middleClick = false;
        }
    }
    void RightClickCamRotation()
    {
        if (Input.GetMouseButton(1))
        {
            Vector2 mousePos = Input.mousePosition;
            if (!rightClick)
            {
                rightClick = true;
                lastMousePosition = mousePos;
            }
            Vector2 diff = mousePos - lastMousePosition;

            // Turn
            if (Mathf.Abs(diff.x) > 0)
            {
                transform.Rotate(Vector3.up, diff.x, Space.Self);
            }

            // Look Up/Down
            if (Mathf.Abs(diff.y) > 0)
            {
                Transform camTran = transform.GetChild(0);
                camTran.Rotate(-Vector3.right, diff.y, Space.Self);
                if (camTran.rotation.eulerAngles.x < 20f || camTran.rotation.eulerAngles.x > 70f)
                {
                    camTran.Rotate(Vector3.right, diff.y, Space.Self);
                }
            }

            lastMousePosition = mousePos;
        }
        else
        {
            rightClick = false;
        }
    }
    void ArrowKeys()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Translate(transform.forward, Space.World);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Translate(-transform.forward, Space.World);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(-transform.right, Space.World);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(transform.right, Space.World);
        }
    }
    void Zoom(float lowlimit, float highlimit)
    {
        if (Input.mouseScrollDelta.y == 1f)
        {
            if (transform.position.y > lowlimit)
            {
                transform.Translate(-transform.up * zoomSpeed, Space.World);
                transform.Translate(transform.forward * zoomSpeed, Space.World);
            }
        }
        else if (Input.mouseScrollDelta.y == -1f)
        {
            if (transform.position.y < highlimit)
            {
                transform.Translate(transform.up * zoomSpeed, Space.World);
                transform.Translate(-transform.forward * zoomSpeed, Space.World);
            }
        }
    }
    void PlayerFence()
    {
        Vector3 pos = transform.position;
        if (pos.z < -520f)
        {
            transform.position = new Vector3(pos.x, pos.y, -520f);
        }
        else if (pos.z > 120f)
        {
            transform.position = new Vector3(pos.x, pos.y, 120f);
        }

        if (pos.x < -1100f)
        {
            transform.position = new Vector3(-1100f, pos.y, pos.z); 
        }
        else if (pos.x > 1100f)
        {
            transform.position = new Vector3(1100f, pos.y, pos.z);
        }
    }
}