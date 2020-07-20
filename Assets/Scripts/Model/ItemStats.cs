using System;
using UnityEngine;

namespace FromBossToCrook.Model
{
    public enum TargetField
    {
        Happiness,
        Health,
        None
    }

    [Serializable]
    public class ItemStats
    {
        [SerializeField]
        private string _title = "Default";
        public string Title { get => _title; }

        [SerializeField]
        private float _cost = 0f;
        public float Cost { get => _cost; }

        [SerializeField]
        private TargetField _targetField = TargetField.None;
        public TargetField TargetField { get => _targetField; }

        [SerializeField]
        private float _value = 0f;
        public float Value { get => _value; }
    }
}