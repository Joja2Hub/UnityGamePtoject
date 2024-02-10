using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DishesChoiser : MonoBehaviour
{

    public int dishID;
    public GameObject Cup;
    public GameObject spawnPos;
    CupScript cupScript;


    private void Start()
    {
        cupScript = GetComponent<CupScript>();
    }


    public bool cupExist = false;
    private void OnMouseDown()
    {
        if (!cupExist)
        {
            Instantiate(Cup, spawnPos.transform);
            cupExist = true;
        }
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
