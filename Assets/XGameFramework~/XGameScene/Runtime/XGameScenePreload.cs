using System.Collections.Generic;
using UnityEngine;

namespace XGameFramework.XGameScene.Runtime
{
    public class XGameScenePreload : IXGameScenePreload
    {
        private List<string> _SrcSceneAssets = new List<string>();
        private List<string> _DstSceneAssets = new List<string>();
        
        public void Start(IXGameScene src, IXGameScene dst)
        {
        }
        public void Tick(float deltaTime) 
        {
            
        }
        public bool IsCompleted()
        {
            return true;
        }
    }
}
