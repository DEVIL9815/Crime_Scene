using UnityEngine;
using TMPro;

public class ClueManager : MonoBehaviour
{
    public static ClueManager instance;

    public int totalClues = 3;
    private int collectedClues = 0;

    public TMP_Text clueCounterText;
    public TMP_Text objectiveText;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        UpdateUI();
        objectiveText.text = "Objective: Investigate the crime scene";
    }

    public void CollectClue()
    {
        collectedClues++;
        UpdateUI();

        if (collectedClues >= totalClues)
        {
            objectiveText.text = "Objective Complete: All evidence collected";
        }
    }

    void UpdateUI()
    {
        clueCounterText.text = "EVIDENCE: " + collectedClues + " / " + totalClues;
    }
}