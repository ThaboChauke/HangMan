using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public TMP_Text timeField;
    public TMP_Text wordToFind;
    private float time;
    private string[] wordsLocal = { "KING", "JOHN", "MATT", "HELEN" };
    private string hiddenWord;
    private string chosenWord;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chosenWord = wordsLocal[Random.Range(0, wordsLocal.Length)];
        wordToFind.text = chosenWord;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeField.text = time.ToString();
    }
}
