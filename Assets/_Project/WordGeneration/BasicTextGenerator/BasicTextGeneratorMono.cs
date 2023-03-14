using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeedTypeGame
{
    public class BasicTextGeneratorMono : MonoBehaviour
    {
        [SerializeField] TextAsset _textAsset;
        BasicTextGenerator textGenerator;

        private void Awake()
        {
            textGenerator = new BasicTextGenerator(_textAsset.text);
        }

        public string GetWord(int _count)
        {
            return textGenerator.GetWordFromPool(_count);
        }
    }
}
