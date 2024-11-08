using UnityEngine;
using TMPro;
using System.IO;

public class GameController : MonoBehaviour
{
    public TMP_Text timeField;
    public TMP_Text wordToFind;
    public GameObject[] hangMan;
    public GameObject winText;
    public GameObject loseText;
    public GameObject replayButton;

    private float time;
    private string[] words = File.ReadAllLines(@"Assets/words.txt");
    private string hiddenWord;
    private string chosenWord;
    private int fails;
    private bool gameEnd = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chosenWord = words[Random.Range(0, words.Length)];

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
        if (!gameEnd)
        {
            time += Time.deltaTime;
            timeField.text = time.ToString("F2"); // Displays time rounded to 2 decimal places
            replayButton.SetActive(false);
        }

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
            if (fails == hangMan.Length)
            { 
                loseText.SetActive(true);
                replayButton.SetActive(true);
                gameEnd = true;
            }
            if (!hiddenWord.Contains("_"))
            {
                winText.SetActive(true);
                replayButton.SetActive(true);
                gameEnd = true;
            }
        }
    }
}
