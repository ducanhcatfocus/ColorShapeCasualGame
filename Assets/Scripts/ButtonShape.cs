using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonShape : MonoBehaviour
{
    public ObjectSpawner spawner;
    public ClickPanel clickPanel;
    public int shapeColor;
    public int shapeType;

    void Start()
    {
        spawner = FindObjectOfType<ObjectSpawner>();
        clickPanel = FindObjectOfType<ClickPanel>();
    }

    public void DestroyShape()
    {
        Shape shape = spawner.GetFirstShape();
        if(shape.shapeColor ==  shapeColor && shape.shapeType == shapeType)
        {
            spawner.DestroyShape();
            GameManager.Instance.IncreaseScore(10);
            AudioManager.Instance.PlaySound();

        }
        else
        {
            AudioManager.Instance.PlayWrongSound();

        }
        clickPanel.GenerateButtonShape();
    }
}
