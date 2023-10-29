using System;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using MelonLoader;
using ModHelperData = MagicParagons.ModHelperData;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Weapons;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using System.Linq;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Utils;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Color = UnityEngine.Color;

[assembly: MelonInfo(typeof(MagicParagons.Main), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace MagicParagons
{
    public class Main : BloonsTD6Mod
    {
        public static string[] towersToIgnore = { "" };

        public override void OnApplicationStart()
        {
            MelonLogger.Msg(System.ConsoleColor.Magenta, "Magic Paragons Loaded!");
        }

        public class DruidParagon
        {
            public class PrimordialKing : ModVanillaParagon
            {
                public override string BaseTower => "Druid-005";
            }

            public class PrimordialKingUpgrade : ModParagonUpgrade<PrimordialKing>
            {
                public override int Cost => 2000000;

                public override string Description =>
                    "The source of all druid magic... More powerful than any other...";

                public override string DisplayName => "Primordial King";
                public override string Icon => "DruidParagonIcon";
                public override string Portrait => "DruidParagonPortrait";

                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    var LightningDisplay = new CreateLightningEffectModel("cool", 0.3f,
                        new PrefabReference[]
                        {
                            new PrefabReference() { guidRef = GetDisplayGUID<LightningSmall1Display>() },
                            new PrefabReference() { guidRef = GetDisplayGUID<LightningSmall2Display>() },
                            new PrefabReference() { guidRef = GetDisplayGUID<LightningSmall3Display>() },
                            new PrefabReference() { guidRef = GetDisplayGUID<LightningMedium1Display>() },
                            new PrefabReference() { guidRef = GetDisplayGUID<LightningMedium2Display>() },
                            new PrefabReference() { guidRef = GetDisplayGUID<LightningMedium3Display>() },
                            new PrefabReference() { guidRef = GetDisplayGUID<LightningLarge1Display>() },
                            new PrefabReference() { guidRef = GetDisplayGUID<LightningLarge2Display>() },
                            new PrefabReference() { guidRef = GetDisplayGUID<LightningLarge3Display>() }
                        },
                        new float[]
                        {
                            17.962965f, 17.962965f, 17.962965f, 50.0000076f, 50.0000076f, 50.0000076f, 85.18519f,
                            85.18519f, 85.18519f
                        });
                    var LightningDisplay2 = new CreateLightningEffectModel("cool", 0.3f,
                        new PrefabReference[]
                        {
                            new PrefabReference() { guidRef = GetDisplayGUID<LightningSmall1Display>() },
                            new PrefabReference() { guidRef = GetDisplayGUID<LightningSmall3Display>() },
                            new PrefabReference() { guidRef = GetDisplayGUID<LightningSmall3Display>() },
                            new PrefabReference() { guidRef = GetDisplayGUID<LightningMedium1Display>() },
                            new PrefabReference() { guidRef = GetDisplayGUID<LightningMedium3Display>() },
                            new PrefabReference() { guidRef = GetDisplayGUID<LightningMedium3Display>() },
                            new PrefabReference() { guidRef = GetDisplayGUID<LightningLarge1Display>() },
                            new PrefabReference() { guidRef = GetDisplayGUID<LightningLarge3Display>() },
                            new PrefabReference() { guidRef = GetDisplayGUID<LightningLarge3Display>() }
                        },
                        new float[]
                        {
                            17.962965f, 17.962965f, 17.962965f, 50.0000076f, 50.0000076f, 50.0000076f, 85.18519f,
                            85.18519f, 85.18519f
                        });
                    towerModel.RemoveBehavior<PoplustSupportModel>();
                    towerModel.displayScale = 1.75f;
                    towerModel.range = 95;
                    towerModel.RemoveBehaviors<AttackModel>();
                    towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Druid-050")
                        .GetBehavior<PerRoundCashBonusTowerModel>().Duplicate());
                    var CashBonus = towerModel.GetBehavior<PerRoundCashBonusTowerModel>();
                    CashBonus.cashPerRound = 10000;
                    towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Druid-050")
                        .GetBehavior<SpiritOfTheForestModel>().Duplicate());
                    var VinesOnTrack = towerModel.GetBehavior<SpiritOfTheForestModel>();
                    VinesOnTrack.closeRange = 100000;
                    VinesOnTrack.middleRange = 200000;
                    VinesOnTrack.GetDescendants<DamageOverTimeCustomModel>().Last().interval = 0.25f;
                    VinesOnTrack.GetDescendants<DamageOverTimeCustomModel>().Last().additive = 28;
                    VinesOnTrack.objectToPlace1ClosePath = new PrefabReference()
                    {
                        guidRef = GetDisplayGUID<Vine1Display>()
                    };
                    VinesOnTrack.objectToPlace2ClosePath = new PrefabReference()
                    {
                        guidRef = GetDisplayGUID<Vine2Display>()
                    };
                    VinesOnTrack.objectToPlace3ClosePath = new PrefabReference()
                    {
                        guidRef = GetDisplayGUID<Vine3Display>()
                    };
                    VinesOnTrack.objectToPlace4ClosePath = new PrefabReference()
                    {
                        guidRef = GetDisplayGUID<Vine1Display>()
                    };
                    towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Druid-050").GetDescendants<AttackModel>()
                        .Last().Duplicate());
                    var JungleVine = towerModel.GetAttackModels()[0];
                    JungleVine.GetDescendant<JungleVineLimitProjectileModel>().limit = 20;
                    towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Druid-500").GetDescendant<AttackModel>()
                        .Duplicate());
                    var StormAttack = towerModel.GetAttackModels()[1];
                    StormAttack.GetDescendants<DamageModel>().ForEach(damage => damage.damage *= 10);
                    StormAttack.GetDescendants<WeaponModel>().ForEach(weapon => weapon.rate *= 0.25f);
                    StormAttack.range = towerModel.range;
                    StormAttack.weapons[3].rate = 0.001f;
                    StormAttack.GetDescendants<ProjectileModel>().Last().RemoveBehavior<CreateLightningEffectModel>();
                    StormAttack.GetDescendants<ProjectileModel>().Last().AddBehavior(LightningDisplay);
                    StormAttack.weapons[1].projectile.GetDescendant<ProjectileModel>()
                        .RemoveBehavior<CreateLightningEffectModel>();
                    StormAttack.weapons[1].projectile.GetDescendant<ProjectileModel>().AddBehavior(LightningDisplay);
                    StormAttack.weapons[2].rate = 1;
                    StormAttack.weapons[2].projectile.GetDescendant<ProjectileModel>().GetDescendant<ProjectileModel>()
                        .RemoveBehavior<CreateLightningEffectModel>();
                    StormAttack.weapons[2].projectile.GetDescendant<ProjectileModel>().GetDescendant<ProjectileModel>()
                        .AddBehavior(LightningDisplay2);
                    towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Druid-005").GetDescendant<AttackModel>()
                        .Duplicate());
                    var WrathAttack = towerModel.GetAttackModels()[2];
                    WrathAttack.range = towerModel.range;
                    WrathAttack.GetDescendant<ProjectileModel>().pierce = 1000;
                    WrathAttack.GetDescendant<RandomEmissionModel>().count = 20;
                    WrathAttack.GetDescendant<WeaponModel>().rate = 0.1f;
                    WrathAttack.GetDescendant<DamageModel>().damage = 300;
                    towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Alchemist-500")
                        .GetBehaviors<AttackModel>().Last().Duplicate());
                    var PoplustBuff = towerModel.GetAttackModels()[3];
                    PoplustBuff.range = 999999;
                    PoplustBuff.GetDescendants<WeaponModel>().ForEach(weapon => weapon.rate = 0.001f);
                    PoplustBuff.GetDescendant<AddBerserkerBrewToProjectileModel>().buffIconName = GetInstance<DruidBuffIcon>().Id;
                    PoplustBuff.GetDescendant<AddBerserkerBrewToProjectileModel>().buffLocsName = GetInstance<DruidBuffIcon>().Icon;
                    PoplustBuff.GetDescendants<AddBerserkerBrewToProjectileModel>()
                        .ForEach(damage => damage.damageUp = 10);
                    PoplustBuff.GetDescendants<AddBerserkerBrewToProjectileModel>()
                        .ForEach(damage => damage.pierceUp = 5);
                    PoplustBuff.GetDescendants<AddBerserkerBrewToProjectileModel>().ForEach(rate => rate.rateUp = 0.2f);
                    PoplustBuff.GetDescendants<AddBerserkerBrewToProjectileModel>().ForEach(range => range.rangeUp = 0);
                    PoplustBuff.GetDescendant<ProjectileModel>().RemoveBehavior<CreateSoundOnProjectileExpireModel>();
                    foreach (var tower in Game.instance.model.towers)
                    {
                        if (tower.baseId != "Druid")
                        {
                            Array.Resize(ref towersToIgnore, towersToIgnore.Length + 1);
                            towersToIgnore[towersToIgnore.Length - 1] = tower.baseId;
                        }
                    }

                    PoplustBuff.GetDescendants<BrewTargettingModel>()
                        .ForEach(target => target.towerIgnoreList = towersToIgnore);



                    towerModel.GetDescendants<FilterInvisibleModel>().ForEach(x => x.isActive = false);
                    towerModel.GetDescendants<DamageModel>()
                        .ForEach(x => x.immuneBloonProperties = Il2Cpp.BloonProperties.None);
                }
            }

            public class DruidBuffIcon : ModBuffIcon
            {
                public override string Icon => GetTextureGUID("DruidParagonBuffIcon");
            }

            public class Vine1Display : ModDisplay
            {
                public override string BaseDisplay => Generic2dDisplay;

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "SpiritOfTheForestStrongVines");
                }
            }

            public class Vine2Display : ModDisplay
            {
                public override string BaseDisplay => Generic2dDisplay;

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "SpiritOfTheForestStrongVines02");
                }
            }

            public class Vine3Display : ModDisplay
            {
                public override string BaseDisplay => Generic2dDisplay;

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "SpiritOfTheForestStrongVines03");
                }
            }

            public class LightningLarge1Display : ModDisplay
            {
                public override string BaseDisplay => Generic2dDisplay;

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "LightningLarge1");
                }
            }

            public class LightningLarge2Display : ModDisplay
            {
                public override string BaseDisplay => Generic2dDisplay;

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "LightningLarge2");
                }
            }

            public class LightningLarge3Display : ModDisplay
            {
                public override string BaseDisplay => Generic2dDisplay;

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "LightningLarge3");
                }
            }

            public class LightningMedium1Display : ModDisplay
            {
                public override string BaseDisplay => Generic2dDisplay;

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "LightningMedium1");
                }
            }

            public class LightningMedium2Display : ModDisplay
            {
                public override string BaseDisplay => Generic2dDisplay;

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "LightningMedium2");
                }
            }

            public class LightningMedium3Display : ModDisplay
            {
                public override string BaseDisplay => Generic2dDisplay;

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "LightningMedium3");
                }
            }

            public class LightningSmall1Display : ModDisplay
            {
                public override string BaseDisplay => Generic2dDisplay;

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "LightningSmall1");
                }
            }

            public class LightningSmall2Display : ModDisplay
            {
                public override string BaseDisplay => Generic2dDisplay;

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "LightningSmall2");
                }
            }

            public class LightningSmall3Display : ModDisplay
            {
                public override string BaseDisplay => Generic2dDisplay;

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "LightningSmall3");
                }
            }

            public class AvatarOfWrathBolt : ModDisplay
            {
                public override string BaseDisplay => Generic2dDisplay;

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "AvatarOfWrathBolt");
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
                        renderer.material.mainTexture = GetTexture("DruidParagonDisplay");
                    }
                }
            }
        }

        public class AlchemistParagon
        {
            public class HyperScience : ModVanillaParagon
            {
                public override string BaseTower => "Alchemist-005";
            }

            public class HyperScienceUpgrade : ModParagonUpgrade<HyperScience>
            {
                public override int Cost => 1200000;

                public override string Description =>
                    "After years of experiments, trials and errors and decades of monkey knowledge, the perfect potions are now upon us!";

                public override string DisplayName => "Hyper-Science";
                public override string Icon => "AlchemistParagonIcon";
                public override string Portrait => "AlchemistParagonPortrait";

                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    towerModel.displayScale = 1.5f;
                    towerModel.range = 100;
                    towerModel.RemoveBehaviors<AttackModel>();
                    towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Alchemist-500").GetBehaviors<AttackModel>().Last().Duplicate());
                    var attackModelBREW = towerModel.GetAttackModels()[0];
                    attackModelBREW.range = towerModel.range;
                    attackModelBREW.GetDescendants<WeaponModel>().ForEach(weapon => weapon.rate = 0.2f);
                    attackModelBREW.GetDescendant<AddBerserkerBrewToProjectileModel>().buffIconName = GetInstance<AlchemistBuffIcon>().Id;
                    attackModelBREW.GetDescendant<AddBerserkerBrewToProjectileModel>().buffLocsName = GetInstance<AlchemistBuffIcon>().Icon;
                    attackModelBREW.GetDescendants<AddBerserkerBrewToProjectileModel>().ForEach(damage => damage.damageUp = 5);
                    attackModelBREW.GetDescendants<AddBerserkerBrewToProjectileModel>().ForEach(damage => damage.pierceUp = 20);
                    attackModelBREW.GetDescendants<AddBerserkerBrewToProjectileModel>().ForEach(rate => rate.rateUp = 0.2f);
                    attackModelBREW.GetDescendants<AddBerserkerBrewToProjectileModel>().ForEach(range => range.rangeUp = 1);
                    towerModel.AddBehavior(Game.instance.model.GetTowerFromId("Alchemist-005").GetBehaviors<AttackModel>().Last().Duplicate());
                    var attackModelREDTRANSFORM = towerModel.GetAttackModels()[1];
                    attackModelREDTRANSFORM.GetDescendant<WeaponModel>().rate = 0.86f;
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
                    abilityModel.GetBehavior<MorphTowerModel>().maxCost = 999999999f;
                    abilityModel.GetBehavior<MorphTowerModel>().maxTowers = 999999;
                    abilityModel.GetBehavior<MorphTowerModel>().maxTier = 4;
                    abilityModel.GetBehavior<MorphTowerModel>().affectList = "DartMonkey, BoomerangMonkey, BombShooter, TackShooter, IceMonkey, GlueGunner, SniperMonkey, DartlingGunner, WizardMonkey, NinjaMonkey, Alchemist, Druid, EngineerMonkey";
                    abilityModel.GetDescendants<AttackModel>().ForEach(range => range.range = 99999999999f);
                    abilityModel.GetDescendants<DamageModel>().ForEach(damage => damage.damage = 1000f);
                    abilityModel.cooldown = 180;
                    abilityModel.GetDescendants<ProjectileModel>().ForEach(pierce => pierce.pierce = 1000f);
                    abilityModel.GetDescendants<ProjectileModel>().ForEach(aimbot => aimbot.AddBehavior(new TrackTargetWithinTimeModel("aimbot", 999999f, true, false, 144f, false, 99999999f, false, 3.47999978f, true)));
                    abilityModel.GetDescendants<ProjectileModel>().ForEach(proj => proj.ApplyDisplay<MONKELASERS>());
                    abilityModel.GetBehavior<MorphTowerModel>().MorthTowerNotSelf.newTowerModel.GetDescendants<AttackModel>().ForEach(range => range.range = 99999999999f);
                    abilityModel.GetBehavior<MorphTowerModel>().morthTowerNotSelf.newTowerModel.GetDescendants<DamageModel>().ForEach(damage => damage.damage = 1000f);
                    abilityModel.GetBehavior<MorphTowerModel>().morthTowerNotSelf.newTowerModel.GetDescendants<ProjectileModel>().ForEach(pierce => pierce.pierce = 1000f);
                    abilityModel.GetBehavior<MorphTowerModel>().morthTowerNotSelf.newTowerModel.GetDescendants<ProjectileModel>().ForEach(aimbot => aimbot.AddBehavior(new TrackTargetWithinTimeModel("aimbot", 999999f, true, false, 144f, false, 99999999f, false, 3.47999978f, true)));
                    abilityModel.GetBehavior<MorphTowerModel>().morthTowerNotSelf.newTowerModel.GetDescendants<ProjectileModel>().ForEach(proj => proj.ApplyDisplay<MONKELASERS>());
                    abilityModel.GetBehavior<MorphTowerModel>().secondaryTowerModel.range = 99999999999f;
                    abilityModel.GetBehavior<MorphTowerModel>().morthTowerNotSelf.newTowerModel.range = 99999999999f;
                    abilityModel.GetBehavior<MorphTowerModel>().morthTowerNotSelf.newTowerModel.GetDescendants<FilterInvisibleModel>().ForEach(filter => filter.isActive = false);
                    abilityModel.GetBehavior<MorphTowerModel>().morthTowerNotSelf.newTowerModel.GetDescendants<AttackModel>().ForEach(filter => filter.attackThroughWalls = true);
                    abilityModel.GetDescendants<TravelStraitModel>().ForEach(travels => travels.lifespan = 2);
                    abilityModel.GetBehavior<MorphTowerModel>().morthTowerNotSelf.newTowerModel.GetDescendants<TravelStraitModel>().ForEach(travels => travels.lifespan = 2);
                    abilityModel.GetBehavior<MorphTowerModel>().morthTowerNotSelf.newTowerModel.ApplyDisplay<MonkeTransformation>();

                    towerModel.GetDescendants<FilterInvisibleModel>().ForEach(filter => filter.isActive = false);
                    towerModel.GetDescendants<DamageModel>().ForEach(immune => immune.immuneBloonProperties = Il2Cpp.BloonProperties.None);
                }
            }

            public class AlchemistBuffIcon : ModBuffIcon
            {
                public override string Icon => GetTextureGUID("AlchemistParagonBuffIcon");
            }

            public class HyperScienceDisplay : ModTowerDisplay<HyperScience>
            {
                public override string BaseDisplay => GetDisplay(TowerType.Alchemist, 5, 0, 0);

                public override bool UseForTower(int[] tiers)
                {
                    return IsParagon(tiers);
                }

                public override int ParagonDisplayIndex => 0;

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    foreach (var renderer in node.genericRenderers)
                    {
                        renderer.SetOutlineColor(new Color(15f / 255, 50f / 255, 89f / 255));
                        if (renderer == node.genericRenderers.Last())
                        {

                        }
                        else
                        {
                            renderer.material.mainTexture = GetTexture("AlchemistParagonDisplay");
                        }
                    }
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

            public class MonkeTransformation : ModDisplay
            {
                public override string BaseDisplay => "c2ca641e5b2249a47b1e6f7dd53db1db";

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    foreach (var renderer in node.genericRenderers)
                    {
                        renderer.material.mainTexture = GetTexture("AlchemistParagonDisplay");
                    }
                }
            }

            public class PermaBrewIcon : ModBuffIcon
            {
                public new virtual SpriteReference IconReference =>
                    (SpriteReference)VanillaSprites.PermanentBrewUpgradeIcon;
            }
        }

        public class WizardParagon
        {
            /*public class PlaceHolder2Tower : ModTower
            {
                public override string DisplayName => "";
                public override string BaseTower => "DartMonkey";
                public override int Cost => 0;
                public override int TopPathUpgrades => 0;
                public override int MiddlePathUpgrades => 0;
                public override bool DontAddToShop => true;
                public override int BottomPathUpgrades => 0;
                public override TowerSet TowerSet => TowerSet.Support;

                public override void ModifyBaseTowerModel(TowerModel towerModel)
                {
                    towerModel.isSubTower = true;
                    towerModel.displayScale = 0.000000000000001f;
                    towerModel.RemoveBehavior<AttackModel>();
                    towerModel.ignoreTowerForSelection = true;
                    towerModel.AddBehavior(new TowerCreateTowerModel("Praying this works",
                        Game.instance.model.GetTowerFromId("WizardMonkey-050").GetDescendant<TowerCreateTowerModel>()
                            .towerModel.Duplicate(), true));
                    var PhoenixModel = towerModel.GetBehavior<TowerCreateTowerModel>().towerModel;
                    PhoenixModel.ApplyDisplay<GrandMagusPhoenixDisplay>();
                    PhoenixModel.GetDescendant<DamageModel>().damage = 100;
                    PhoenixModel.GetDescendant<WeaponModel>().rate = 0.075f;
                    PhoenixModel.GetDescendant<ProjectileModel>().pierce = 100;
                    PhoenixModel.GetDescendant<ProjectileModel>().ApplyDisplay<SmolBall>();
                    PhoenixModel.GetDescendant<ProjectileModel>().scale = 1f;
                    PhoenixModel.AddBehavior(Game.instance.model.GetTowerFromId("WizardMonkey-050")
                        .GetDescendant<AbilityCreateTowerModel>().towerModel.GetBehaviors<AttackModel>().Last()
                        .Duplicate());
                    var BigBall = PhoenixModel.GetAttackModels().Last();
                    BigBall.GetDescendants<ArcEmissionModel>().ForEach(emission => emission.count = 10);
                    BigBall.GetDescendants<WeaponModel>().ForEach(rate => rate.rate = 0.75f);
                    BigBall.GetDescendants<ProjectileModel>().ForEach(pierce => pierce.pierce = 1000);
                    BigBall.GetDescendants<ProjectileModel>().ForEach(display => display.ApplyDisplay<BigBall>());
                    BigBall.GetDescendants<DisplayModel>().ForEach(display => display.ApplyDisplay<BigBall>());
                    BigBall.GetDescendant<DamageModel>().damage = 500;
                    PhoenixModel.GetDescendants<ProjectileModel>().ForEach(aimbot =>
                        aimbot.AddBehavior(new TrackTargetWithinTimeModel("aimbot", 999999f, true, false, 144f, false,
                            99999999f, false, 3.47999978f, true)));

                }
            }

            public class GrandMagus : ModVanillaParagon
            {
                public override string BaseTower => "WizardMonkey-500";
            }

            public class GrandMagusUpgrade : ModParagonUpgrade<GrandMagus>
            {
                public override int Cost => 1600000;

                public override string Description =>
                    "Unravel the mysteries of the arcane arts and see for yourself why they are kept secret.";

                public override string DisplayName => "Grand Magus";
                public override string Icon => "WizardParagonIcon";
                public override string Portrait => "WizardParagonPortrait";

                public override void ApplyUpgrade(TowerModel towerModel)
                {
                    towerModel.towerSelectionMenuThemeId = "UnpoppedArmy";
                    towerModel.displayScale = 2;
                    towerModel.range = 75;
                    towerModel.RemoveBehaviors<AttackModel>();
                    towerModel.AddBehavior(Game.instance.model.GetTowerFromId("WizardMonkey-005")
                        .GetBehaviors<AttackModel>().Last().Duplicate());
                    towerModel.AddBehavior(Game.instance.model.GetTowerFromId("WizardMonkey-005")
                        .GetBehavior<NecromancerZoneModel>().Duplicate());
                    var NecromancerModel = towerModel.GetAttackModels()[0];
                    NecromancerModel.GetDescendant<NecromancerEmissionModel>().maxRbeStored = 100000;
                    NecromancerModel.GetDescendant<NecromancerEmissionModel>().roundsBeforeDecay = 100000;
                    NecromancerModel.GetDescendant<NecromancerEmissionModel>().maxRbeSpawnedPerSecond = 2500;
                    NecromancerModel.GetDescendant<NecromancerEmissionModel>().maxBloonsSpawnedPerWave = 20;
                    NecromancerModel.GetDescendant<CreateEffectOnExhaustedModel>().lifespan = 9999999999f;
                    NecromancerModel.GetDescendant<TravelAlongPathModel>().lifespanFrames = 999999999;
                    NecromancerModel.range = 9999999999;
                    towerModel.AddBehavior(
                        Game.instance.model.GetTowerFromId("WizardMonkey-500").GetBehaviors<AttackModel>()[1]
                            .Duplicate());
                    var ShimmerModel = towerModel.GetAttackModels()[1];
                    ShimmerModel.range = towerModel.range;
                    ShimmerModel.weapons[0].rate = 0.0000000001f;
                    towerModel.AddBehavior(
                        Game.instance.model.GetTowerFromId("WizardMonkey-500").GetBehaviors<AttackModel>()[0]
                            .Duplicate());
                    var MainAttack = towerModel.GetAttackModels()[2];
                    MainAttack.range = towerModel.range;
                    MainAttack.weapons[0].rate = 0.05f;
                    MainAttack.GetDescendant<DamageModel>().damage = 250;
                    towerModel.AddBehavior(
                        Game.instance.model.GetTowerFromId("WizardMonkey-500").GetBehaviors<AttackModel>()[2]
                            .Duplicate());
                    var DragonsBreathAttack = towerModel.GetAttackModels()[3];
                    DragonsBreathAttack.range = towerModel.range;
                    DragonsBreathAttack.GetDescendant<AddBehaviorToBloonModel>().lifespan = 20;
                    DragonsBreathAttack.GetDescendant<DamageOverTimeModel>().interval = 0.5f;
                    DragonsBreathAttack.GetDescendant<DamageOverTimeModel>().damage = 50f;
                    DragonsBreathAttack.GetDescendant<DamageModel>().damage = 10f;


                    towerModel.GetDescendants<FilterInvisibleModel>().ForEach(filter => filter.isActive = false);
                    towerModel.GetDescendants<DamageModel>().ForEach(immune =>
                        immune.immuneBloonProperties = Il2Cpp.BloonProperties.None);
                }
            }

            public class SmolBall : ModDisplay
            {
                public override string BaseDisplay => "7e672209db39b9e4db63c13dbe11cad5";

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "SmolBall");
                }
            }

            public class BigBall : ModDisplay
            {
                public override string BaseDisplay => "7e672209db39b9e4db63c13dbe11cad5";

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    Set2DTexture(node, "BigBall");
                }
            }

            public class GrandMagusPhoenixDisplay : ModTowerDisplay<PlaceHolder2Tower>
            {
                public override string BaseDisplay => "1e5aa5cc44941da43a90880b50d5d112";

                public override bool UseForTower(int[] tiers)
                {
                    return true;
                }

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    foreach (var renderer in node.genericRenderers)
                    {
                        if (renderer == node.genericRenderers.First())
                        {
                            renderer.material.mainTexture = GetTexture("WizardParagonPhoenixDisplay");
                            renderer.SetOutlineColor(new Color(1f / 255, 109f / 255, 130f / 255));
                        }
                        else
                        {

                        }
                    }
                }
            }

            public class GrandMagusDisplay : ModTowerDisplay<GrandMagus>
            {
                public override string BaseDisplay => GetDisplay("WizardMonkey", 0, 3, 0);

                public override bool UseForTower(int[] tiers)
                {
                    return IsParagon(tiers);
                }

                public override int ParagonDisplayIndex => 0;

                public override void ModifyDisplayNode(UnityDisplayNode node)
                {
                    foreach (var renderer in node.genericRenderers)
                    {
                        renderer.material.mainTexture = GetTexture("WizardParagonDisplay");
                        renderer.SetOutlineColor(new Color(235f / 255, 99f / 255, 14f / 255));
                    }
                }
            }*/
        }
    }
}