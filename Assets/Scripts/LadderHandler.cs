using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderHandler : MonoBehaviour
{
    public void SetLadderStartPoint(List<GameObject> ladders,List<List<GameObject>> joints)
    {
        for (int i = 0; i < ladders.Count; i++)
        {
            Ladder ladder = ladders[i].GetComponent<Ladder>();

            ladder.SetStartPoint(joints[0][i].GetComponent<Joint>());
        }
    }
    public void SetStartCharacter(List<GameObject> ladders, int count)
    {

    }
}
