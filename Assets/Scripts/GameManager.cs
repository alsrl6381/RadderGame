using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public StageSpawner stageSpawner;
    public JointManager jointManager;
    public LineConnector lineConnector;

    public int radderCount;
    public int jointCount;

    private void Start()
    {
        stageSpawner.SpawnRadder(radderCount);

        jointManager.MakeJoint(stageSpawner.GetRadderList(), jointCount);

        lineConnector.MakeLine(jointManager.GetJointArray2D());
    }
}
