using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickPanel : MonoBehaviour
{   
    ChangeColor changeColor = new ChangeColor();
    public ButtonShape buttonShapePrefab;
    public ObjectSpawner objectSpawner;
    public List<Sprite> sprites;
    public Transform parent;
    public int numberofbutton = 6;
    public int numberofcolor = 6;

    public void GenerateButtonShape()
    {
        ButtonShape[] buttonShapes = parent.GetComponentsInChildren<ButtonShape>();
        Shape shape = objectSpawner.GetFirstShape();
        int matchShapeIndex = Random.Range(0, numberofbutton - 1);
     
        if (buttonShapes.Length == 0 )
        {
          
            for (int i = 0; i < numberofbutton; i++)
            {
            
                if (i == matchShapeIndex)
                {
               
                    ButtonShape buttonShape = Instantiate(buttonShapePrefab, parent);
                    SetOneButtonShape(buttonShape, shape.shapeColor, shape.shapeType);

                }
                else
                {
                    CreateButtonShape(shape.shapeType, shape.shapeColor);

                }
            }
        }
        else
        {
     
            SetOneButtonShape(buttonShapes[matchShapeIndex], shape.shapeColor, shape.shapeType);
            for (int i = 0; i < buttonShapes.Length; i++)
            {
            

                if (i != matchShapeIndex)
                {
                    UpdateButtonShape(buttonShapes[i], shape.shapeType, shape.shapeColor);

                }
            }
       
        }
       
    }

    private void CreateButtonShape(int shapeMatchType, int shapeMatchColor)
    {
        ButtonShape buttonShape = Instantiate(buttonShapePrefab, parent);



        UpdateButtonShape(buttonShape, shapeMatchType, shapeMatchColor);
    }

    private void UpdateButtonShape(ButtonShape buttonShape, int shapeMatchType, int shapeMatchColor)
    {
        int shapeIndex = GetRandomIndexExcludingValue(0, sprites.Count, shapeMatchType);
        int colorIndex = GetRandomIndexExcludingValue(0, numberofcolor - 1, shapeMatchColor);

        SetOneButtonShape(buttonShape, colorIndex, shapeIndex);
    }

    private void SetOneButtonShape(ButtonShape buttonShape, int colorIndex, int shapeIndex )
    {
        buttonShape.shapeColor = colorIndex;
        buttonShape.shapeType = shapeIndex;
        Image spriteRenderer = buttonShape.GetComponent<Image>();
        spriteRenderer.sprite = sprites[shapeIndex];
        spriteRenderer.color = changeColor.GetShapeColorByIndex(colorIndex);
    }

    private int GetRandomIndexExcludingValue(int min, int max, int exludedValue)
    {
        int random;
        do
        {
            random = Random.Range(min, max);
        }while(random == exludedValue);

        return random;

    }

  


}
