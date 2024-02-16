using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Animator animator;
    public ClientsScript clientSript;
    public GameObject []clients;
    public int currentClientIndex = 0;
    public GameObject spawnPos;
    GameObject currentClient;
    GameObject currentCup;

    public float enjoyStats;
    public float patience;
    public float discontent;

    public Slider EnjoySlider;
    public Slider DiscontentSlider;
    public Slider PatienceSlide;
    public Button ServeButton;

    public CupScript cupScript;
    GameObject cup;
    public DishesChoiser dishesChoiser;

    public DialogSystem dialogue;
    public GameObject dialoger;
    [SerializeField] int[] dialogIndexArray;
    private int drinkCount;


    float cirlcDif = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    private void Awake()
    {

    }


    public void CupScriptInit()
    {
        cupScript = FindObjectOfType<CupScript>();
    }
    private void Start()
    {
        statsInit();
        dishesChoiser = FindObjectOfType<DishesChoiser>();  
    }

    void statsInit()
    {
        enjoyStats = 0;
        patience = 0;
        discontent = 0;
    }

    bool clientGone = false;
    private void Update()
    {
        EnjoySlider.value = enjoyStats;
        DiscontentSlider.value = discontent;
        PatienceSlide.value = patience;

        if ((DiscontentSlider.value >= 1 || PatienceSlide.value >= 1 || EnjoySlider.value >=1) && !clientGone)
        {
            ClientGone();
            clientGone = true;
        }
    }

    void SpawnClient()
    {
        Instantiate(clients[currentClientIndex], spawnPos.transform.position, Quaternion.identity);
        currentClient = GameObject.FindGameObjectWithTag("Client");
        animator = currentClient.GetComponent<Animator>();

    }

    public void ClientCum()
    {
        clientGone = false;
        SpawnClient();
        enjoyStats = 0;
        patience = 0;
        discontent = 0;
        clientSript = clients[currentClientIndex].GetComponent<ClientsScript>();
        
        ServeButton.gameObject.SetActive(true);
        ClienReady();
    }

    void ClienReady()
    {
        ServeButton.interactable = true;
    }

    
    void ClientGone()
    {
        statsInit();
        ServeButton.interactable = false;
        ClientGoneAnim();

        Invoke("ClientUpdate", 3f);
    }



    public void ClientGoneAnim()
    {
        animator.SetTrigger("ClientGone");
    }

    void ClientUpdate()
    {
        Destroy(currentClient);
        currentClientIndex++;
        ClientCum();
    }

    public void Serve()
    {
        Debug.Log(cirlcDif.ToString());
        GameObject[] luqid = GameObject.FindGameObjectsWithTag("Luqid");
        drinkCount = 0;
        foreach (GameObject go in luqid)
        {
            drinkCount++;
            Destroy (go);
        }
        Debug.Log(drinkCount.ToString());
        ServeButton.interactable = false;
        clientSript.TaskReload();
        //Начать диалог
        ClienReady();
        Destroy(currentCup);
        enjoyStatsCalculate();
    }

    void enjoyStatsCalculate()
    {
        cirlcDif = Mathf.Abs(Vector2.Distance(clientSript.cirle.transform.localPosition, clientSript.perfectPos.transform.localPosition));
        if (drinkCount >= 50)
        {
            if (cirlcDif <= 0.15)
            {
                enjoyStats += 0.35f;
                Debug.Log("Perfect");
            }
            else if (cirlcDif <= 0.3)
                enjoyStats += 0.25f;
            else if (cirlcDif <= 0.5)
                enjoyStats += 0.15f;
            else if (cirlcDif <= 1)
                enjoyStats += 0.15f;
            else if (cirlcDif >= 1.5)
            {
                enjoyStats += 0.05f;
                discontent += 0.1f;
            }
        }
        else
        {
            discontent += 0.3f;
                
        }
        drinkCount = 0;
    }
}
