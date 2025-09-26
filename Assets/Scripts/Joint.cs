using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//�ٸ��� �߰��ϱ� ���� ����Ʈ�� ������ ����
public class Joint : MonoBehaviour
{
    [SerializeField]
    private Joint nextJoint;
    private Joint underJoint;
    private bool isConnected;

    private void Start()
    {
        isConnected = false;
    }

    public void SetUnderJoint(Joint _joint)
    {
        underJoint = _joint;
    }
    public void SetNextJoint(Joint _joint)
    {
        nextJoint = _joint;
        isConnected = true;
    }

    public void Connect()
    {
        isConnected = true;
    }

    public bool IsConnected()
    {
        return isConnected;
    }

    public void CancelConnected()
    {
        isConnected = false;
    }

    public Joint ReturnConnectedJoint(Joint prev)
    {
        if(isConnected)
        {
            if(prev == nextJoint)
            {
                return underJoint;
            }
            else
            {
                return nextJoint;
            }
        }
        else
        {
            return underJoint;
        }
        
    }
}
