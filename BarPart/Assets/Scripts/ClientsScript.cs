using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEditor.U2D.Path.GUIFramework;
using UnityEngine;

public class ClientsScript : MonoBehaviour
{
    public int fire = 0;
    int firePrev = 0;
    public int air = 0;
    int airPrev = 0;
    public int water = 0;
    int waterPrev = 0;
    public int earth = 0;
    int earthPrev = 0;
    public float airCoeff;
    public float waterCoeff;
    public float earthCoeff;
    public float fireCoeff;   
    public string drunkInfo;

    public GameObject cirle;
    public GameObject fireOrb;
    public GameObject airOrb;
    public GameObject waterOrb;
    public GameObject earthOrb;
    public GameObject perfectPos;

    Vector2 cirlePos;
    GameManager gameManager;
    public GameObject client;
    public Animator animator;

    public bool Perfect = false;
    void Start()
    {
        cirle.transform.position = cirlePos;
        cirlePos.x = Random.Range(-1 * 7, 1 * 4);
        cirlePos.y = Random.Range((float)-0.1 * 7, (float)1.3 * 4);
        gameManager = FindObjectOfType<GameManager>();
    }

    public void TaskReload()
    {
        Debug.Log(cirle.transform.position);
        Debug.Log(cirlePos);
        cirlePos.x = Random.Range(-1 * 7, 1 * 4);
        cirlePos.y = Random.Range((float)-0.1 * 7, (float)1.3 * 4);
        cirle.transform.position = cirlePos;
        CirleTransform(cirlePos, 5);
        Debug.Log("New "+ cirle.transform.position);
        Debug.Log("New " + cirlePos);
        air = airPrev = fire = firePrev = earth = earthPrev = water = waterPrev = 0;
    }

    private void Awake()
    {
        clientInit();
    }

    void clientInit()
    {
        client = GameObject.FindGameObjectWithTag("Client");
    }


    void Update()
    {
        /*if(Input.GetKeyDown(KeyCode.K)) 
        {
            WakeUp();
        }
        */

        //CirleChange
        if(air > airPrev)
        {
            CirleTransform(airOrb.transform.position, airCoeff);
            airPrev = air;
        }
        if(water > waterPrev)
        {
            CirleTransform (waterOrb.transform.position, waterCoeff);
            waterPrev = water;
        }
        if(fire > firePrev)
        {
            CirleTransform(fireOrb.transform.position, fireCoeff);
            firePrev = fire;
        }
        if(earth > earthPrev)
        {
            CirleTransform(earthOrb.transform.position, earthCoeff);
            earthPrev = earth;
        }
    }


    void CirleTransform(Vector3 target, float movePower)
    {
        cirle.transform.position = Vector3.MoveTowards(cirlePos, target, movePower * Time.deltaTime);
        cirlePos = cirle.transform.position;
    }

    public void WakeUp()
    {
        fireOrb.SetActive(true);
        airOrb.SetActive(true);
        waterOrb.SetActive(true);
        earthOrb.SetActive(true);
        cirle.SetActive(true);
    }


    public void WakeDown()
    {
        fireOrb.SetActive(false);
        airOrb.SetActive(false);
        waterOrb.SetActive(false);
        earthOrb.SetActive(false);
        cirle.SetActive(false);
    }

    public void ClientDestroyer()
    {
        Debug.Log("ClientGoneWith 2f");
        //Destroy(gameObject);
    }


    //dialog system

    [SerializeField] bool firstInteraction = true;
    [SerializeField] int repeatStartPosition;
    public string npcName;
    public DialogSystem dialogueAsset;
    [HideInInspector]
    public int StartPosition
    {
        get
        {
            if (firstInteraction)
            {
                firstInteraction = false;
                return 0;
            }
            else
            {
                return repeatStartPosition;
            }
        }
    }
}
