using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private StageSpawner stageSpawner;
    [SerializeField] private JointManager jointManager;
    [SerializeField] private LineConnector lineConnector;
    [SerializeField] private LadderHandler ladderHandler;
    [SerializeField] private int ladderCount;
    [SerializeField] private int jointCount;
    [SerializeField] private int characterCount;

    private void Start()
    {
        stageSpawner.SpawnLadder(ladderCount);

        jointManager.MakeJoint(stageSpawner.GetLadderList(), jointCount);

        jointManager.SetUnderJoint();

        ladderHandler.SetLadderStartPoint(stageSpawner.GetLadderList(), jointManager.GetJointArray2D());

        StartCoroutine(lineConnector.MakeLine(jointManager.GetJointArray2D()));
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        for (int i = 0; i < stageSpawner.GetLadderList().Count; i++)
        {
            Ladder ladder = stageSpawner.GetLadderList()[i].GetComponent<Ladder>();

            ladder.StartGame();
        }
    }
}

