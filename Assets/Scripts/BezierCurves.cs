using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurves
{
    public static Vector3 QuadraticLerp(Vector3 p0, Vector3 p1, Vector3 p2, float t)
    {
        var clampedTime = Mathf.Clamp01(t);
        var returnVector = Mathf.Pow((1 - clampedTime),2) * p0 
            + 2 * (1 - clampedTime) * clampedTime * p1 
            + Mathf.Pow(clampedTime, 2) * p2;
        return returnVector;
    }
}
