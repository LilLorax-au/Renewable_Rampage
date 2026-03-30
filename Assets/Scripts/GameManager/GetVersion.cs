#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.Build.Reporting;
public class GetVersion: Editor
{
    public string ver;
    void Start()
    {
        ver =  Application.version;
    }

}
#endif