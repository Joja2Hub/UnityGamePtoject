using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ClientsScript clientSript;
    public GameObject client;

    public float enjoyStats;
    public float patience;
    public float discontent;

    public Slider EnjoySlider;
    public Slider DiscontentSlider;
    public Slider PatienceSlide;
    public Button ServeButton;


    float cirlcDif = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    private void Start()
    {
        enjoyStats = 0;
        patience = 0;
        discontent = 0;
        ClientCum();
    }

    private void Update()
    {
        EnjoySlider.value = enjoyStats;
        DiscontentSlider.value = discontent;
        PatienceSlide.value = patience;

        if (DiscontentSlider.value >= 1 || PatienceSlide.value >= 1)
            ClientGone();
    }

    void ClientCum()
    {
        enjoyStats = 0;
        patience = 0;
        discontent = 0;
        client = GameObject.FindGameObjectWithTag("Client");
        clientSript = client.GetComponent<ClientsScript>();
        clientSript.WakeUp();
        ServeButton.gameObject.SetActive(true);
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
