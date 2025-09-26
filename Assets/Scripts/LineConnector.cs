using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineConnector : MonoBehaviour
{
    public RectTransform lineImage;
    public RectTransform connector;
    public IEnumerator MakeLine(List<List<GameObject>> joints)
    {

        yield return null;

        for (int i=0; i<joints.Count; i++)
        {
            Debug.Log(i);

            for(int j =0; j<joints[i].Count; j++)
            {
                Debug.Log(joints[i].Count);
                int k = j + 1;

                if (k >= joints[i].Count) continue;

                Vector3 worldA = joints[i][j].transform.position;
                Debug.Log(worldA);
                Vector3 worldB = joints[i][k].transform.position;
                Debug.Log(worldB);

                Vector3 localA = connector.InverseTransformPoint(worldA);
                Vector3 localB = connector.InverseTransformPoint(worldB);

                RectTransform lineInstance = Instantiate(lineImage, connector);

                lineInstance.GetComponent<Line>().SetJoint(joints[i][j].GetComponent<Joint>(), joints[i][k].GetComponent<Joint>());

                lineInstance.localPosition = (localA + localB) / 2f;

                float distance = Vector3.Distance(localA, localB);

                lineInstance.sizeDelta = new Vector2(distance, joints[i][j].GetComponent<RectTransform>().sizeDelta.y);

                joints[i][j].GetComponent<Joint>().CancelConnected();
                joints[i][k].GetComponent<Joint>().CancelConnected();

                // È¸Àü
                //  Vector3 dir = (posB - posA).normalized;
                // float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                // lineInstance.rotation = Quaternion.Euler(0, 0, angle);
            }
        }
    }
}
