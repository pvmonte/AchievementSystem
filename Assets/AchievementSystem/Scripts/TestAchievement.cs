using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UgglaGames.AchievementSystem;

public class TestAchievement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            AchievementSystem._instance.ProgressAchievementWithName("Click");
        }
    }
}
