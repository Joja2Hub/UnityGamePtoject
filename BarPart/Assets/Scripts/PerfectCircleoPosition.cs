using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerfectCircleoPosition : MonoBehaviour
{
    public ClientsScript clientSript;
    public GameObject client;

    private void Start()
    {
        client = GameObject.FindGameObjectWithTag("Client");
        clientSript = client.GetComponent<ClientsScript>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Choise_Circle")
            clientSript.Perfect = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Choise_Circle")
            clientSript.Perfect = false;
    }

}
