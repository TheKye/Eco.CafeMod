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
    [Weight(500)]
    [LocDisplayName("Brewed Coffee")]
    [Ecopedia("Food", "Product", createAsSubPage: true, display: InPageTooltip.DynamicTooltip)]
    public partial class BrewedCoffeeItem : FoodItem
    {
        public override LocString DisplayDescription => Localizer.DoStr("A Lovely Cup Of Brewed Coffee, Yum.");

        private static Nutrients nutrition = new Nutrients() 
        { 
            Carbs = 5, 
            Fat = 3, 
            Protein = 1, 
            Vitamins = 2, 
        };
        public override float Calories => 500f;
        public override Nutrients Nutrition => nutrition;
    }

    [RequiresSkill(typeof(CookingSkill), 1)]
    public partial class BrewedCoffeeRecipe : RecipeFamily
    {
        public BrewedCoffeeRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Brewed Coffee",
                    Localizer.DoStr("Brewed Coffee"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(CoffeeCupItem), 1, true),
                        new IngredientElement(typeof(CharredBeansItem), 15, typeof(CookingSkill))
                    },
                    new CraftingElement<BrewedCoffeeItem>()
                )
            };
            this.ExperienceOnCraft = 1;
            this.LaborInCalories = CreateLaborInCaloriesValue(300, typeof(CookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(BrewedCoffeeRecipe), 5, typeof(CookingSkill), typeof(CookingFocusedSpeedTalent), typeof(CookingParallelSpeedTalent));
            this.Initialize(Localizer.DoStr("Brewed Coffee"), typeof(BrewedCoffeeRecipe));
            CraftingComponent.AddRecipe(typeof(CastIronStoveObject), this);
        }
    }
}
