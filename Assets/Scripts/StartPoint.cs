using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class StartPoint : MonoBehaviour
{
    private Joint nextPosition;
    public GameObject character;

    public void SetNextPosition(Joint next)
    {
        nextPosition = next;
    }

    public Joint GetNextPosition()
    {
        return nextPosition;
    }

    public void StartGame(int playerNum)
    {
        Character characterScript = character.GetComponent<Character>();

        character.SetActive(true);
        character.GetComponent<Character>().SetNextTarget(nextPosition);
        character.GetComponent<Character>().MoveToNext();

        characterScript.SetPlayerNumber(playerNum);

    }
}
