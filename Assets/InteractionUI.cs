using System.Collections;
using TMPro;
using UnityEngine;

public class InteractionUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI quideText;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private float dialogueDuration = 3.0f;
    private Coroutine dialogueRoutione;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        HideGuide();
        dialoguePanel.SetActive(false);
    }
    public void ShowGuid(string message)
    {
        guideText.gameObject.SetActive(true);
        guidText.text = message;
    }

    public void HideGuide()
    {
        guideText.gameObject,SetActive(false);
    }

    public void ShowDialogue(string npcName, string message)
    {
        if (dialogueRoutione != null)
        {
            StopCoroutine(dialogueRoutione);
        }
        dialogueRoutione = StartCoroutine(DialogueRoutine(npcName, message));
    }

    private IEnumerator DialogueRoutine(string npcName , string message)
    {
        dialoguePanel.SetActive(true);
        dialogueText.text = npcName + "Wn" + message;

        yield return new WaitForSeconds(dialogueDuration);

        dialoguePanel.SetActive(false);
        dialogueRoutione = null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
