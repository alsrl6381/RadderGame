using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class StageSpawner : MonoBehaviour
{
    public Canvas gameMapCanvas;

    public GameObject ladder;

    public GameObject ladderPanel;

    public List<GameObject> ladderList = new List<GameObject>();

    public void SpawnLadder(int _count) 
    {
        for(int i=0; i<_count; i++) {
            GameObject ladderObj = Instantiate(ladder);
            ladderObj.transform.SetParent(ladderPanel.transform);

            ladderList.Add(ladderObj);
        }
    }

    public int LadderCount()
    {
        return ladderList.Count;
    }

    public List<GameObject> GetLadderList()
    {
        return ladderList;
    }

}
