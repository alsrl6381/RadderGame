using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    public List<Character> characters;

    private int currentIndex = 0;



    public void StartNextCharacter()
    {
        if (currentIndex >= characters.Count) return;

        Character character = characters[currentIndex];
        character.OnFinished += HandleCharacterFinished;
        character.MoveToNext();
    }

    public void HandleCharacterFinished(Character character)
    {
        character.OnFinished -= HandleCharacterFinished; // 구독 해제
        currentIndex++;
        StartNextCharacter();
    }
}
