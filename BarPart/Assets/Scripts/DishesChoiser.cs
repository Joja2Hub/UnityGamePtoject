using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DishesChoiser : MonoBehaviour
{

    public int dishID;
    public GameObject Cup;
    public GameObject spawnPos;
    CupScript cupScript;
    GameManager gameManager;
    

    private void Start()
    {
        
        cupScript = GetComponent<CupScript>();
        gameManager = GetComponent<GameManager>();
        
    }


    public bool cupExist = false;

   
    
    
    private void OnMouseDown()
    {
        if (!cupExist)
        {
            Instantiate(Cup, spawnPos.transform);
            cupInit();
            Vector3 newPosition = gameObject.transform.position;
            newPosition.y = -10f;
            gameObject.transform.position = newPosition;
            cupExist = true;
        }
    }

    public void cupInit()
    {
        Cup = GameObject.FindGameObjectWithTag("Cup");
        cupScript = Cup.GetComponent<CupScript>();
    }

    public void dishChoiserInitLos()
    {
        gameManager.dishesChoiser = null;
    }

    private void Update()
    {
        if(cupExist)
        {
            //gameObject.SetActive(false);
        }   
        else
            gameObject.SetActive(true);
    }

}
