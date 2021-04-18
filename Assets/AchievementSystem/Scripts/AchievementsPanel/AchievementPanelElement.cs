using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UgglaGames.AchievementSystem;

public class AchievementPanelElement : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Text title;
    [SerializeField] Text description;
    [SerializeField] Text count;

    public void PopulateElementContent(Achievement achievement)
    {
        icon.sprite = achievement.Icon;
        title.text = achievement.Name;
        description.text = achievement.Description;
        count.text = $"{achievement.CurrentCount}/{achievement.GoalCount}";
    }
}
