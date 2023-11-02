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

        //���������
        lines[0][0] = "...";
        lines[0][1] = "...";
        lines[0][2] = "���";
        lines[0][3] = "��� ��� �?";
        lines[0][4] = "��� ���, ��� ��� �� ����";
        lines[0][5] = "����, ������ ����� � ���� �����, �� ����� �� ������� �������";
        lines[0][6] = "...";
        lines[0][7] = "����, � ��� ������?";
        lines[0][8] = "� �� ������� ���� �� ����� ��������";
        lines[0][9] = "...";
        lines[0][10] = "���� ������� ���� ������, ����� ����� ���� �����������";
        lines[0][11] = "...";

        //������ ������
        lines[1][0] = "������. ��� ��� ������";
        lines[1][1] = "...";
        lines[1][2] = "��?";
        lines[1][3] = "...";
        lines[1][4] = "��� ��....";
        lines[1][5] = "PlaceHolder";
        lines[1][6] = "PlaceHolder";
        lines[1][7] = "PlaceHolder";
        lines[1][8] = "PlaceHolder";
        lines[1][9] = "PlaceHolder";
        lines[1][10] = "PlaceHolder";
        lines[1][11] = "PlaceHolder";


    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space)) 
        {
            if(text.text == lines[dialogID][index])
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


    //������ �����
    IEnumerator TypeLine()
    {
        foreach(char c in lines[dialogID][index].ToCharArray()) 
        {
            text.text += c;
            yield return new WaitForSeconds(TextSpeed);
        }

    }

    void NextLine()
    {
        if(index < indexTrigger) 
        {
            index++;
            text.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else if(index == indexTrigger)
        {
            gameManager.ClientCum();
            gameObject.SetActive(false);
        }
    }

}
