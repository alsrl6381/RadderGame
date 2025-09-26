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

    //이거 LateUpdate나 코루틴 써야 함
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
               Debug.Log("이동 완료!");
               // 이동 완료 후 처리할 로직 여기에 작성
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
