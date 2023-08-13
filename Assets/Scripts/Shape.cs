using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shape : MonoBehaviour
{
    public float speed;
    public int shapeColor;
    public int shapeType;


    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += speed * Time.deltaTime * Vector3.down;
    }

    public void DestroyShape()
    {
       
        Destroy(gameObject);
    }

    public void AddSpeed(float amount)
    {
        speed += amount;
    }
}
