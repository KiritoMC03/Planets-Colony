using PlanetsColony.Levels;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PlanetsColony.Spaceships
{
    [RequireComponent(typeof(Spaceship), typeof(SpriteRenderer))]
    public class SpaceshipSprite : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _shipSprite = null;

        private void Awake()
        {
            _shipSprite = GetComponent<SpriteRenderer>();
            if (_shipSprite == null)
            {
                throw new Exception("SpriteRenderer component not fount.");
            }
        }

        private void Start()
        {
            SpaceshipsLevelling.Instance.OnSpaceshipsLevelUp.AddListener(UpdateLevelSprite);
            UpdateLevelSprite();
        }

        public void UpdateLevelSprite()
        {
            _shipSprite.sprite = SpaceshipsLevelling.Instance.FindAppropriateSprite();
        }
    }
}
