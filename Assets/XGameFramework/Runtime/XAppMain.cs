using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using XGameFramework;

public class XAppMain : MonoBehaviour
{
    private XILRuntimeDomain _ILRuntimeDomain;

    void Start()
    {
        _ILRuntimeDomain = new XILRuntimeDomain();
        _ILRuntimeDomain.Init(true);
        _ILRuntimeDomain.Start($"{Application.dataPath}/../Library/ScriptAssemblies/", "Launch",
            () =>
            {
                //
            });
    }


    void Update()
    {
        _ILRuntimeDomain.Tick(Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _ILRuntimeDomain.Invoke("XGameFrameworkHotfix.Launch", "Start", null, _ILRuntimeDomain);
        }
    }
}