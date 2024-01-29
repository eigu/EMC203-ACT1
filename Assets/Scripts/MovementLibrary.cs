using UnityEngine;

public class MovementLibrary
{
    public static Vector3 Lerp(Vector3 startPoint, Vector3 endPoint, float time)
    {
        var clampedTime = Mathf.Clamp01(time);

        var returnVector = startPoint +
            clampedTime * (endPoint - startPoint);

        return returnVector;
    }

    public static Vector3 QuadraticLerp(Vector3 startPoint, Vector3 endPoint, Vector3 middlePoint, float time)
    {
        var clampedTime = Mathf.Clamp01(time);

        var returnVector = Mathf.Pow((1 - clampedTime), 2) * startPoint
            + 2 * (1 - clampedTime) * clampedTime * middlePoint
            + Mathf.Pow(clampedTime, 2) * endPoint;
        
        return returnVector;
    }

    public static Vector3 CubicLerp(Vector3 startPoint, Vector3 endPoint, Vector3 middlePoint1, Vector3 middlePoint2, float time)
    {
        var clampedTime = Mathf.Clamp01(time);

        var returnVector = Mathf.Pow((1 - clampedTime), 3) * startPoint
            + 3 * Mathf.Pow((1 - clampedTime), 2) * clampedTime * middlePoint1
            + 3 * Mathf.Pow((1 - clampedTime), 2) * clampedTime * middlePoint2
            + Mathf.Pow(clampedTime, 3) * endPoint;

        return returnVector;
    }
}
