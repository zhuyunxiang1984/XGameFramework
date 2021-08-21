using System;
using System.Collections.Generic;
using UnityEngine;
using XGameFramework.XGameScene.Runtime;

namespace XGameFramework.XGameScene
{
    public class XGameSceneManager : IXGameSceneManager
    {
        private Func<string, IXGameScene> _CreateMethod;
        private Dictionary<string, string> _SceneRelationShip = new Dictionary<string, string>();
        private Dictionary<string, IXGameScene> _GameScenes = new Dictionary<string, IXGameScene>();
        private IXGameScene _SceneRoot;
        private IXGameScenePreload _Preload;
        
        public void Init(Func<string, IXGameScene> method)
        {
            _CreateMethod = method;
        }

        public void AddScenes(XGameSceneConfig config, string parent)
        {
        }

        public void Start()
        {
            
        }

        public void Tick(float deltaTime)
        {
            
        }
        public void EnterScene(string sceneName)
        {
            
        }

        private void _ChangeScene(IXGameScene src, IXGameScene dst)
        {
            
        }
    }
}
