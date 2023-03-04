using System;
using UnityEngine;

namespace Common
{
    // Token: 0x0200000C RID: 12
    public abstract class ConsoleCommand : MonoBehaviour
    {
        // Token: 0x17000007 RID: 7
        // (get) Token: 0x06000035 RID: 53
        public abstract bool AvailableInStartScreen { get; }

        // Token: 0x17000008 RID: 8
        // (get) Token: 0x06000036 RID: 54
        public abstract bool AvailableInGame { get; }

        // Token: 0x06000037 RID: 55
        public abstract void RegisterCommand();
    }
}
