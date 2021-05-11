using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Transform[] PositionsToMove;
    public GameObject TargetModel;
    public DestroyObject DestroyObject;

    [Header("Settings")] 
    public float MovementSpeed;

    private int _nextPosIndex;
    private Transform _nextPos;

    private void Start()
    {
        _nextPos = PositionsToMove[0];
    }

    private void Update()
    {
        MoveTarget();
    }

    public void GetHit()
    {

        DestroyObject.DestroyGameObject();
    }

    private void MoveTarget()
    {
        if (TargetModel.transform.position == _nextPos.position)
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
            TargetModel.transform.position = Vector3.MoveTowards(TargetModel.transform.position, _nextPos.position, MovementSpeed * Time.deltaTime);
        }
    }
}
