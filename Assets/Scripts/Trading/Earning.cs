using PlanetsColony.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

namespace PlanetsColony.Trading
{
    public class Earning : MonoBehaviour, IEarning
    {
        [SerializeField] private Text _text = null;
        [SerializeField] private float _showTextTime = 1.5f;
        private const string ADD_MONEY_TEXT = "Добавлено монет: ";
        private Coroutine _showTextRoutine = null;

        private void Awake()
        {
            if (GetComponent<Text>() != null)
            {
                throw new Exception("ы");
            }
            if (_text == null)
            {
                throw new Exception("f");
            }
            _text.gameObject.SetActive(false);
        }

        public void Show(BigInteger addedMoney)
        {
            Debug.Log(ADD_MONEY_TEXT + addedMoney);
            _text.text = ADD_MONEY_TEXT + Converter.ValueToString(addedMoney);
            if (_showTextRoutine != null)
            {
                StopCoroutine(_showTextRoutine);
            }
            _showTextRoutine = StartCoroutine(ShowTextRoutine(_showTextTime));
        }

        private IEnumerator ShowTextRoutine(float delay)
        {
            _text.gameObject.SetActive(true);
            yield return new WaitForSeconds(delay);
            _text.gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }
    }
}