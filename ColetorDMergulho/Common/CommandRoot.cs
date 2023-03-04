using System;
using System.Collections.Generic;
using Common.Helpers;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Common
{
    // Token: 0x0200000D RID: 13
    public class CommandRoot
    {
        // Token: 0x06000039 RID: 57 RVA: 0x00002B2C File Offset: 0x00000D2C
        public CommandRoot(string name, bool indestructible = false)
        {
            this.gameObject = new GameObject(name);
            if (indestructible)
            {
                this.gameObject.AddComponent<Indestructible>();
            }
            SceneManager.sceneLoaded += new UnityAction<Scene, LoadSceneMode>(this.OnSceneLoaded);
        }

        // Token: 0x0600003A RID: 58 RVA: 0x00002B6C File Offset: 0x00000D6C
        private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            bool flag = scene.name == "XMenu";
            bool flag2 = scene.name == "Main";
            foreach (ConsoleCommand consoleCommand in this.commands)
            {
                if (flag && consoleCommand.AvailableInStartScreen)
                {
                    consoleCommand.RegisterCommand();
                }
                if (flag2 && consoleCommand.AvailableInGame)
                {
                    consoleCommand.RegisterCommand();
                }
            }
        }

        // Token: 0x0600003B RID: 59 RVA: 0x00002C0C File Offset: 0x00000E0C
        public void AddCommand<T>() where T : ConsoleCommand
        {
            ConsoleCommand consoleCommand = this.gameObject.AddComponent<T>();
            if (consoleCommand != null)
            {
                this.commands.Add(consoleCommand);
                return;
            }
            throw new Exception("Requested console command cannot add!");
        }

        // Token: 0x0400004C RID: 76
        public GameObject gameObject;

        // Token: 0x0400004D RID: 77
        private List<ConsoleCommand> commands = new List<ConsoleCommand>();
    }
}
