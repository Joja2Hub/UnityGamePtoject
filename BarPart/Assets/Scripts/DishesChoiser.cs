using System.Collections;
using System.Collections.Generic;
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
            cupExist = true;
            gameManager.dishesChoiser = this;
        }
    }

    public void cupInit()
    {
        Cup = GameObject.FindGameObjectWithTag("Cup");
        cupScript = Cup.GetComponent<CupScript>();
    }

    public void destroerCurCup()
    {
        Destroy(Cup);
        gameManager.dishesChoiser = null;
    }

    private void Update()
    {
        if(cupExist)
        {
            gameObject.SetActive(false);
        }   
        else
            gameObject.SetActive(true);
    }

}
