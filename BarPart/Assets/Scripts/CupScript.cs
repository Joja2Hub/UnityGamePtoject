using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupScript : MonoBehaviour
{
    public ClientsScript clientSript;
    public GameObject client;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.FindObjectOfType<GameManager>();
    }

    

    public void Awake()
    {
        //gameManager.CupScriptInit();
        client = GameObject.FindGameObjectWithTag("Client");
        clientSript = client.GetComponent<ClientsScript>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "LiquidParticle_air(Clone)")
            clientSript.air++;
        else if (collision.name == "LiquidParticle_Earth(Clone)")
            clientSript.earth++;
        else if (collision.name == "LiquidParticle_Fire(Clone)")
            clientSript.fire++;
        else if (collision.name == "LiquidParticle_Water(Clone)")
            clientSript.water++;
    }

}
