using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Instructions : MonoBehaviour
{
    public List<Step> steps;
    public TextMeshProUGUI instructionsText;
    private int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (instructionsText == null)
        {
            Debug.LogError("TextMeshPro component not found on the assigned GameObject");
        }
        instructionsText.enabled = true;
    }
    [System.Serializable]
    public class Step
    {
        public string name;
        public bool hasPlayed = false;
    }

    public void PlayInstructionsIndex()
    {
        Step step = steps[index];
        if (!step.hasPlayed)
        {
            step.hasPlayed = true;
            if (instructionsText != null)
            {
                instructionsText.SetText(step.name);
                instructionsText.ForceMeshUpdate();
                Canvas.ForceUpdateCanvases();
            }
            else
            {
                Debug.LogWarning("instructionsText is not assigned!");
            }
            index++;
        }
    }
}
