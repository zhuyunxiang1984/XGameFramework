using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XGameFramework;

namespace XGameFrameworkHotfix
{
    public static class Launch
    {
        public static void Start(XILRuntimeDomain domain)
        {
            Debug.Log("Launch Start");
            domain.Start($"{Application.dataPath}/../Library/ScriptAssemblies/", "Game",
            () =>
            {
                domain.Invoke("XGameFrameworkHotfix.Game", "Start", null, domain);
                //
            });
        }
    }
}