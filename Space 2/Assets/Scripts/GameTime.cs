using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameTime : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI gameText;
    public TextMeshProUGUI instructionsText;
    public TextMeshProUGUI FPS;
    public float timeRemaining = 160f;
    private bool isTimerRunning = false;
    public GameObject TransitionManager;
    void Start()
    {
        if (timeText == null)
        {
            Debug.LogError("TextMeshPro component not found on the assigned GameObject");
        }
        timeText.enabled = true;
        instructionsText.enabled = true;
        gameText.enabled = false;
        isTimerRunning = true;
        FPS.enabled = true;
        InvokeRepeating("UpdateFPS", 1, 1);
    }
    void UpdateTime()
    {
        timeText.SetText("Time remaining : " + Mathf.Round(timeRemaining));
        timeText.ForceMeshUpdate();
        Canvas.ForceUpdateCanvases();
    }
    // Update is called once per frame
    void Update()
    {
        if(isTimerRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTime();
            }
            else
            {
                isTimerRunning = false;
            }
        }
        else
        {
            gameText.enabled = true;
            instructionsText.enabled = false;
            timeText.enabled = false;
            gameText.SetText("Game Over !\nSurvival sometimes requires thinking for yourself rather than blindly following instructions.");
            TransitionManager.GetComponent<SceneTransitionManager>().GoToSceneAsync(0);
        }
    }
    public void UpdateFPS()
    {
        int fps = (int)(1f / Time.unscaledDeltaTime);
        FPS.text = "FPS :" + fps;
    }
}
