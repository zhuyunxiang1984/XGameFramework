using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XGameFramework;
using XGameKit.XILRuntime;

namespace XGameFrameworkHotfix
{
    public static class Game
    {
        static XILRuntime _XilRuntime;
        public static void Main(XILRuntime xilruntime)
        {
            Debug.Log("Game Start");
            _XilRuntime = xilruntime;
            SceneManager.LoadScene("Game");
        }
        public static void Exit()
        {
            Debug.Log("Game Exit");
            _XilRuntime = null;
            SceneManager.LoadScene("Launch");
        }
        static float _Time = 1;
        public static void Tick(float deltaTime)
        {
            _Time -= deltaTime;
            if (_Time <= 0)
            {
                _Time = 1f;
                Debug.Log("Game Tick");
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                _XilRuntime.Exit();
                
            }
        }
    }
}