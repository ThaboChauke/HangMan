using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public TMP_Text timeField;
    public TMP_Text wordToFind;
    public GameObject[] hangMan;


    private float time;
    private string[] wordsLocal = { "KING", "JOHN", "MATT", "HELEN" };
    private string hiddenWord;
    private string chosenWord;
    private int fails;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chosenWord = wordsLocal[Random.Range(0, wordsLocal.Length)];

        for (int i = 0; i < chosenWord.Length; i++)
        {
            char letter = chosenWord[i];
            if (char.IsWhiteSpace(letter))
            {
                hiddenWord += " ";
            }
            else
            {
                hiddenWord += "_";
            }
        }
        wordToFind.text = hiddenWord;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timeField.text = time.ToString();
    }

    private void OnGUI()
    {
        Event e = Event.current;

        if (e.type == EventType.KeyDown && e.keyCode.ToString().Length == 1)
        {
            string pressedLetter = e.keyCode.ToString();

            if (chosenWord.Contains(pressedLetter))
            {
                int i = chosenWord.IndexOf(pressedLetter);

                while (i != -1)
                {
                    hiddenWord = hiddenWord.Substring(0,i) + pressedLetter + hiddenWord.Substring(i + 1);

                    chosenWord = chosenWord.Substring(0, i) + "_" + chosenWord.Substring(i+1);

                    i = chosenWord.IndexOf(pressedLetter);

                }

                wordToFind.text = hiddenWord;
            }
            else
            {
                hangMan[fails].SetActive(true);
                fails++;
            }
        }
    }
}
