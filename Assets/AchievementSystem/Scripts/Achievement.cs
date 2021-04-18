using System;
using System.Collections.Generic;
using UnityEngine;
using UgglaGames.Gerals;

namespace UgglaGames.AchievementSystem
{
    [CreateAssetMenu(menuName = "Achievement", fileName = "Achievement")]
    public class Achievement : ScriptableObject, IObservable<Achievement>, INotificationData
    {
        [SerializeField] protected string _name;
        [SerializeField, TextArea(1, 3)] protected string _description;
        [SerializeField] protected Sprite _icon;
        [SerializeField] protected int goalCount;
        [SerializeField] protected int currentCount;
        [SerializeField] protected bool _achieved;
        protected List<IObserver<Achievement>> _observers = new List<IObserver<Achievement>>();
        public string Name { get => _name; }        
        public Sprite Icon { get => _icon; }
        public string Description { get => _description; }
        public int GoalCount { get => goalCount; }
        public int CurrentCount { get => currentCount; }

        public void ProgressAndTryAchieve()
        {
            if (_achieved)
                return;

            currentCount++;
            AchieveByCurrentCount();
        }

        void AchieveByCurrentCount()
        {
            _achieved = CurrentCount >= GoalCount;
            Notify();
        }

        void Notify()
        {
            foreach (var observer in _observers)
                observer.OnNext(this);
        }

        public void Reset()
        {
            currentCount = 0;
        }

        public IDisposable Subscribe(IObserver<Achievement> observer)
        {
            if (_observers.Contains(observer))
                return null;

            _observers.Add(observer);
            return new Unsubscriber<Achievement>(_observers, observer);
        }
    }
}
