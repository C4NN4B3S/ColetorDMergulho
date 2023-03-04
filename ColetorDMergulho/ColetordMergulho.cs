using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;


namespace MAC.ColetordMergulho
{
    // TODO Review this file and update to your own requirements.

    [BepInPlugin(MyGUID, PluginName, VersionString)]
    public class ColetordMergulho : MonoBehaviour
    {
        // Mod specific details. MyGUID should be unique, and follow the reverse domain pattern
        // e.g.
        // com.mynameororg.pluginname
        // Version should be a valid version string.
        // e.g.
        // 1.0.0
        private const string MyGUID = "com.FHack.ColetordMergulho";
        private const string PluginName = "ColetordMergulho";
        private const string VersionString = "1.0.0";

        public void Start()
        {
            bool flag = UnityEngine.Object.FindObjectsOfType<ColetordMergulho>().Length >= 2;
            if (flag)
            {
                Console.WriteLine("[pluginName] [ERROR] ColetordMergulho component must be a singleton!");
                UnityEngine.Object.DestroyImmediate(this);
            }
        }

        public void Update()
        {
            List<InventoryItem> items = new List<InventoryItem>();
            Inventory.main.container.GetItemTypes().ForEach(delegate (TechType type)
            {
                items.AddRange(Inventory.main.container.GetItems(type));
            });
            List<Oxygen> list = (from item in items
                                 where item.item.gameObject.GetComponent<Oxygen>() != null
                                 select item.item.gameObject.GetComponent<Oxygen>()).ToList<Oxygen>();
            InventoryItem itemInSlot = Inventory.main.equipment.GetItemInSlot("Tank");
            TechType? techType;
            if (itemInSlot == null)
            {
                techType = null;
            }
            else
            {
                Pickupable item2 = itemInSlot.item;
                techType = ((item2 != null) ? new TechType?(item2.GetTechType()) : null);
            }
            TechType? techType2 = techType;
            TechType techType3 = ColetordMergulho.techType;
            bool flag = techType2.GetValueOrDefault() == techType3 & techType2 != null;
            if (flag)
            {
                list.ForEach(delegate (Oxygen source)
                {
                    Player.main.oxygenMgr.RegisterSource(source);
                });
            }
            else
            {
                list.ForEach(delegate (Oxygen source)
                {
                    Player.main.oxygenMgr.UnregisterSource(source);
                });
            }
        }

        public static TechType techType;
    }
}
