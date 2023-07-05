using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RevealChars : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI dialogText;
    [SerializeField] float intervalBetweenChar = 0.2f;

    void Start()
    {        
        dialogText.maxVisibleCharacters = 0;
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
        {
            dialogText.ForceMeshUpdate();
            TMP_TextInfo textInfo = dialogText.textInfo;

            int characterCount = textInfo.characterCount;
            int visibleCount = 0;

            while(visibleCount < characterCount)
            {
                yield return new WaitForSeconds(intervalBetweenChar);
                visibleCount++;
                dialogText.maxVisibleCharacters =  visibleCount;
            }
        }
}
