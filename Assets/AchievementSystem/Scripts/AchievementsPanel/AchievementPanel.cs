using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UgglaGames.AchievementSystem;

namespace UgglaGames.NotificationSystem
{
    /// <summary>
    /// Class of Panel used to show to player the achievements of game
    /// </summary>
    public class AchievementPanel : MonoBehaviour
    {
        string achievementsPath = "Achievements";
        [SerializeField] AchievementPanelElement prefab;
        [SerializeField] RectTransform content;

        [SerializeField] List<AchievementPanelElement> panelElements = new List<AchievementPanelElement>();

        // Start is called before the first frame update
        void OnEnable()
        {
            PopulatePanel();
        }

        /// <summary>
        /// Load Achievements from Resources folder, create UI elements for them and populate the panel
        /// </summary>
        private void PopulatePanel()
        {
            var achievements = Resources.LoadAll<Achievement>(achievementsPath);

            foreach (var item in achievements)
            {
                CretePanelElementAndAddToList(item);
            }
        }

        /// <summary>
        /// Create UI element for the given achievement, then add to list
        /// </summary>
        /// <param name="item"></param>
        private void CretePanelElementAndAddToList(Achievement item)
        {
            var element = Instantiate(prefab, content.transform);
            element.PopulateElementContent(item);
            panelElements.Add(element);
        }

        private void OnDisable()
        {
            ClearPanel();
        }

        /// <summary>
        /// Destroy panel elements and clean the elements list
        /// </summary>
        private void ClearPanel()
        {
            foreach (var item in panelElements)
            {
                Destroy(item.gameObject);
            }

            panelElements.Clear();
        }
    }
}