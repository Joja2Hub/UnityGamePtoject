using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    public GameObject Luqid;
    private Vector3 dragOffset;
    private float dragSpeed = 15f;
    Vector3 rotation;
    private float rotationSpeed = 150f;
    public Transform dropPoint;
    float cooldown = 0;
    public float zRotation;

    private void OnMouseDown()
    {
        dragOffset = this.transform.position - GetMousePosition();
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    }
    private void OnMouseDrag()
    {
        gameObject.transform.GetComponent<Rigidbody2D>().freezeRotation = true;
        gameObject.transform.GetComponent<Rigidbody2D>().freezeRotation = false;
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
        this.transform.position = Vector3.MoveTowards(this.transform.position, GetMousePosition() + dragOffset, dragSpeed);
        if (Input.GetKey(KeyCode.Q))
            rotation = Vector3.forward;
        else if (Input.GetKey(KeyCode.E))
            rotation = Vector3.back;
        else rotation = Vector3.zero;

        
    }

    

    private void Update()
    {
        transform.Rotate(rotation * rotationSpeed * Time.deltaTime);

        if (Input.GetMouseButtonUp(0))
        {
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }

        zRotation = transform.rotation.z;

        if (zRotation > 0.85 || zRotation < -0.85)
        {
            SpawnLuqid();
        }
    }

    private Vector3 GetMousePosition()
    {
        var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        return mousePosition;
    }

    void SpawnLuqid()
    {
        cooldown -= Time.deltaTime;
        while (cooldown < 0)
        {
            cooldown += 0.03f;
            Instantiate(Luqid, dropPoint.position, Quaternion.identity);
        }
    }




}
