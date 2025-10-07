using System.Linq;
using NaughtyAttributes;
using TinyColorLib;
using UnityEngine.Assertions;

namespace GameLib.ColorScheme
{
#if UNITY_EDITOR
    public partial class ColorSchemeCreator
    {
        [Button]
        public void PopulateHardcoded()
        {
            InputSource.Clear();

            // For each color: 3 sequences: tint + shade + saturate
            // For each category: 10 colors

            #region Category BasicColorsMaterials

            InputSource.Add(new ColorSource
            {
                Name = "White",
                ShortenedName = "White",
                Category = ColorScheme.MaterialCategory.BasicColorsMaterials,
                Color = TinyColor.ParseFromHex("#FFFFFF").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Black",
                ShortenedName = "Black",
                Category = ColorScheme.MaterialCategory.BasicColorsMaterials,
                Color = TinyColor.ParseFromHex("#000000").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Red",
                ShortenedName = "Red",
                Category = ColorScheme.MaterialCategory.BasicColorsMaterials,
                Color = TinyColor.ParseFromHex("#FF0000").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Green",
                ShortenedName = "Green",
                Category = ColorScheme.MaterialCategory.BasicColorsMaterials,
                Color = TinyColor.ParseFromHex("#008000").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Blue",
                ShortenedName = "Blue",
                Category = ColorScheme.MaterialCategory.BasicColorsMaterials,
                Color = TinyColor.ParseFromHex("#0000FF").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Yellow",
                ShortenedName = "Yellow",
                Category = ColorScheme.MaterialCategory.BasicColorsMaterials,
                Color = TinyColor.ParseFromHex("#FFFF00").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Orange",
                ShortenedName = "Orange",
                Category = ColorScheme.MaterialCategory.BasicColorsMaterials,
                Color = TinyColor.ParseFromHex("#FFA500").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Purple",
                ShortenedName = "Purple",
                Category = ColorScheme.MaterialCategory.BasicColorsMaterials,
                Color = TinyColor.ParseFromHex("#800080").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Gray",
                ShortenedName = "Gray",
                Category = ColorScheme.MaterialCategory.BasicColorsMaterials,
                Color = TinyColor.ParseFromHex("#808080").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Pink",
                ShortenedName = "Pink",
                Category = ColorScheme.MaterialCategory.BasicColorsMaterials,
                Color = TinyColor.ParseFromHex("#FFC0CB").ToColor(),
            });

            #endregion

            #region Category Misc

            InputSource.Add(new ColorSource
            {
                Name = "Reserved 1",
                ShortenedName = "res1",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#FFFFFF").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Reserved 2",
                ShortenedName = "res2",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#67AFF6").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Reserved 3",
                ShortenedName = "res3",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#67AFF6").ToColor(),
            });
            InputSource.Add(new ColorSource
            {
                Name = "Reserved 4",
                ShortenedName = "res4",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#67AFF6").ToColor(),
            });
            InputSource.Add(new ColorSource
            {
                Name = "Reserved 5",
                ShortenedName = "res5",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#67AFF6").ToColor(),
            });
            InputSource.Add(new ColorSource
            {
                Name = "Reserved 6",
                ShortenedName = "res6",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#67AFF6").ToColor(),
            });
            InputSource.Add(new ColorSource
            {
                Name = "Reserved 7",
                ShortenedName = "res7",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#67AFF6").ToColor(),
            });
            InputSource.Add(new ColorSource
            {
                Name = "Reserved 8",
                ShortenedName = "res8",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#67AFF6").ToColor(),
            });
            InputSource.Add(new ColorSource
            {
                Name = "Reserved 9",
                ShortenedName = "res9",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#67AFF6").ToColor(),
            });
            InputSource.Add(new ColorSource
            {
                Name = "Reserved 10",
                ShortenedName = "res10",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#67AFF6").ToColor(),
            });

            #endregion

            #region Category Organic Materials

            InputSource.Add(new ColorSource
            {
                Name = "Blood",
                ShortenedName = "Blood",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#FF0000").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Wood",
                ShortenedName = "Wood",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#8B5A2B").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Fabric / Cloth",
                ShortenedName = "Fabric",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#F28E8E").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Leather",
                ShortenedName = "Leather",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#CFAE8B").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Bark",
                ShortenedName = "Bark",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#5C4033").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Bone",
                ShortenedName = "Bone",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#EDE6D6").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Paper",
                ShortenedName = "Paper",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#FFF8DC").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Rope / Twine",
                ShortenedName = "Rope",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#D2B48C").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Feathers",
                ShortenedName = "Feathers",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#DCDCF5").ToColor(),
                Step = 0.2f,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Hide / Fur",
                ShortenedName = "HideFur",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#A0522D").ToColor(),
            });

            #endregion

            #region Category Fruits and Vegetables

            InputSource.Add(new ColorSource
            {
                Name = "Apple",
                ShortenedName = "Apple",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#FF0800").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Banana",
                ShortenedName = "Banana",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#FFE135").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Carrot",
                ShortenedName = "Carrot",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#FFA500").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Tomato",
                ShortenedName = "Tomato",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#FF6347").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Potato",
                ShortenedName = "Potato",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#D2B48C").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Lettuce",
                ShortenedName = "Lettuce",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#7CFC00").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Orange",
                ShortenedName = "Orange",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#FFA500").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Strawberry",
                ShortenedName = "Strawberry",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#FC5A8D").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Pumpkin",
                ShortenedName = "Pumpkin",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#FF7518").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Grapes",
                ShortenedName = "Grapes",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#6F2DA8").ToColor(), // purple variant
            });

            #endregion

            #region Category General Vegetation

            InputSource.Add(new ColorSource
            {
                Name = "Grass",
                ShortenedName = "Grass",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#7CFC00").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Bushes / Shrubs",
                ShortenedName = "Bushes",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#228B22").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Trees",
                ShortenedName = "Trees",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#006400").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Flowers",
                ShortenedName = "Flowers",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#FF69B4").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Vines / Creepers",
                ShortenedName = "Vines",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#3CB371").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Ferns",
                ShortenedName = "Ferns",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#4F7942").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Moss",
                ShortenedName = "Moss",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#8A9A5B").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Weeds / Wild Plants",
                ShortenedName = "Weeds",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#6B8E23").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Reeds / Tall Grass",
                ShortenedName = "Reeds",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#9ACD32").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Cacti / Succulents",
                ShortenedName = "Cacti",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#568203").ToColor(),
            });

            #endregion

            #region Category Mineral and Building Materials

            InputSource.Add(new ColorSource
            {
                Name = "Stone",
                ShortenedName = "Stone",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#808080").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Brick",
                ShortenedName = "Brick",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#B22222").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Concrete",
                ShortenedName = "Concrete",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#A9A9A9").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Sand",
                ShortenedName = "Sand",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#C2B280").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Marble",
                ShortenedName = "Marble",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#E5E4E2").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Rock",
                ShortenedName = "Rock",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#708090").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Gravel",
                ShortenedName = "Gravel",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#9E9E9E").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Clay",
                ShortenedName = "Clay",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#B66A50").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Slate",
                ShortenedName = "Slate",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#2F4F4F").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Limestone",
                ShortenedName = "Limestone",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#D9D6CF").ToColor(),
            });

            #endregion

            #region Category Metals

            InputSource.Add(new ColorSource
            {
                Name = "Iron",
                ShortenedName = "Iron",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#43464B").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Steel",
                ShortenedName = "Steel",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#B0C4DE").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Copper",
                ShortenedName = "Copper",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#B87333").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Bronze",
                ShortenedName = "Bronze",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#CD7F32").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Silver",
                ShortenedName = "Silver",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#C0C0C0").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Gold",
                ShortenedName = "Gold",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#FFD700").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Aluminum",
                ShortenedName = "Aluminum",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#DCDCDC").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Chrome",
                ShortenedName = "Chrome",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#E5E4E2").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Rusty Metal",
                ShortenedName = "Rusty",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#8B3E2F").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Titanium",
                ShortenedName = "Titanium",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#BFC1C2").ToColor(),
            });

            #endregion

            #region Category Transparent and Translucent Materials

            InputSource.Add(new ColorSource
            {
                Name = "Glass",
                ShortenedName = "Glass",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#A7C7E7").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Water",
                ShortenedName = "Water",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#1CA9C9").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Ice",
                ShortenedName = "Ice",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#AFDBF5").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Crystal",
                ShortenedName = "Crystal",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#B0E0E6").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Fog / Mist",
                ShortenedName = "Fog",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#D3D3D3").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Steam",
                ShortenedName = "Steam",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#C0C0C0").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Plasma / Energy Field",
                ShortenedName = "Plasma",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#00FFFF").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Gel / Slime",
                ShortenedName = "Slime",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#7FFFD4").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Resin / Amber",
                ShortenedName = "Resin",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#FFBF00").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Bubble / Foam",
                ShortenedName = "Bubble",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#E0FFFF").ToColor(),
            });

            #endregion

            #region Category Natural Textures and Ground Materials

            InputSource.Add(new ColorSource
            {
                Name = "Soil / Dirt",
                ShortenedName = "Soil",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#8B4513").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Grass",
                ShortenedName = "Grass",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#228B22").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Mud",
                ShortenedName = "Mud",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#704214").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Sand",
                ShortenedName = "Sand",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#C2B280").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Snow",
                ShortenedName = "Snow",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#FFFFFF").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Gravel",
                ShortenedName = "Gravel",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#A9A9A9").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Rocky Ground",
                ShortenedName = "Rock",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#808080").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Ash / Volcanic Soil",
                ShortenedName = "Ash",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#555555").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Leaves / Forest Floor",
                ShortenedName = "Leaves",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#556B2F").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Moss",
                ShortenedName = "Moss",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#6B8E23").ToColor(),
            });

            #endregion

            #region Category Artificial and Modern Materials

            InputSource.Add(new ColorSource
            {
                Name = "Plastic",
                ShortenedName = "Plastic",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#E0E0E0").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Rubber",
                ShortenedName = "Rubber",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#2F4F4F").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Concrete",
                ShortenedName = "Concrete",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#A9A9A9").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Asphalt",
                ShortenedName = "Asphalt",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#3B3B3B").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Painted Metal",
                ShortenedName = "PaintMetal",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#B22222").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Fabric (Synthetic)",
                ShortenedName = "SynFabric",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#D3D3D3").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Plastic Panel / Polymer Surface",
                ShortenedName = "Polymer",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#CCCCCC").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Circuit / Electronics",
                ShortenedName = "Circuit",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#006400").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Neon Light",
                ShortenedName = "Neon",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#39FF14").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Holographic Material",
                ShortenedName = "Holo",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#DDA0DD").ToColor(),
            });

            #endregion

            #region Category Special Effects Materials

            InputSource.Add(new ColorSource
            {
                Name = "Fire",
                ShortenedName = "Fire",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#FF4500").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Lava",
                ShortenedName = "Lava",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#FF6347").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Magic Essence",
                ShortenedName = "Magic",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#8A2BE2").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Smoke",
                ShortenedName = "Smoke",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#696969").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Electricity",
                ShortenedName = "Electric",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#1E90FF").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Ice / Frost Effect",
                ShortenedName = "Frost",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#ADD8E6").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Acid / Corrosive Substance",
                ShortenedName = "Acid",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#ADFF2F").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Light / Glow Effect",
                ShortenedName = "Glow",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#FFFACD").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Energy / Plasma",
                ShortenedName = "Plasma",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#00FFFF").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Dust / Particles",
                ShortenedName = "Dust",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#D2B48C").ToColor(),
            });

            #endregion

            #region Fabric and Soft Materials

            InputSource.Add(new ColorSource
            {
                Name = "Cotton",
                ShortenedName = "Cotton",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#FAF0E6").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Linen",
                ShortenedName = "Linen",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#EEE6CA").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Wool",
                ShortenedName = "Wool",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#C2B280").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Velvet",
                ShortenedName = "Velvet",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#800020").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Satin",
                ShortenedName = "Satin",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#FFF5EE").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Silk",
                ShortenedName = "Silk",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#F5F5DC").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Microfiber",
                ShortenedName = "Microfib",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#E8E8E8").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Fur / Faux Fur",
                ShortenedName = "Fur",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#D2B48C").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Velour",
                ShortenedName = "Velour",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#B76E79").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Tweed",
                ShortenedName = "Tweed",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#8B7765").ToColor(),
            });

            #endregion

            #region Category Sky and Celestial Materials

            InputSource.Add(new ColorSource
            {
                Name = "Clear Day Sky",
                ShortenedName = "SkyDay",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#87CEEB").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Cloudy Sky",
                ShortenedName = "SkyCloud",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#B0C4DE").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Cumulus Clouds",
                ShortenedName = "Cumulus",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#F5F5F5").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Stratus Clouds",
                ShortenedName = "Stratus",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#DCDCDC").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Cirrus Clouds",
                ShortenedName = "Cirrus",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#E0FFFF").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Sun",
                ShortenedName = "Sun",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#FFD700").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Moon",
                ShortenedName = "Moon",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#F0EAD6").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Stars",
                ShortenedName = "Stars",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#FFFFE0").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Night Sky",
                ShortenedName = "SkyNight",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#191970").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Sunset / Sunrise Sky",
                ShortenedName = "Sunset",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#FFB347").ToColor(),
            });

            #endregion

            #region Category Precious Metals and Gems

            InputSource.Add(new ColorSource
            {
                Name = "Gold",
                ShortenedName = "Gold",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#FFD700").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Silver",
                ShortenedName = "Silver",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#C0C0C0").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Copper",
                ShortenedName = "Copper",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#B87333").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Bronze",
                ShortenedName = "Bronze",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#CD7F32").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Platinum",
                ShortenedName = "Platinum",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#E5E4E2").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Diamond",
                ShortenedName = "Diamond",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#B9F2FF").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Ruby",
                ShortenedName = "Ruby",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#E0115F").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Sapphire",
                ShortenedName = "Sapphire",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#0F52BA").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Emerald",
                ShortenedName = "Emerald",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#50C878").ToColor(),
            });

            InputSource.Add(new ColorSource
            {
                Name = "Amethyst",
                ShortenedName = "Amethyst",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#9966CC").ToColor(),
            });

            #endregion

            foreach (var colorSource in InputSource)
            {
                colorSource.Step = 0.2f;
                colorSource.GenerateTint = 6;
                colorSource.GenerateShade = 6;
                colorSource.GenerateSaturate = 6;
            }

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.BasicColorsMaterials) == 10,
                "BasicColorsMaterials category must contain exactly 10 color sources");

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.Misc) == 10,
                "Misc category must contain exactly 10 color sources");

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.OrganicMaterials) == 10,
                "OrganicMaterials category must contain exactly 10 color sources");

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.FruitsAndVegetables) == 10,
                "FruitsAndVegetables category must contain exactly 10 color sources");

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.GeneralVegetation) == 10,
                "GeneralVegetation category must contain exactly 10 color sources");

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.MineralAndBuildingMaterials) == 10,
                "MineralAndBuildingMaterials category must contain exactly 10 color sources");

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.Metals) == 10,
                "Metals category must contain exactly 10 color sources");

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials) == 10,
                "TransparentAndTranslucentMaterials category must contain exactly 10 color sources");

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials) == 10,
                "NaturalTexturesAndGroundMaterials category must contain exactly 10 color sources");

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.ArtificialAndModernMaterials) == 10,
                "Artificial and Modern Materials category must contain exactly 10 color sources");

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.SpecialEffectsMaterials) == 10,
                "Special Effects Materials category must contain exactly 10 color sources");

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.FabricAndSoftMaterials) == 10,
                "FabricAndSoftMaterials category must contain exactly 10 color sources");

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.SkyAndCelestialMaterials) == 10,
                "Sky and Celestial Materials category must contain exactly 10 color sources");

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.PreciousMetalsAndGems) == 10,
                "Precious Metals and Gems category must contain exactly 10 color sources");
        }
    }
#endif
}