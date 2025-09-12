using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class StageSpawner : MonoBehaviour
{
    public Canvas gameMapCanvas;

    public GameObject radder;

    public GameObject radderPanel;

    public List<GameObject> radderList = new List<GameObject>();

    public void SpawnRadder(int _count) 
    {
        for(int i=0; i<_count; i++) {
            GameObject radderObj = Instantiate(radder);
            radderObj.transform.SetParent(radderPanel.transform);

            radderList.Add(radderObj);
        }
    }

    public int RadderCount()
    {
        return radderList.Count;
    }

    public List<GameObject> GetRadderList()
    {
        return radderList;
    }

}
