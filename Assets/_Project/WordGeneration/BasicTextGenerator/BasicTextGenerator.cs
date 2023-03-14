using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace SpeedTypeGame
{
    public class BasicTextGenerator
    {
        private const int MAX_LETTER_COUNT = 42;

        List<List<string>> words;
        List<List<string>> activeWords;

        public BasicTextGenerator(string _text)
        {
            if (!_text.Contains("\n") && (_text.Length <= 0)) 
            {
                _text = "????";
            }

            //Create words List
            words = new List<List<string>>();
            for (int i = 0; i < MAX_LETTER_COUNT; i ++)
            {
                words.Add(new List<string>());
            }

            //Read Input Text
            string[] textWords = _text.Split('\n');
            for (int i = 0;i < textWords.Length;i ++)
            {
                string word = textWords[i].Trim();
                int wordLength = word.Length;
                
                if ((wordLength > MAX_LETTER_COUNT) || (wordLength == 0)) 
                    continue;

                Debug.Log(word + " " + wordLength);

                words[wordLength - 1].Add(word);
            }

            ResetActiveWordList();
        }

        private void ResetActiveWordList()
        {
            activeWords = new List<List<string>>();

            for(int i = 0; i  < words.Count; i++)
            {
                activeWords.Add(new List<string>());

                for (int j = 0; j < words[i].Count; j++)
                {
                    activeWords[i].Add(words[i][j]);
                }
            }
        }

        public string GetWordFromPool(int _letterCount, bool _checkOtherLetterCountsIfEmpty = true)
        {
            //Make letter count valid
            _letterCount = Mathf.Clamp(_letterCount, 1, MAX_LETTER_COUNT);

            string returnWord = "";

            int curIndex = _letterCount - 1;
            int checkDirection = -1;
            while(returnWord.Length == 0) 
            {
                if (curIndex <= 0)
                {
                    curIndex = 0;
                    checkDirection = 1;
                }
                if (curIndex >=  MAX_LETTER_COUNT) 
                {
                    ResetActiveWordList();
                    curIndex = _letterCount - 1;
                    checkDirection = -1;
                    continue;
                }

                List<string> wordsWithLength = activeWords[curIndex];

                if (wordsWithLength.Count == 0)
                {
                    curIndex += checkDirection;
                }
                else
                {
                    returnWord = wordsWithLength[Random.Range(0,wordsWithLength.Count)];
                    RemoveFromPool(returnWord);
                }
            }

            return returnWord;
        }

        private void RemoveFromPool(string _word)
        {
            activeWords[_word.Length - 1].Remove(_word);
        }
    }
}
