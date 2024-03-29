﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Patcher {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Configs {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Configs() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Patcher.Configs", typeof(Configs).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на [
        ///  {
        ///    &quot;_type&quot;: &quot;BANK_NAGA_TEMPLE&quot;,
        ///    &quot;_shared&quot;: &quot;/MapObjects/NEWBANK1.(AdvMapBuildingShared).xdb&quot;
        ///  },
        ///  {
        ///    &quot;_type&quot;: &quot;BANK_DEMOLISH&quot;,
        ///    &quot;_shared&quot;: &quot;/MapObjects/NagaTemple.(AdvMapBuildingShared).xdb&quot;
        ///  },
        ///  {
        ///    &quot;_type&quot;: &quot;BANK_SUNKEN_TEMPLE&quot;,
        ///    &quot;_shared&quot;: &quot;/MapObjects/DemonBank.(AdvMapBuildingShared).xdb&quot;
        ///  },
        ///  {
        ///    &quot;_type&quot;: &quot;BANK_UNKEMPT&quot;,
        ///    &quot;_shared&quot;: &quot;/MapObjects/HumanBank.(AdvMapBuildingShared).xdb&quot;
        ///  },
        ///  {
        ///    &quot;_type&quot;: &quot;BANK_CRYPT&quot;,
        ///    &quot;_shared&quot;: &quot;/MapObjects/Crypt [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string BANK_TYPE_MAPPING {
            get {
                return ResourceManager.GetString("BANK_TYPE_MAPPING", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на {
        ///  &quot;_dayLights&quot;: [
        ///    &quot;/Lights/_(AmbientLight)/Town/Day_light_Haven01(VicTest).xdb#xpointer(/AmbientLight)&quot;,
        ///    &quot;/Lights/_(AmbientLight)/Town/Day_light_Haven01(PanovTest).xdb#xpointer(/AmbientLight)&quot;,
        ///    &quot;/Lights/_(AmbientLight)/AdvMap/Addon/A1SM3.xdb#xpointer(/AmbientLight)&quot;
        ///  ],
        ///
        ///  &quot;_nightLights&quot;: [
        ///    &quot;/Lights/_(AmbientLight)/Tests/c4m4_wastes.xdb#xpointer(/AmbientLight)&quot;,
        ///    &quot;/Lights/_(AmbientLight)/Arena/dirtArena/DirtArena01 (2).xdb#xpointer(/AmbientLight)&quot;,
        ///    &quot;/Lights/_(AmbientLight [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string lights {
            get {
                return ResourceManager.GetString("lights", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на {
        ///  &quot;BaseDetectors&quot;: {
        ///    &quot;template&quot;: &quot;BTD.Patcher.MapInfo.TemplateDetector&quot;,
        ///    &quot;playersCount&quot;: &quot;BTD.Patcher.MapInfo.PlayersCountDetector&quot;
        ///  },
        ///  &quot;FileDetectors&quot;: {
        ///    &quot;mainXdb&quot;: &quot;BTD.Patcher.MapInfo.MainXdbDetector&quot;,
        ///    &quot;mapTag&quot;: &quot;BTD.Patcher.MapInfo.MapTagDetector&quot;
        ///  }
        ///}.
        /// </summary>
        internal static string map_fields_detectors {
            get {
                return ResourceManager.GetString("map_fields_detectors", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на {
        ///  &quot;BankDetector&quot;: {
        ///    &quot;_type&quot;: &quot;BTD.Patcher.BuildingDetector&quot;,
        ///    &quot;_name&quot;: &quot;AdvMapBuilding&quot;,
        ///    &quot;_props&quot;: {
        ///      &quot;_config&quot;: &quot;BANK_TYPE_MAPPING&quot;,
        ///      &quot;_output&quot;: &quot;BTD_BanksInfo&quot;
        ///    }
        ///  },
        ///
        ///  &quot;NewBuildingsDetector&quot;: {
        ///    &quot;_type&quot;: &quot;BTD.Patcher.BuildingDetector&quot;,
        ///    &quot;_name&quot;: &quot;AdvMapBuilding&quot;,
        ///    &quot;_props&quot;: {
        ///      &quot;_config&quot;: &quot;OBJECT_TYPE_MAPPING&quot;,
        ///      &quot;_output&quot;: &quot;BTD_NewObjects&quot;
        ///    }
        ///  },
        ///
        ///  &quot;TreasuresDetector&quot;: {
        ///    &quot;_type&quot;: &quot;BTD.Patcher.TreasureDetector&quot;,
        ///    &quot;_name&quot;: &quot;AdvM [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string OBJECT_DETECTOR_DECORATORS {
            get {
                return ResourceManager.GetString("OBJECT_DETECTOR_DECORATORS", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на [
        ///  {
        ///    &quot;_type&quot;: &quot;BTD_STATUE_OF_REVELATION&quot;,
        ///    &quot;_shared&quot;: &quot;/MapObjects/BTD/StatueOfRevelation.(AdvMapBuildingShared).xdb&quot;
        ///  },
        ///
        ///  {
        ///    &quot;_type&quot;: &quot;BTD_SUN_RIDER_MONUMENT&quot;,
        ///    &quot;_shared&quot;: &quot;/MapObjects/BTD/SunRiderMonument/building.(AdvMapBuildingShared).xdb&quot;
        ///  },
        ///
        ///  {
        ///    &quot;_type&quot;: &quot;BTD_WARMEN_HOUSE&quot;,
        ///    &quot;_shared&quot;: &quot;/MapObjects/BTD/WarmenHouse/building.(AdvMapBuildingShared).xdb&quot;
        ///  },
        ///  {
        ///    &quot;_type&quot;: &quot;BTD_KNOWLEDGE_MEGALITH&quot;,
        ///    &quot;_shared&quot;: &quot;/MapObjects/BTD/KnowledgeMegalith/KnowledgeMeg [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string OBJECT_TYPE_MAPPING {
            get {
                return ResourceManager.GetString("OBJECT_TYPE_MAPPING", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на [
        ///  &quot;AdvMapBuilding&quot;,
        ///  &quot;AdvMapStatic&quot;,
        ///  &quot;AdvMapTreasure&quot;
        ///].
        /// </summary>
        internal static string OBJECTS_NAMES {
            get {
                return ResourceManager.GetString("OBJECTS_NAMES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на &lt;Item href=&quot;#n:inline(AdvMapShrine)&quot; id=&quot;item_A9D916B6-3446-4655-B6CD-8C040A6351680&quot;&gt;
        ///			&lt;AdvMapShrine&gt;
        ///				&lt;Pos&gt;
        ///					&lt;x&gt;1&lt;/x&gt;
        ///					&lt;y&gt;1&lt;/y&gt;
        ///					&lt;z&gt;-10&lt;/z&gt;
        ///				&lt;/Pos&gt;
        ///				&lt;Rot&gt;3.14159&lt;/Rot&gt;
        ///				&lt;Floor&gt;0&lt;/Floor&gt;
        ///				&lt;Name&gt;SHRINE_0&lt;/Name&gt;
        ///				&lt;CombatScript/&gt;
        ///				&lt;pointLights/&gt;
        ///				&lt;Shared href=&quot;/MapObjects/Shrine_Of_Magic_1.(AdvMapShrineShared).xdb#xpointer(/AdvMapShrineShared)&quot;/&gt;
        ///				&lt;SpellID&gt;SPELL_NONE&lt;/SpellID&gt;
        ///			&lt;/AdvMapShrine&gt;
        ///		&lt;/Item&gt;
        ///		&lt;Item href=&quot;#n:inline(AdvMapShrine)&quot; id=&quot;item_A [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string OBJECTS_SHRINES {
            get {
                return ResourceManager.GetString("OBJECTS_SHRINES", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на {
        ///  &quot;script&quot;: {
        ///    &quot;Type&quot;: &quot;BTD.Patcher.ScriptGenerator&quot;,
        ///    &quot;File&quot;: &quot;mainXdb&quot;,
        ///    &quot;RequestedParameter&quot;: null
        ///  },
        ///  &quot;object&quot;: {
        ///    &quot;Type&quot;: &quot;BTD.Patcher.ObjectDetector&quot;,
        ///    &quot;File&quot;: &quot;mainXdb&quot;,
        ///    &quot;RequestedParameter&quot;: null
        ///  },
        ///  &quot;quest&quot;: {
        ///    &quot;Type&quot;: &quot;BTD.Patcher.QuestGenerator&quot;,
        ///    &quot;File&quot;: &quot;mainXdb&quot;,
        ///    &quot;RequestedParameter&quot;: null
        ///  },
        ///  &quot;light&quot;: {
        ///    &quot;Type&quot;: &quot;BTD.Patcher.LightGenerator&quot;,
        ///    &quot;File&quot;: &quot;mainXdb&quot;,
        ///    &quot;RequestedParameter&quot;: &quot;useNightLight&quot;
        ///  },
        ///  &quot;team_generator&quot;: [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string patcher_types {
            get {
                return ResourceManager.GetString("patcher_types", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на 					&lt;Item&gt;
        ///						&lt;Name&gt;HIDDEN&lt;/Name&gt;
        ///						&lt;CaptionFileRef href=&quot;&quot;/&gt;
        ///						&lt;ObscureCaptionFileRef href=&quot;&quot;/&gt;
        ///						&lt;DescriptionFileRef href=&quot;&quot;/&gt;
        ///						&lt;ProgressCommentsFileRef/&gt;
        ///						&lt;Kind&gt;OBJECTIVE_KIND_MANUAL&lt;/Kind&gt;
        ///						&lt;Parameters/&gt;
        ///						&lt;Timeout&gt;-1&lt;/Timeout&gt;
        ///						&lt;Holdout&gt;-1&lt;/Holdout&gt;
        ///						&lt;CheckDelay&gt;-1&lt;/CheckDelay&gt;
        ///						&lt;Dependencies/&gt;
        ///						&lt;InstantVictory&gt;false&lt;/InstantVictory&gt;
        ///						&lt;TargetGlance&gt;
        ///							&lt;Target&gt;
        ///								&lt;Type&gt;ADV_TARGET_NONE&lt;/Type&gt;
        ///								&lt;Name/&gt;
        ///								&lt; [остаток строки не уместился]&quot;;.
        /// </summary>
        internal static string Quest {
            get {
                return ResourceManager.GetString("Quest", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
        ///&lt;Script&gt;
        ///	&lt;FileName href=&quot;MapScript.lua&quot;/&gt;
        ///	&lt;ScriptText/&gt;
        ///&lt;/Script&gt;
        ///.
        /// </summary>
        internal static string script_xdb {
            get {
                return ResourceManager.GetString("script_xdb", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на [
        ///  &quot;S0-1P2Z2K3.1T&quot;,
        ///  &quot;BTD-Square&quot;,
        ///  &quot;S0-1P2Z2K3T&quot;,
        ///  &quot;BTD-K1S&quot;,
        ///  &quot;S1-2P2-8Z8K2S&quot;,
        ///  &quot;BTD-Universe&quot;,
        ///  &quot;S1-3P2-4Z5V&quot;,
        ///  &quot;BTD-Test&quot;,
        ///  &quot;S1P2Z3K5.1&quot;,
        ///  &quot;S2-3P2Z7N2&quot;,
        ///  &quot;BTD-RMS&quot;,
        ///  &quot;BTD-Pirate(W)&quot;,
        ///  &quot;BTD-JebusCross&quot;,
        ///  &quot;BTD-KingsBounty&quot;,
        ///  &quot;BTD-Circles&quot;,
        ///  &quot;BTD-ClashOfDragons&quot;,
        ///  &quot;BTD-KingsBounty&quot;,
        ///  &quot;BTD-SandGlass&quot;,
        ///  &quot;BTD-2x2&quot;,
        ///  &quot;BTD-Hexagonal&quot;,
        ///  &quot;BTD-1deal&quot;,
        ///  &quot;BTD-RMS-GIGA&quot;,
        ///  &quot;BTD-Dynamite&quot;,
        ///  &quot;BTD-UniverseX6&quot;,
        ///  &quot;BTD-MightMagic&quot;,
        ///  &quot;BTD-Double&quot;,
        ///  &quot;BTD-Anarchy&quot;
        ///].
        /// </summary>
        internal static string templates {
            get {
                return ResourceManager.GetString("templates", resourceCulture);
            }
        }
    }
}
