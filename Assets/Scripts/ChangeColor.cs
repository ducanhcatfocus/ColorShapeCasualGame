using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor { 
    public Color GetShapeColorByIndex(int randomIndex)
    {
        switch (randomIndex)
        {
            case 0:
                return GetColorRGB(102, 210, 133); 
            case 1:
                return GetColorRGB(236, 138, 134); 
            case 2:
                return GetColorRGB(163, 95, 173);
            case 3:
                return GetColorRGB(94, 135, 232);
            case 4:
                return GetColorRGB(251, 242, 104);
            case 5:
                return GetColorRGB(250, 179, 93);
            default:
                return GetColorRGB(102, 210, 133);
        }
    }

    private Color GetColorRGB(int r, int g, int b)
    {
        float normalizedR = r / 255f;
        float normalizedG = g / 255f;
        float normalizedB = b / 255f;
        return new Color(normalizedR, normalizedG, normalizedB);
    }
}
