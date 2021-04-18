using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UgglaGames.AchievementSystem;

public class AchievementPanel : MonoBehaviour
{
    string achievementsPath = "Achievements";
    [SerializeField] AchievementPanelElement prefab;
    [SerializeField] RectTransform content;

    // Start is called before the first frame update
    void Start()
    {
        PopulatePanel();
    }

    private void PopulatePanel()
    {
        var achievements = GetAchievementsFromResources();

        foreach (var item in achievements)
        {
            CretePanelElement(item);
        }
    }

    private Achievement[] GetAchievementsFromResources()
    {
        return Resources.LoadAll<Achievement>(achievementsPath);
    }

    private void CretePanelElement(Achievement item)
    {
        var element = Instantiate(prefab, content.transform);
        element.PopulateElementContent(item);
    }
}
