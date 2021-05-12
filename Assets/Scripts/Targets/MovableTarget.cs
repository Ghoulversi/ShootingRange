using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableTarget : MonoBehaviour
{
    public GameSettings GameSettings;
    public Transform[] PositionsToMove;
    public GameObject TargetModel;
    public GameObject AntiTargetModel;
    public GameObject ObstacleModel;
    public DestroyObject DestroyObject;

    [Header("Settings")] 
    public float MovementSpeed;

    private int _nextPosIndex;
    private Transform _nextPos;
    private GameObject _currentTargetObj;

    private void Start()
    {
        _nextPos = PositionsToMove[0];
        SpawnNewTargetSetSpeed();
    }

    private void Update()
    {
        MoveTarget();
    }

    public void GetHit()
    {

        DestroyObject.DestroyGameObject(_currentTargetObj);

        SpawnNewTargetSetSpeed();

    }

    //move target from one point to another in a loop
    private void MoveTarget()
    {
        if (_currentTargetObj == null) return;

        if (_currentTargetObj.transform.position == _nextPos.position)
        {
            _nextPosIndex++;
            if (_nextPosIndex >= PositionsToMove.Length)
            {
                _nextPosIndex = 0;
            }

            _nextPos = PositionsToMove[_nextPosIndex];
        }
        else
        {
            _currentTargetObj.transform.position = Vector3.MoveTowards(_currentTargetObj.transform.position, _nextPos.position, MovementSpeed * Time.deltaTime);
        }
    }

    //get a random spawn position between first point and second
    private Vector3 GetRandomSpawnPos()
    {
        var pos1 = PositionsToMove[0].position;
        var pos2 = PositionsToMove[1].position;
        var offSet = 0.2f;

        var randomPosX = Random.Range(pos1.x + offSet, pos2.x - offSet);
        var randomPosY = Random.Range(pos1.y + offSet, pos2.y - offSet);
        var randomPosZ = Random.Range(pos1.z + offSet, pos2.z - offSet);

        return new Vector3(randomPosX, randomPosY, randomPosZ);
    }

    private void SpawnNewTargetSetSpeed()
    {
        switch (GameSettings.gameMode)
        {
            case GameMode.Easy:
                 _currentTargetObj = Instantiate(TargetModel, GetRandomSpawnPos(), Quaternion.identity, transform);
                break;
            case GameMode.Normal:
                var randomTarget = Random.Range(0, 1);

                _currentTargetObj = Instantiate(randomTarget == 0 ? TargetModel : ObstacleModel, GetRandomSpawnPos(), Quaternion.identity, transform);
                break;
            case GameMode.Hard:
                var randomTargets = Random.Range(0, 100);

                if (randomTargets >= 0 && randomTargets <= 40)
                {
                    _currentTargetObj = Instantiate(TargetModel, GetRandomSpawnPos(), Quaternion.identity, transform);
                }
                else if (randomTargets >= 41 && randomTargets <= 60)
                {
                    _currentTargetObj = Instantiate(ObstacleModel, GetRandomSpawnPos(), Quaternion.identity, transform);
                }
                else
                {
                    _currentTargetObj = Instantiate(AntiTargetModel, GetRandomSpawnPos(), Quaternion.identity, transform);
                }

                break;
            default:
                _currentTargetObj = Instantiate(TargetModel, GetRandomSpawnPos(), Quaternion.identity, transform);
                break;
        }

        MovementSpeed = Random.Range(2, 10);
    }
}
