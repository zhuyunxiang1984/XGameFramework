using System;
using System.Collections.Generic;
using UnityEngine;

namespace XGameFramework.XGameScene
{
    public class XGameSceneConfig : ScriptableObject
    {
        [Serializable]
        public class Data
        {
            public string Parent;
            public string SceneName;
        }
        
        public List<Data> Datas = new List<Data>();
    }
}
