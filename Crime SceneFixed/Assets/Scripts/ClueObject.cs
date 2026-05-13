using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class ClueObject : MonoBehaviour
{
    public string clueName;
    [TextArea] public string clueDescription;

    public GameObject cluePanel;
    public TMP_Text clueText;

    public GameObject interactPrompt;
    public GameObject backgroundDark;

    private bool playerNear = false;
    private bool collected = false;

    private void Start()
    {
        if (interactPrompt != null)
            interactPrompt.SetActive(false);

        if (cluePanel != null)
            cluePanel.SetActive(false);

        if (backgroundDark != null)
            backgroundDark.SetActive(false);
    }

    private void Update()
    {
        if (playerNear && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            ShowClue();
        }

        if (cluePanel != null && cluePanel.activeSelf && Keyboard.current != null && Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            cluePanel.SetActive(false);

            if (backgroundDark != null)
                backgroundDark.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;

            if (interactPrompt != null)
                interactPrompt.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = false;

            if (interactPrompt != null)
                interactPrompt.SetActive(false);

            if (cluePanel != null)
                cluePanel.SetActive(false);

            if (backgroundDark != null)
                backgroundDark.SetActive(false);
        }
    }

    public void ShowClue()
    {
        if (backgroundDark != null)
            backgroundDark.SetActive(true);

        if (cluePanel != null && clueText != null)
        {
            cluePanel.SetActive(true);

            clueText.text =
            "<size=20><color=#AAAAAA>EVIDENCE</color></size>\n\n" +
            "<size=34><b>" + clueName + "</b></size>\n\n" +
            "<size=24>" + clueDescription + "</size>";
        }

        if (interactPrompt != null)
            interactPrompt.SetActive(false);

        if (!collected)
        {
            collected = true;

            if (ClueManager.instance != null)
                ClueManager.instance.CollectClue();
        }
    }
}