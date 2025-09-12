using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConnector : MonoBehaviour
{
    public RectTransform lineImage;
    public void MakeLine(List<List<GameObject>> joints)
    {
        RectTransform lineInstance = Instantiate(lineImage, transform);

        for(int i=0; i<joints.Count; i++)
        {
          
            for(int j =0; j<joints[i].Count; j++)
            {
                int k = j + 1;

                if (k >= joints[i].Count) return;

                Vector3 posA = joints[i][j].transform.position;
                Vector3 posB = joints[i][k].transform.position;

                lineInstance.position = (posA + posB) / 2f;

                float distance = Vector3.Distance(posA, posB);

                lineInstance.sizeDelta = new Vector2(distance, lineInstance.sizeDelta.y);

                // È¸Àü
                Vector3 dir = (posB - posA).normalized;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                lineInstance.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
}
