#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpeedTypeGame
{
    //[ExecuteInEditMode]
    public class Debug_BasicTextGenerator : MonoBehaviour
    {
        [SerializeField] BasicTextGeneratorMono wordGenerator;

        [SerializeField] bool useSymbols = false;

        [SerializeField] int length = 3;

        List<string> usedWords = new List<string>();

        public string wordA;
        public string wordB;
        public string wordC;
        public string wordD;

        private void Start()
        {
            wordGenerator = wordGenerator != null? wordGenerator:  GetComponent<BasicTextGeneratorMono>();
        }

        private void Update()
        {
            //if (Input.anyKeyDown)
            {
                Gen();
            }
        }

        [ContextMenu("GenerateWords")]
        public void Gen()
        {
            wordA = wordGenerator.GetWord(length);
            wordB = wordGenerator.GetWord(length);
            wordC = wordGenerator.GetWord(length);
            wordD = wordGenerator.GetWord(length);
        }
    }
}
#endif