using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public enum EnemyPathing
    {
        Linear,
        Quadratic,
        Cubic
    }

    [SerializeField] private EnemyPathing enemyPathing;

    [SerializeField] private Transform startPoint, endPoint, middlePoint1, middlePoint2;
    [SerializeField] private Transform objectToMove;
    [SerializeField, Range(1, 10)] private float timeToTake;

    float currentTime;

    void Start()
    {
        currentTime = 0;
        
        InitializePoints();
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        HandleMovement();
    }

    void InitializePoints()
    {
        startPoint = GameObject.Find("StartPoint").transform;
        endPoint = GameObject.Find("EndPoint").transform;
        middlePoint1 = GameObject.Find("MiddlePoint1").transform;
        middlePoint2 = GameObject.Find("MiddlePoint2").transform;
    }

    void HandleMovement()
    {
        if (!CheckPoints()) return;

        switch (enemyPathing)
        {
            case EnemyPathing.Linear:
                HandleLerp(2);
                break;
            case EnemyPathing.Quadratic:
                HandleQuadraticLerp(3);
                break;
            case EnemyPathing.Cubic:
                HandleCubicLerp(4);
                break;
        }
    }

    void HandleLerp(int numPoints)
    {
        if (numPoints != 2) return;

        var percentTime = currentTime / timeToTake;
        var newPos = MovementLibrary.Lerp(startPoint.position, endPoint.position, percentTime);
        objectToMove.position = newPos;
    }

    void HandleQuadraticLerp(int numPoints)
    {
        if (numPoints != 3) return;

        var percentTime = currentTime / timeToTake;
        var newPos = MovementLibrary.QuadraticLerp(startPoint.position, endPoint.position, middlePoint1.position, percentTime);
        objectToMove.position = newPos;
    }

    void HandleCubicLerp(int numPoints)
    {
        if (numPoints != 4) return;

        var percentTime = currentTime / timeToTake;
        var newPos = MovementLibrary.CubicLerp(startPoint.position, endPoint.position, middlePoint1.position, middlePoint2.position, percentTime);
        objectToMove.position = newPos;
    }

    bool CheckPoints()
    {
        if (startPoint == null
            || endPoint == null
            || middlePoint1 == null
            || middlePoint2 == null
            || objectToMove == null)
            return false;

        return true;
    }
}
