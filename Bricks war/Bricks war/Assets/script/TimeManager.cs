using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text[] timeLabel;
    public float playTime = 0;

    void Update()
    {
        playTime += Time.deltaTime;
        timeLabel[0].text = string.Format("{0}:{1}", ((int)playTime) / 60, ((int)playTime) % 60);
        timeLabel[1].text = string.Format("{0}:{1}", ((int)playTime) / 60, ((int)playTime) % 60);
        timeLabel[2].text = string.Format("{0}:{1}", ((int)playTime) / 60, ((int)playTime) % 60);
        timeLabel[3].text = string.Format("{0}:{1}", ((int)playTime) / 60, ((int)playTime) % 60);
        timeLabel[4].text = string.Format("{0}:{1}", ((int)playTime) / 60, ((int)playTime) % 60);
    }
}
