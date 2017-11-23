using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardButtons : MonoBehaviour {

    private Achivements achievements;
    public GameObject Panel;

    public GameObject AchievementManager;
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            achievements = AchievementManager.GetComponent<Achivements>();
            achievements.SlicesAchievement();
            achievements.TimeAchievement();
            achievements.MoneyAchievement();
            if (Panel.active)
            {
                Panel.SetActive(false);
            }
            else
            {
                Panel.SetActive(true);
            }
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (Panel.active)
                Panel.SetActive(false);
        }
    }
}
