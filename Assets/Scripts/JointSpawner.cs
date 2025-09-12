using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JointSpawner : MonoBehaviour
{
    public GameObject joint;

    public GameObject MakeJoint(GameObject _line)
    {
        GameObject _joint = Instantiate(joint, _line.transform);

        return _joint;
    }
}
