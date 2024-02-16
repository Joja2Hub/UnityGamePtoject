    using System.Collections;
    using System.Collections.Generic;
    using UnityEditor.PackageManager;
    using UnityEditor.U2D.Path.GUIFramework;
    using UnityEngine;
using UnityEngine.SocialPlatforms;

public class ClientsScript : MonoBehaviour
    {
        public float fire = 0;
    float firePrev = 0;
        public float air = 0;
    float airPrev = 0;
        public float water = 0;
    float waterPrev = 0;
        public float earth = 0;
    float earthPrev = 0;
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

        Vector2 newPos;
        Vector2 cirlePos;
        GameManager gameManager;
        public GameObject client;
        public Animator animator;

        public bool Perfect = false;
        void Start()
        {
        cirlePos.x = newPos.x = Random.Range(-1.3f, 1.4f);
        cirlePos.y = newPos.y = Random.Range(-0.21f, 1.4f);
        //CirleTransform(cirlePos, 200);
        cirle.transform.localPosition = cirlePos;
        gameManager = FindObjectOfType<GameManager>();
        }

        public void TaskReload()
        {
            air = airPrev = fire = firePrev = earth = earthPrev = water = waterPrev = 0f;
            newPos.x = Random.Range(-1.3f, 1.4f);
            newPos.y = Random.Range(-0.21f, 1.4f);
            //CirleTransform(newPos, 2000);
            cirle.transform.localPosition = newPos;
            
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

        //CirleChange
        if (air > airPrev)
        {
            CirleTransform(airOrb.transform.localPosition, airCoeff);
            airPrev = air;
        }
        else if (water > waterPrev)
        {
            CirleTransform(waterOrb.transform.localPosition, waterCoeff);
            waterPrev = water;
        }
        else if (fire > firePrev)
        {
            CirleTransform(fireOrb.transform.localPosition, fireCoeff);
            firePrev = fire;
        }
        else if (earth > earthPrev)
        {
            CirleTransform(earthOrb.transform.localPosition, earthCoeff);
            earthPrev = earth;
        }
    }


        public void CirleTransform(Vector3 target, float movePower)
        {
            cirle.transform.localPosition = Vector3.MoveTowards(cirle.transform.localPosition, target, movePower * Time.deltaTime);//Vector3.Lerp(cirle.transform.localPosition, target, movePower * Time.deltaTime);
            cirlePos = cirle.transform.localPosition;
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
