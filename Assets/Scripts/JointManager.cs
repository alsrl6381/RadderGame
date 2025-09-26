using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointManager : MonoBehaviour
{
    public JointSpawner jSpawner;

    public List<List<GameObject>> jointArray2D = new List<List<GameObject>>();

    //조인트 생성하기 ##
    public void MakeJoint(List<GameObject> ladders,int _jointCount)
    {
            for (int r = 0; r < _jointCount; r++)
            {
                jointArray2D.Add(new List<GameObject>());
                for (int c = 0; c < ladders.Count; c++)
                {
                    jointArray2D[r].Add(null);
                }
            }

            //같은 행에 조인트끼리 리스트로 저장하기
        for (int i=0; i<ladders.Count; i++)
        {
            for (int j = 0; j < _jointCount; j++)
            {
                GameObject line = ladders[i].GetComponent<LineObject>().GetLine();

                jointArray2D[j][i] = jSpawner.MakeJoint(line);
            }

            //ladders에서 line 가져오는 함수 만들기
        }
    }

    public void SetUnderJoint()
    {
        for(int i=0; i< jointArray2D.Count; i++)
        {
            for(int k=0; k< jointArray2D[i].Count; k++)
            {
                if (i + 1 < jointArray2D.Count)
                {
                    jointArray2D[i][k].GetComponent<Joint>().SetUnderJoint(jointArray2D[i + 1][k].GetComponent<Joint>());
                }
                else
                {
                    //도착 지점
                }
            }
        }
    }

    public List<List<GameObject>> GetJointArray2D()
    {
        return jointArray2D;
    }
}

