using UnityEngine;
using System.Collections.Generic;

namespace XGameFramework.XGameScene
{
    public interface IXGameScene
    {
        void Enter();
        void Exit();
        void Tick(float deltaTime);
        List<string> GetPreloadAssets();
    }
}
