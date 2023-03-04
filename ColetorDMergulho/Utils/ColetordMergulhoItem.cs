using SMLHelper.V2.Assets;
using SMLHelper.V2.Crafting;
using SMLHelper.V2.Handlers;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;


namespace MAC.ColetordMergulho
{
    public class ColetordMergulhoItem : Craftable
    {
        public ColetordMergulhoItem() : base("ColetordMergulho", "Coletor de Mergulho", "Combina o suprimento de oxigênio de todos os tanques transportados")
        {
            this.OnFinishedPatching = delegate ()
            {

                CraftDataHandler.SetEquipmentType(base.TechType, EquipmentType.Tank);
                CraftDataHandler.SetCraftingTime(base.TechType, 5f);
                CraftDataHandler.SetItemSize(base.TechType, 3, 2);
                ColetordMergulho.techType = base.TechType;
            };
        }

        protected override TechData GetBlueprintRecipe()
        {

            return new TechData
            {
                Ingredients = new List<Ingredient>
                {
                    new Ingredient(TechType.Silicone, 1),
                    new Ingredient(TechType.Titanium, 3),
                    new Ingredient(TechType.Lubricant, 2),
                },
                craftAmount = 1
            };

        }

        public override CraftTree.Type FabricatorType
        {
            get
            {
                return CraftTree.Type.Fabricator;
            }
        }

        public override string[] StepsToFabricatorTab
        {
            get
            {
                return "Personal/Equipment".Split(new char[]
                {
                    '/'
                });
            }
        }

        public override TechGroup GroupForPDA
        {
            get
            {
                return TechGroup.Personal;
            }
        }

        public override TechCategory CategoryForPDA
        {
            get
            {
                return TechCategory.Equipment;
            }
        }

        public override string AssetsFolder
        {
            get
            {
                return Path.Combine(new DirectoryInfo(Path.Combine(Assembly.GetExecutingAssembly().Location, "..")).Name, "Assets");
            }
        }

        public override string IconFileName
        {
            get
            {
                return "ColetordMergulho.png";
            }
        }

        public override GameObject GetGameObject()
        {
            GameObject gameObject = Object.Instantiate(Patche.prefabGameObject);
            Pickupable component = gameObject.GetComponent<Pickupable>();
            component.destroyOnDeath = false;
            ColetordMergulho ColetorMergulho = Player.mainObject.GetComponent<ColetordMergulho>() ?? Player.mainObject.AddComponent<ColetordMergulho>();
            Object.DestroyImmediate(gameObject.GetComponent<Oxygen>());
            return gameObject;
        }
    }
}