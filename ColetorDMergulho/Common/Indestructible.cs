using System;
using UnityEngine;

namespace Common.Helpers
{
    // Token: 0x02000028 RID: 40
    public class Indestructible : MonoBehaviour
    {
        // Token: 0x060000F0 RID: 240 RVA: 0x0000555A File Offset: 0x0000375A
        public void Awake()
        {
            base.gameObject.AddComponent<SceneCleanerPreserve>();
            UnityEngine.Object.DontDestroyOnLoad(base.gameObject);
            SNLogger.Log("Indestructible component added.");
        }
    }
}
