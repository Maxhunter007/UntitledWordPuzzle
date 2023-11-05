
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class StartConditions : MonoBehaviour
{
    [SerializeField] private GameObject LetterPrefab;
    [SerializeField] private List<string> _startLetters;

    void Start()
    {
        for (int i = 0; i < _startLetters.Count; i++)
        {
            Vector3 position = new(Random.Range(-16, 16), Random.Range(-5, 3));
            var letter = Instantiate(LetterPrefab, position, Quaternion.identity);
            letter.GetComponent<TMP_Text>().text = "" + _startLetters[i];
        }
    }
}
