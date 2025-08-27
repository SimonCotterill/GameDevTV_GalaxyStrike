using UnityEngine;
using TMPro;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] string[] timelineTextLines;

    int currentLine = 0;

    public void NextDialogueLine()
    {
        currentLine++;
        dialogueText.text = timelineTextLines[currentLine];
    }
}
