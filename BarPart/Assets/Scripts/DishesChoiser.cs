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

    private void OnMouseDown()
    {
        Instantiate(Cup, spawnPos.transform);
        cupScript.cupScriptInit();
        Debug.Log("Loa");
    }
}
