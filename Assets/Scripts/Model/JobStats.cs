using System;
using UnityEngine;

namespace FromBossToCrook.Model
{
    [Serializable]
    public class JobStats
    {
        [SerializeField]
        private string _title = "Default";
        public string Title { get => _title; }

        [SerializeField]
        private float _salary = 0f;
        public float Salary { get => _salary; }
    }
}