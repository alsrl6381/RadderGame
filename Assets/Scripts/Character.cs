using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using Unity.VisualScripting;
using System;


public class Character : MonoBehaviour
{
    public Joint nextTarget;
    private Joint previousTarget;
    private int playerNumber;

    public event Action<Character> OnFinished;

    public void SetNextTarget(Joint _joint) 
    {
        previousTarget = nextTarget;
        nextTarget = _joint;
    }

    public void MoveToNext()
    {
        StartCoroutine(Move());
    }

    //�̰� LateUpdate�� �ڷ�ƾ ��� ��
    IEnumerator Move()
    {

        yield return null;

        if (nextTarget == null)
        {
            OnFinished?.Invoke(this);
            yield break;
        }


        RectTransform pos = this.GetComponent<RectTransform>();
      
        pos.DOMove(nextTarget.transform.position, 1f)
           .SetEase(Ease.OutQuad)
           .OnComplete(() =>
           {
               Debug.Log("�̵� �Ϸ�!");
               // �̵� �Ϸ� �� ó���� ���� ���⿡ �ۼ�
               SetNextTarget(nextTarget.ReturnConnectedJoint(previousTarget));
               MoveToNext();
           });

    }

    public void SetPlayerNumber(int num)
    {
        playerNumber = num;
    }
    public bool isCorrect(int num)
    {
        if (playerNumber == num) return true;
        else return false;
    }
}
