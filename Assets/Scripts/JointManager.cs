using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointManager : MonoBehaviour
{
    public JointSpawner jSpawner;

    public List<List<GameObject>> jointArray2D = new List<List<GameObject>>();

    //����Ʈ �����ϱ� ##
    public void MakeJoint(List<GameObject> radders,int _jointCount)
    {
            for (int r = 0; r < _jointCount; r++)
            {
                jointArray2D.Add(new List<GameObject>());
                for (int c = 0; c < radders.Count; c++)
                {
                    jointArray2D[r].Add(null);
                }
            }

            //���� �࿡ ����Ʈ���� ����Ʈ�� �����ϱ�
        for (int i=0; i<radders.Count; i++)
        {
            for (int j = 0; j < _jointCount; j++)
            {
                GameObject line = radders[i].GetComponent<LineObject>().GetLine();
                jointArray2D[j][i] = jSpawner.MakeJoint(line);
            }

            //radders���� line �������� �Լ� �����
        }
    }

    public List<List<GameObject>> GetJointArray2D()
    {
        return jointArray2D;
    }
}
