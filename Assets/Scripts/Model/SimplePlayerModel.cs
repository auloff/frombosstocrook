using System;
using UnityEditor;
using UnityEngine;

namespace FromBossToCrook.Model
{
    [CreateAssetMenu]
    public class SimplePlayerModel : ScriptableObject, IPlayerModel
    {
        [SerializeField]
        private int _maxAge = 83;
        public int MaxAge { get => _maxAge; }

        [SerializeField]
        private int _age = 18;
        public int Age { get => _age; }

        [SerializeField]
        private float _money = 0;
        public float Money 
        { 
            get => _money; 
            set
            { 
                _money = value;
                ModelChanged?.Invoke();
            } 
        }

        [SerializeField]
        private float _health = 100;
        public float Health 
        { 
            get => _health; 
            set 
            { 
                if (value <= 0)
                {
                    _health = 0;
                    Death?.Invoke();
                }
                else if (value >= 100)
                    _health = 100;
                else
                    _health = value;

                ModelChanged?.Invoke();
            }
        }

        [SerializeField]
        private float _happiness = 100;
        public float Happiness 
        { 
            get => _happiness; 
            set
            {
                if (value <= 0)
                {
                    _happiness = 0;
                }
                else if (value >= 100)
                    _happiness = 100;
                else
                    _happiness = value;

                ModelChanged?.Invoke();
            }
        }

        public event Action Death;
        public event Action ModelChanged;

        public void IncreaseAge()
        {
            if (Health <= 5) _age++;
            if (Happiness <= 5) _age++;

            if (++_age > _maxAge)
            {
                Death?.Invoke();
            }

            ModelChanged?.Invoke();
        }
    }
}