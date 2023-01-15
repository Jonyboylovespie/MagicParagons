using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.ModOptions;
using BTD_Mod_Helper.Api.Data;
using BTD_Mod_Helper.Api.Components;
using MelonLoader;
using ModHelperData = MagicParagons.ModHelperData;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using UnityEngine;
using Il2CppAssets.Scripts.Models.Towers.Mods;
using Il2CppAssets.Scripts.Models;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using System.Linq;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Utils;
using BTD_Mod_Helper.Api.Enums;

[assembly: MelonInfo(typeof(MagicParagons.Main), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace MagicParagons
{
    public class Main : BloonsTD6Mod
    {
        public override void OnNewGameModel(GameModel gameModel, Il2CppSystem.Collections.Generic.List<ModModel> mods)
        {
            
        }
        public override void OnTitleScreen()
        {

        }
        public override void OnApplicationStart()
        {
            MelonLogger.Msg(System.ConsoleColor.Magenta, "Magic Paragons Loaded!");
        }
        public class DruidParagon
        {
            public class PrimordialKing : ModVanillaParagon
            {
                public override string BaseTower => "Druid-005";
                public override string Name => "Druid";
            }
            public class PrimordialKingUpgrade : ModParagonUpgrade<PrimordialKing>
            {
                public override int Cost => 0;
                public override string Description => "The source of all druid magic... More powerful than any other...";
                public override string DisplayName => "Primordial King";
                public override string Icon => "DruidParagonIcon";
                public override string Portrait => "DruidParagonPortrait";
                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    var attackModel = towerModel.GetAttackModel();
                }
            }
            public class PrimordialKingDisplay : ModTowerDisplay<PrimordialKing>
            {
                public override string BaseDisplay => "acf836014419c134787007ed2a6304b5";
                public override bool UseForTower(int[] tiers)
                {
                    return IsParagon(tiers);
                }
                public override int ParagonDisplayIndex => 0;
                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    foreach (var renderer in node.genericRenderers)
                    {
                        renderer.SetOutlineColor(new Color(255f / 255, 255f / 255, 255f / 255));
                    }
                }
            }
        }
        public class AlchemistParagon
        {
            public class HyperScience : ModVanillaParagon
            {
                public override string BaseTower => "Alchemist-005";
                public override string Name => "Alchemist";
            }
            public class HyperScienceUpgrade : ModParagonUpgrade<HyperScience>
            {
                public override int Cost => 1200000;
                public override string Description => "After years of experiments, trials and errors and decades of monkey knowledge, the perfect potions are now upon us!";
                public override string DisplayName => "Hyper-Science";
                public override string Icon => "AlchemistParagonIcon";
                public override string Portrait => "AlchemistParagonPortrait";
                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    towerModel.range = 100;
                    towerModel.RemoveBehaviors<AttackModel>();
                    towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Alchemist-500").GetBehaviors<AttackModel>().Last().Duplicate());
                    var attackModelBREW = towerModel.GetAttackModels()[0];
                    attackModelBREW.range = towerModel.range;
                    attackModelBREW.GetDescendants<WeaponModel>().ForEach(weapon => weapon.rate = 0.2f);
                    attackModelBREW.GetDescendants<AddBerserkerBrewToProjectileModel>().ForEach(damage => damage.damageUp = 5);
                    attackModelBREW.GetDescendants<AddBerserkerBrewToProjectileModel>().ForEach(rate => rate.rateUp = 0.3f);
                    attackModelBREW.GetDescendants<AddBerserkerBrewToProjectileModel>().ForEach(range => range.rangeUp = 1);
                    towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Alchemist-005").GetBehaviors<AttackModel>().Last().Duplicate());
                    var attackModelREDTRANSFORM = towerModel.GetAttackModels()[1];
                    attackModelREDTRANSFORM.GetDescendants<WeaponModel>().ForEach(rate => rate.rate = 2);
                    towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Alchemist-015").GetBehaviors<AttackModel>().First().Duplicate());
                    var attackModelACIDPOOL = towerModel.GetAttackModels()[2];
                    attackModelACIDPOOL.GetDescendants<ProjectileModel>().ForEach(pierce => pierce.pierce = 200);
                    attackModelACIDPOOL.GetDescendants<AcidPoolModel>().ForEach(pierce => pierce.pierce = 200);
                    attackModelACIDPOOL.GetDescendants<DamageOverTimeModel>().ForEach(damage => damage.damage = 2);
                    attackModelACIDPOOL.GetDescendants<DamageOverTimeModel>().ForEach(interval => interval.interval = 0.5f);
                    attackModelACIDPOOL.GetDescendants<WeaponModel>().ForEach(rate => rate.rate = 2);
                    towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Alchemist-050").GetBehaviors<AttackModel>().First().Duplicate());
                    var attackModelMAINATTACK = towerModel.GetAttackModels()[3];
                    attackModelMAINATTACK.range = towerModel.range;
                    attackModelMAINATTACK.GetDescendants<WeaponModel>().ForEach(rate => rate.rate = 0.25f);
                    attackModelMAINATTACK.GetDescendants<DamageModel>().ForEach(damage => damage.damage = 50);
                    attackModelMAINATTACK.GetDescendants<DamageOverTimeModel>().ForEach(damage => damage.damage = 100);
                    attackModelMAINATTACK.GetDescendants<DamageOverTimeModel>().ForEach(interval => interval.interval = 0.1f);
                    towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Alchemist-050").GetBehaviors<AbilityModel>().First().Duplicate());
                    var abilityModel = towerModel.GetAbility();
                    abilityModel.GetDescendants<AttackModel>().ForEach(range => range.range = towerModel.range);
                    abilityModel.GetDescendants<DamageModel>().ForEach(damage => damage.damage = 1000f);
                    abilityModel.cooldown = 180;
                    abilityModel.GetDescendants<ProjectileModel>().ForEach(pierce => pierce.pierce = 1000f);
                    abilityModel.GetDescendants<ProjectileModel>().ForEach(aimbot => aimbot.AddBehavior(new TrackTargetWithinTimeModel("aimbot", 999999f, true, false, 144f, false, 99999999f, false, 3.47999978f, true)));
                    abilityModel.GetDescendants<ProjectileModel>().ForEach(proj => proj.ApplyDisplay<MONKELASERS>());



                    towerModel.GetDescendants<FilterInvisibleModel>().ForEach(filter => filter.isActive = false);
                    towerModel.GetDescendants<DamageModel>().ForEach(immune => immune.immuneBloonProperties = Il2Cpp.BloonProperties.None);
                }
            }
            public class HyperScienceDisplay : ModTowerDisplay<HyperScience>
            {
                public override string BaseDisplay => GetDisplay(TowerType.Alchemist, 5, 0, 0);
                public override bool UseForTower(int[] tiers)
                { return IsParagon(tiers); }
                public override int ParagonDisplayIndex => 0;
                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    foreach (var renderer in node.genericRenderers)
                    {
                        renderer.SetOutlineColor(new Color(15f / 255, 50f / 255, 89f / 255));
                    }
                    node.genericRenderers.First().material.mainTexture = GetTexture("AlchemistParagonDisplay");
                }
            }
            public class MONKELASERS : ModDisplay
            {
                public override string BaseDisplay => "7e672209db39b9e4db63c13dbe11cad5";
                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "AlchemistParagonLasersDisplay");
                }
            }
            public class PermaBrewIcon : ModBuffIcon
            {
                public new virtual SpriteReference IconReference  => (SpriteReference)VanillaSprites.PermanentBrewUpgradeIcon;
            }
        }
    }
    public class Settings : ModSettings
    {
        

        private static readonly ModSettingCategory OPParagons = new ("Toggle OP Mode of Paragons")
        {
            modifyCategory = category =>
            {

            }
        };

        

        private static readonly ModSettingCategory ParagonCost = new("Paragon Costs")
        {
            modifyCategory = category =>
            {

            }
        };

        
    }
}