using BepInEx;
using System.Collections;
using UnityEngine; 

namespace MAC.ColetordMergulho
{
    public class Patche : BaseUnityPlugin
    {
        public static GameObject prefabGameObject;

        public void Awake()
        {
            new ColetordMergulhoItem().Patch();
            Logger.LogMessage("Patched!");
            StartCoroutine(GetPrefab());
        }

        private IEnumerator GetPrefab()
        {
            CoroutineTask<GameObject> request = CraftData.GetPrefabForTechTypeAsync(TechType.Tank, true);
            yield return request;
            prefabGameObject = request.GetResult();
            Logger.LogMessage("Got game object!");
        }
    }
}