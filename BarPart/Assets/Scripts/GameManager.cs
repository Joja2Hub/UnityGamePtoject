using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ClientsScript clientSript;
    public GameObject []clients;
    public int currentClientIndex = 0;
    public GameObject spawnPos;

    public float enjoyStats;
    public float patience;
    public float discontent;

    public Slider EnjoySlider;
    public Slider DiscontentSlider;
    public Slider PatienceSlide;
    public Button ServeButton;

    private CupScript cupScript;

    public GameObject dialoger;
    private DialogSystem dialogSystem;
    [SerializeField] int[] dialogIndexArray;
    [SerializeField] int indexTrigger = 1;


    float cirlcDif = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    private void Awake()
    {
        cupScript = FindObjectOfType<CupScript>();
        dialogSystem = FindObjectOfType<DialogSystem>();
    }
    private void Start()
    {
        enjoyStats = 0;
        patience = 0;
        discontent = 0;
    }

    private void Update()
    {
        EnjoySlider.value = enjoyStats;
        DiscontentSlider.value = discontent;
        PatienceSlide.value = patience;

        if (DiscontentSlider.value >= 1 || PatienceSlide.value >= 1)
            ClientGone();
    }

    void SpawnClient()
    {
        Instantiate(clients[currentClientIndex], spawnPos.transform.position, Quaternion.identity);
    }

    public void ClientCum()
    {
        SpawnClient();
        cupScript.cupScriptInit();
        enjoyStats = 0;
        patience = 0;
        discontent = 0;
        clientSript = clients[currentClientIndex].GetComponent<ClientsScript>();
        clientSript.WakeUp();
        ServeButton.gameObject.SetActive(true);
        //Dialog
        dialogSystem.nextDialog(dialogIndexArray[indexTrigger]);
        dialoger.SetActive(true);
        ClienReady();
    }

    void ClienReady()
    {
        ServeButton.interactable = true;
    }

    void ClientGone()
    {
        Debug.Log("ClientGone");
        ServeButton.interactable = false;
        clientSript.ClientGoneAnim();
        currentClientIndex++;
    }

    public void Serve()
    {
        enjoyStatsCalculate();
        Debug.Log(cirlcDif.ToString());
        GameObject[] luqid = GameObject.FindGameObjectsWithTag("Luqid");
        foreach (GameObject go in luqid)
        {
            Destroy (go);
        }
        ServeButton.interactable = false;
        clientSript.TaskReload();
        //Начать диалог
        Dialog();
    }

    void Dialog()
    {
        ClienReady();
    }

    void enjoyStatsCalculate()
    {
        cirlcDif = Vector2.Distance(clientSript.cirle.transform.position, clientSript.perfectPos.transform.position);
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

}
