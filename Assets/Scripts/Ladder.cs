using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    public StartPoint startPoint;

    public void SetStartPoint(Joint _joint)
    {
        startPoint.SetNextPosition(_joint);
    }

    public void StartGame()
    {
       // startPoint.StartGame();
    }
}
