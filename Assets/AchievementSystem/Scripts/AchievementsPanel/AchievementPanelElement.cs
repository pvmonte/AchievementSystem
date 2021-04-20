using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UgglaGames.AchievementSystem;

/// <summary>
/// The Ui element representing achievement in panel
/// </summary>
public class AchievementPanelElement : MonoBehaviour
{
    [SerializeField] Image icon;
    [SerializeField] Text title;
    [SerializeField] Text description;
    [SerializeField] Text count;

    /// <summary>
    /// Populate the UI element with achievement data
    /// </summary>
    /// <param name="achievement"></param>
    public void PopulateElementContent(Achievement achievement)
    {
        icon.sprite = achievement.Icon;
        title.text = achievement.Name;
        description.text = achievement.Description;
        count.text = $"{achievement.CurrentCount}/{achievement.GoalCount}";
    }
}
