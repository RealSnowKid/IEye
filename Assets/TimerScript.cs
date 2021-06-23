using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimerScript : MonoBehaviour
{
    public static TimerScript instance;

    public TMP_Text timerCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;

    public float elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        timerCounter.text = "00:00";
        timerGoing = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void BeginTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingStr = timePlaying.ToString("mm':'ss");
            timerCounter.text = timePlayingStr;

            yield return null;
        }
    }
}
