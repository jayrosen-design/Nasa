using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance { get; private set; }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    /////////////////////////////////////////////////////
    
    public Vector3 StartPosition, TitanSurfacePosition;
    public float GameTime = 0;
    public int MissionNumber = 1;
    public GameObject GameTimeUI, MissionNumUI, GoMoonBtn, GoTitanBtn;

    private void Start()
    {
        StartPosition = transform.position;
        TitanSurfacePosition = new Vector3(StartPosition.x, StartPosition.y, -400f);
    }

    private void Update()
    {
        GameTime += Time.deltaTime;
        GameTimeUI.GetComponent<TextMeshProUGUI>().text = "Day: " + GameTime.ToString("N0");

        MissionNumUI.GetComponent<TextMeshProUGUI>().text = "Mission: " + MissionNumber.ToString("N0");

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object

                /*if (hit.transform.name == "Titan")
                {
                    //GameTimeUI.GetComponent<TextMeshProUGUI>().color = Color.black;
                    GoMoonBtn.SetActive(false);
                    GoTitanBtn.SetActive(false);
                    transform.position = TitanSurfacePosition;
                    transform.rotation = Quaternion.identity;
                    transform.GetChild(0).rotation = Quaternion.Euler(45f, 0f, 0f);
                    GetComponent<PlayerMovement>().onTitan = true;
                    SceneManager.LoadScene("Titan Surface");
                }*/
            }
        }
    }
}