using System;
using UnityEngine;

namespace XGameFramework.XGameScene
{
    public interface IXGameSceneManager
    {
        void Init(Func<string, IXGameScene> method);
        void AddScenes(XGameSceneConfig config, string parent);
        void Start();
        void Tick(float deltaTime);
        void EnterScene(string sceneName);
    }
}
