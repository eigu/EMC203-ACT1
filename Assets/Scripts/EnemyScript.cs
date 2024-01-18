using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private Transform point1;
    [SerializeField] private Transform point2;
    [SerializeField] private Transform point3;

    [SerializeField] private Transform objectToMove;

    [SerializeField] private float timeToTake;

    float _currentTime;

    void Start()
    {
        _currentTime = 0;
    }

    void Update()
    {
        if (point3 == null 
            || point2 == null 
            || point1 == null 
            || objectToMove == null) return;

        _currentTime += Time.deltaTime;
        var percentTime = _currentTime / timeToTake;
        var newPos = BezierCurves.QuadraticLerp(point1.position, point2.position, point3.position, percentTime);
        objectToMove.position = newPos;
    }
    void EnemySpawner()
    {

    }

    void HandleLinearMovement()
    {

    }

    void HandleMovement()
    {

    }
    
}
