using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogSystem : MonoBehaviour
{
    [SerializeField] int dialogID = 0;
    private int index = 0;
    //TextMeshPro text;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string[][] lines = new string[99][];
    [SerializeField] float TextSpeed;
    GameManager gameManager;
    int indexTrigger = 11;


    void Start()
    {
        gameManager = GameManager.FindObjectOfType<GameManager>();
        for (int i = 0; i < 99; i++)
        {
            lines[i] = new string[99];
        }

        DialogInit();
        text.text = string.Empty;
        StartDialog();
    }

    public void nextDialog(int newTrig)
    {
        gameObject.SetActive(true);
        indexTrigger = newTrig;
        dialogID++;
        StartDialog();
    }
    void DialogInit()
    {

        //Âòóïëåíèå
        lines[0][0] = "..2.";
        lines[0][1] = "Here's a new day";
        lines[0][2] = "Let see";
        lines[0][3] = "..";
        lines[0][4] = "As I remember, it is necessary to pour so much to the client to keep his \"Mood\" in the center";
        lines[0][5] = "...";
        lines[0][6] = "It seems the first guest is coming. He is very sensitive to the \"hot\"";
        lines[0][7] = "He is also quite silent.";
        lines[0][8] = "However, so do all the customers of this bar. It sounds like a ridiculous excuse for a lazy developer.";
        lines[0][9] = "...";
        lines[0][10] = "Let's get started";
        lines[0][11] = "...";

        lines[0][12] = "...";
        lines[1][0] = "...";

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space))
        {
            if (text.text == lines[dialogID][index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                text.text = lines[dialogID][index];
            }
        }
    }


    void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }


    IEnumerator TypeLine()
    {
        foreach (char c in lines[dialogID][index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }

    }

    void NextLine()
    {
        if (index < indexTrigger)
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else if (index == indexTrigger)
        {
            gameManager.ClientCum();
            gameObject.SetActive(false);
        }
    }

}