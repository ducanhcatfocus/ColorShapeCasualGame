using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Random = UnityEngine.Random;




public class ObjectSpawner : MonoBehaviour
{
    // Start is called before the first frame update
  
    public List<Shape> shapes;

    public List<Shape> shapeInScene;

    public Transform firstPos;
    public Transform secondPos;
    public Transform parent;

    public ChangeColor changeColor = new ChangeColor();
    public ClickPanel clickPanel;

    public float randomRange = 4f;

    private float spawnInterval = 1f;
    private float incSpeed = 0f;
    private bool isInit;

    private void Awake()
    {
        StartCoroutine(SpawnObjectDelay());

    }



    IEnumerator SpawnObjectDelay()

    {
        while (true)
        {
            SpawnObject();
            yield return new WaitForSeconds(spawnInterval);

        }
    }

    private void SpawnObject()
    {
        int randomObject = Random.Range(0, shapes.Count);
        int randomIndex = Random.Range(0, 5);

        
        
        Vector3 randomPos = new Vector3(Random.Range(firstPos.position.x, secondPos.position.x), firstPos.position.y, 0);
        Shape obj = Instantiate(shapes[randomObject], randomPos, Quaternion.identity, parent); 

        obj.shapeColor = randomIndex;
        obj.shapeType = randomObject;
        obj.speed += incSpeed;
    
  
        SpriteRenderer spriteRenderer = obj.GetComponent<SpriteRenderer>(); 
        spriteRenderer.color = changeColor.GetShapeColorByIndex(randomIndex);
        shapeInScene.Add(obj);
        if (!isInit)
        {
            clickPanel.GenerateButtonShape();
            isInit = true;
        }

    }

    public void DestroyShape()
    {
        shapeInScene[0].DestroyShape();
        shapeInScene.RemoveAt(0);
    }

    public Shape GetFirstShape()
    {
        if(shapeInScene.Count != 0)
        {
            return shapeInScene[0];

        }
        return shapes[0];
    }
    public void IncreaseLv()
    {
        spawnInterval -= 0.1f;
        incSpeed += 0.5f;
        foreach (var item in shapeInScene)
        {
            item.speed += incSpeed;
        }
    }
}
