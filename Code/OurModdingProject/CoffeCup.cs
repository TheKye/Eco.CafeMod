using System;
using System.Collections.Generic;
using System.ComponentModel;
using Eco.Gameplay.Blocks;
using Eco.Gameplay.Components;
using Eco.Gameplay.DynamicValues;
using Eco.Gameplay.Items;
using Eco.Gameplay.Objects;
using Eco.Gameplay.Players;
using Eco.Gameplay.Skills;
using Eco.Gameplay.Systems;
using Eco.Gameplay.Systems.TextLinks;
using Eco.Shared.Localization;
using Eco.Shared.Serialization;
using Eco.Shared.Utils;
using Eco.Core.Items;
using Eco.World;
using Eco.World.Blocks;
using Eco.Gameplay.Pipes;
using Eco.Mods.TechTree;

namespace Eco.Cafe
{
    [Serialized]
    [LocDisplayName("Coffee Cup")]
    [Weight(100)]
    [MaxStackSize(20)]
    [Currency]
    [Tag("Crockery")]
    [Ecopedia("Items", "Products", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class CoffeeCupItem : Item
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Coffee Cup for Storing Your Delicious Coffee!");
    }
    
    [RequiresSkill(typeof(PaperMillingSkill), 1)]
    public partial class CoffeeCupRecipe : RecipeFamily
    {
        public CoffeeCupRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Coffee Cup",
                    Localizer.DoStr("Coffee Cup"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(PaperItem), 5, typeof(PaperMillingSkill))
                    },
                    new CraftingElement<CoffeeCupItem>(5)
                    )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(250, typeof(PaperMillingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(CoffeeCupRecipe), 1, typeof(PaperMillingSkill), typeof(PaperMillingParallelSpeedTalent), typeof(PaperMillingFocusedSpeedTalent));
            this.Initialize(Localizer.DoStr("Coffee Cup"), typeof(CoffeeCupRecipe));
            CraftingComponent.AddRecipe(typeof(TailoringTableObject), this);
        }
    }
}
