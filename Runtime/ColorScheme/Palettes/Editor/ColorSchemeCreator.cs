using System;
using NaughtyAttributes;
using System.Collections.Generic;
using System.Linq;
using TinyColorLib;
using UnityEngine;
using UnityEngine.Assertions;
using Color = UnityEngine.Color;

namespace GameLib.ColorScheme
{
#if UNITY_EDITOR
    [CreateAssetMenu(fileName = "ColorSchemeCreator", menuName = "GameLib/Color/ColorSchemeCreator", order = 1)]
    public class ColorSchemeCreator : ScriptableObject
    {
        [Serializable]
        public class ColorSource
        {
            // Set default values. Supposed to be redefined by user manually in the inspector
            public ColorSource()
            {
                Name = null;
                Step = 0.1f;
            }

            public ColorSource Randomize()
            {
                // todo: move to tinycolor package as a random helper
                var randomColor = TinyColorLib.Color.Colors
                    .ElementAt(UnityEngine.Random.Range(0, TinyColorLib.Color.Colors.Count)).Value;
                Name = randomColor.ToName();
                Assert.IsNotNull(Name);

                float mutation = UnityEngine.Random.Range(0f, 0.4f);
                if (mutation > 0.05f)
                {
                    if (randomColor.IsDark())
                    {
                        randomColor = randomColor.Brighten(mutation);
                        Name = $"Brighten{Name}{mutation:F1}";
                    }
                    else
                    {
                        randomColor = randomColor.Darken(mutation);
                        Name = $"Darken{Name}{mutation:F1}";
                    }
                }

                Color = randomColor.ToColor();
                return this;
            }

            public string Name;
            public string ShortenedName;
            public ColorScheme.MaterialCategory Category;
            public Color Color;
            public float Step;


            public int GenerateBrighten; // 0 - don't generate, n - generate n grades of brighten colors with the step == Step
            public int GenerateLighten; // 0 - don't generate, n - generate n grades of lighten colors with the step == Step
            public int GenerateDarken; // 0 - don't generate, n - generate n grades of darken colors with the step == Step
            public int GenerateTint; // 0 - don't generate, n - generate n grades of tint colors with the step == Step
            public int GenerateShade; // 0 - don't generate, n - generate n grades of shaded colors with the step == Step
            public int GenerateSaturate; // 0 - don't generate, n - generate n grades of saturated colors with the step == Step
            public int GenerateDesaturate; // 0 - don't generate, n - generate n grades of desaturated colors with the step == Step
            public int GenerateMonochromatic; // 0 - don't generate, n - generate n grades of monochromatic colors with the step == Step
            public int GenerateAnalogous; // 0 - don't generate, n - generate n grades of analogous colors with the step == Step
            public int GeneratePolyad; // 0 - don't generate, n - generate n-level polyad (5 will generate pentad)
        }


        [Tooltip("path to output scriptable object within Assets directory")]
        public string OutputDirectory;

        public string ColorSchemeScriptableObjectName;
        public string ColorSchemeName;
        public bool ShortNames;

        public List<ColorSource> InputSource;

        private void Reset()
        {
            Debug.Log("Setting default values");

            OutputDirectory = "Game/ColorScheme/Palettes";
            ColorSchemeScriptableObjectName = "Basic";
            ColorSchemeName = "Basic colors";

            InputSource = null;
        }

        [Button]
        public void AddRandomColorSource()
        {
            if (InputSource == null)
                InputSource = new List<ColorSource>();
            InputSource.Add(new ColorSource().Randomize());
        }

        [Button]
        public void PopulateHardcoded()
        {
            InputSource.Clear();

            // For each color: 
            // tint + shade + saturate


            #region 0.MISC

            InputSource.Add(new ColorSource
            {
                Name = "Black And White",
                ShortenedName = "BW",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#FFFFFF").ToColor(),
                Step = 0.2f,
                GenerateDarken = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Reserved 2",
                ShortenedName = "res2",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#67AFF6").ToColor(),
                Step = 0.2f,
                GenerateDarken = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Reserved 3",
                ShortenedName = "res3",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#67AFF6").ToColor(),
                Step = 0.2f,
                GenerateDarken = 6,
            });
            InputSource.Add(new ColorSource
            {
                Name = "Reserved 4",
                ShortenedName = "res4",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#67AFF6").ToColor(),
                Step = 0.2f,
                GenerateDarken = 6,
            });
            InputSource.Add(new ColorSource
            {
                Name = "Reserved 5",
                ShortenedName = "res5",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#67AFF6").ToColor(),
                Step = 0.2f,
                GenerateDarken = 6,
            });
            InputSource.Add(new ColorSource
            {
                Name = "Reserved 6",
                ShortenedName = "res6",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#67AFF6").ToColor(),
                Step = 0.2f,
                GenerateDarken = 6,
            });
            InputSource.Add(new ColorSource
            {
                Name = "Reserved 7",
                ShortenedName = "res7",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#67AFF6").ToColor(),
                Step = 0.2f,
                GenerateDarken = 6,
            });
            InputSource.Add(new ColorSource
            {
                Name = "Reserved 8",
                ShortenedName = "res8",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#67AFF6").ToColor(),
                Step = 0.2f,
                GenerateDarken = 6,
            });
            InputSource.Add(new ColorSource
            {
                Name = "Reserved 9",
                ShortenedName = "res9",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#67AFF6").ToColor(),
                Step = 0.2f,
                GenerateDarken = 6,
            });
            InputSource.Add(new ColorSource
            {
                Name = "Reserved 10",
                ShortenedName = "res10",
                Category = ColorScheme.MaterialCategory.Misc,
                Color = TinyColor.ParseFromHex("#67AFF6").ToColor(),
                Step = 0.2f,
                GenerateDarken = 6,
            });

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.Misc) == 10, "Misc category is 10");

            #endregion

            #region 1.Organic Materials

            InputSource.Add(new ColorSource
            {
                Name = "Blood",
                ShortenedName = "Blood",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#FF0000").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Wood",
                ShortenedName = "Wood",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#8B5A2B").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Fabric / Cloth",
                ShortenedName = "Fabric",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#F28E8E").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Leather",
                ShortenedName = "Leather",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#CFAE8B").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Bark",
                ShortenedName = "Bark",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#5C4033").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Bone",
                ShortenedName = "Bone",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#EDE6D6").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Paper",
                ShortenedName = "Paper",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#FFF8DC").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Rope / Twine",
                ShortenedName = "Rope",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#D2B48C").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Feathers",
                ShortenedName = "Feathers",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#DCDCF5").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Hide / Fur",
                ShortenedName = "HideFur",
                Category = ColorScheme.MaterialCategory.OrganicMaterials,
                Color = TinyColor.ParseFromHex("#A0522D").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.OrganicMaterials) == 10, "OrganicMaterials category is 10");

            #endregion

            #region 2.Fruits and Vegetables

            InputSource.Add(new ColorSource
            {
                Name = "Apple",
                ShortenedName = "Apple",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#FF0800").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Banana",
                ShortenedName = "Banana",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#FFE135").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Carrot",
                ShortenedName = "Carrot",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#FFA500").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Tomato",
                ShortenedName = "Tomato",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#FF6347").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Potato",
                ShortenedName = "Potato",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#D2B48C").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Lettuce",
                ShortenedName = "Lettuce",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#7CFC00").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Orange",
                ShortenedName = "Orange",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#FFA500").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Strawberry",
                ShortenedName = "Strawberry",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#FC5A8D").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Pumpkin",
                ShortenedName = "Pumpkin",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#FF7518").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });

            InputSource.Add(new ColorSource
            {
                Name = "Grapes",
                ShortenedName = "Grapes",
                Category = ColorScheme.MaterialCategory.FruitsAndVegetables,
                Color = TinyColor.ParseFromHex("#6F2DA8").ToColor(), // purple variant
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6,
            });
            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.FruitsAndVegetables) == 10, "FruitsAndVegies category is 10");

            #endregion

            #region 3.General Vegetation

            InputSource.Add(new ColorSource
            {
                Name = "Grass",
                ShortenedName = "Grass",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#7CFC00").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Bushes / Shrubs",
                ShortenedName = "Bushes",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#228B22").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Trees",
                ShortenedName = "Trees",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#006400").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Flowers",
                ShortenedName = "Flowers",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#FF69B4").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Vines / Creepers",
                ShortenedName = "Vines",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#3CB371").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Ferns",
                ShortenedName = "Ferns",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#4F7942").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Moss",
                ShortenedName = "Moss",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#8A9A5B").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Weeds / Wild Plants",
                ShortenedName = "Weeds",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#6B8E23").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Reeds / Tall Grass",
                ShortenedName = "Reeds",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#9ACD32").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Cacti / Succulents",
                ShortenedName = "Cacti",
                Category = ColorScheme.MaterialCategory.GeneralVegetation,
                Color = TinyColor.ParseFromHex("#568203").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });
            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.GeneralVegetation) == 10, "General vegetation category is 10");

            #endregion

            #region 4.Mineral and Building Materials

            InputSource.Add(new ColorSource
            {
                Name = "Stone",
                ShortenedName = "Stone",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#808080").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Brick",
                ShortenedName = "Brick",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#B22222").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Concrete",
                ShortenedName = "Concrete",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#A9A9A9").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Sand",
                ShortenedName = "Sand",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#C2B280").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Marble",
                ShortenedName = "Marble",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#E5E4E2").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Rock",
                ShortenedName = "Rock",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#708090").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Gravel",
                ShortenedName = "Gravel",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#9E9E9E").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Clay",
                ShortenedName = "Clay",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#B66A50").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Slate",
                ShortenedName = "Slate",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#2F4F4F").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Limestone",
                ShortenedName = "Limestone",
                Category = ColorScheme.MaterialCategory.MineralAndBuildingMaterials,
                Color = TinyColor.ParseFromHex("#D9D6CF").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });
            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.MineralAndBuildingMaterials) == 10, "Minerals and Building materials category is 10");

            #endregion

            #region 5.Metals

            InputSource.Add(new ColorSource
            {
                Name = "Iron",
                ShortenedName = "Iron",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#43464B").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Steel",
                ShortenedName = "Steel",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#B0C4DE").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Copper",
                ShortenedName = "Copper",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#B87333").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Bronze",
                ShortenedName = "Bronze",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#CD7F32").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Silver",
                ShortenedName = "Silver",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#C0C0C0").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Gold",
                ShortenedName = "Gold",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#FFD700").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Aluminum",
                ShortenedName = "Aluminum",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#DCDCDC").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Chrome",
                ShortenedName = "Chrome",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#E5E4E2").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Rusty Metal",
                ShortenedName = "Rusty",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#8B3E2F").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Titanium",
                ShortenedName = "Titanium",
                Category = ColorScheme.MaterialCategory.Metals,
                Color = TinyColor.ParseFromHex("#BFC1C2").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.Metals) == 10,
                "Metals category must contain exactly 10 color sources");

            #endregion

            #region 6.Transparent and Translucent Materials

            InputSource.Add(new ColorSource
            {
                Name = "Glass",
                ShortenedName = "Glass",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#A7C7E7").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Water",
                ShortenedName = "Water",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#1CA9C9").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Ice",
                ShortenedName = "Ice",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#AFDBF5").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Crystal",
                ShortenedName = "Crystal",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#B0E0E6").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Fog / Mist",
                ShortenedName = "Fog",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#D3D3D3").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Steam",
                ShortenedName = "Steam",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#C0C0C0").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Plasma / Energy Field",
                ShortenedName = "Plasma",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#00FFFF").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Gel / Slime",
                ShortenedName = "Slime",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#7FFFD4").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Resin / Amber",
                ShortenedName = "Resin",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#FFBF00").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Bubble / Foam",
                ShortenedName = "Bubble",
                Category = ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials,
                Color = TinyColor.ParseFromHex("#E0FFFF").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.TransparentAndTranslucentMaterials) == 10,
                "Transparent and Translucent Materials category must contain exactly 10 color sources");

            #endregion

            #region 7.Natural Textures and Ground Materials

            InputSource.Add(new ColorSource
            {
                Name = "Soil / Dirt",
                ShortenedName = "Soil",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#8B4513").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Grass",
                ShortenedName = "Grass",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#228B22").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Mud",
                ShortenedName = "Mud",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#704214").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Sand",
                ShortenedName = "Sand",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#C2B280").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Snow",
                ShortenedName = "Snow",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#FFFFFF").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Gravel",
                ShortenedName = "Gravel",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#A9A9A9").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Rocky Ground",
                ShortenedName = "Rock",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#808080").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Ash / Volcanic Soil",
                ShortenedName = "Ash",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#555555").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Leaves / Forest Floor",
                ShortenedName = "Leaves",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#556B2F").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Moss",
                ShortenedName = "Moss",
                Category = ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials,
                Color = TinyColor.ParseFromHex("#6B8E23").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.NaturalTexturesAndGroundMaterials) == 10,
                "Natural Textures and Ground Materials category must contain exactly 10 color sources");

            #endregion

            #region 8.Artificial and Modern Materials

            InputSource.Add(new ColorSource
            {
                Name = "Plastic",
                ShortenedName = "Plastic",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#E0E0E0").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Rubber",
                ShortenedName = "Rubber",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#2F4F4F").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Concrete",
                ShortenedName = "Concrete",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#A9A9A9").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Asphalt",
                ShortenedName = "Asphalt",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#3B3B3B").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Painted Metal",
                ShortenedName = "PaintMetal",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#B22222").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Fabric (Synthetic)",
                ShortenedName = "SynFabric",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#D3D3D3").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Plastic Panel / Polymer Surface",
                ShortenedName = "Polymer",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#CCCCCC").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Circuit / Electronics",
                ShortenedName = "Circuit",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#006400").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Neon Light",
                ShortenedName = "Neon",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#39FF14").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Holographic Material",
                ShortenedName = "Holo",
                Category = ColorScheme.MaterialCategory.ArtificialAndModernMaterials,
                Color = TinyColor.ParseFromHex("#DDA0DD").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.ArtificialAndModernMaterials) == 10,
                "Artificial and Modern Materials category must contain exactly 10 color sources");

            #endregion

            #region 9.Special Effects Materials

            InputSource.Add(new ColorSource
            {
                Name = "Fire",
                ShortenedName = "Fire",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#FF4500").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Lava",
                ShortenedName = "Lava",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#FF6347").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Magic Essence",
                ShortenedName = "Magic",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#8A2BE2").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Smoke",
                ShortenedName = "Smoke",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#696969").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Electricity",
                ShortenedName = "Electric",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#1E90FF").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Ice / Frost Effect",
                ShortenedName = "Frost",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#ADD8E6").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Acid / Corrosive Substance",
                ShortenedName = "Acid",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#ADFF2F").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Light / Glow Effect",
                ShortenedName = "Glow",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#FFFACD").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Energy / Plasma",
                ShortenedName = "Plasma",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#00FFFF").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Dust / Particles",
                ShortenedName = "Dust",
                Category = ColorScheme.MaterialCategory.SpecialEffectsMaterials,
                Color = TinyColor.ParseFromHex("#D2B48C").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.SpecialEffectsMaterials) == 10,
                "Special Effects Materials category must contain exactly 10 color sources");

            #endregion

            #region 10.Fabric and Soft Materials

            InputSource.Add(new ColorSource
            {
                Name = "Cotton",
                ShortenedName = "Cotton",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#FAF0E6").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Linen",
                ShortenedName = "Linen",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#EEE6CA").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Wool",
                ShortenedName = "Wool",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#C2B280").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Velvet",
                ShortenedName = "Velvet",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#800020").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Satin",
                ShortenedName = "Satin",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#FFF5EE").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Silk",
                ShortenedName = "Silk",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#F5F5DC").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Microfiber",
                ShortenedName = "Microfib",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#E8E8E8").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Fur / Faux Fur",
                ShortenedName = "Fur",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#D2B48C").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Velour",
                ShortenedName = "Velour",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#B76E79").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Tweed",
                ShortenedName = "Tweed",
                Category = ColorScheme.MaterialCategory.FabricAndSoftMaterials,
                Color = TinyColor.ParseFromHex("#8B7765").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.FabricAndSoftMaterials) == 10,
                "Fabric and Soft Materials category must contain exactly 10 color sources");

            #endregion


            #region 11.Sky and Celestial Materials

            InputSource.Add(new ColorSource
            {
                Name = "Clear Day Sky",
                ShortenedName = "SkyDay",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#87CEEB").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Cloudy Sky",
                ShortenedName = "SkyCloud",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#B0C4DE").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Cumulus Clouds",
                ShortenedName = "Cumulus",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#F5F5F5").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Stratus Clouds",
                ShortenedName = "Stratus",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#DCDCDC").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Cirrus Clouds",
                ShortenedName = "Cirrus",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#E0FFFF").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Sun",
                ShortenedName = "Sun",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#FFD700").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Moon",
                ShortenedName = "Moon",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#F0EAD6").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Stars",
                ShortenedName = "Stars",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#FFFFE0").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Night Sky",
                ShortenedName = "SkyNight",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#191970").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Sunset / Sunrise Sky",
                ShortenedName = "Sunset",
                Category = ColorScheme.MaterialCategory.SkyAndCelestialMaterials,
                Color = TinyColor.ParseFromHex("#FFB347").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.SkyAndCelestialMaterials) == 10,
                "Sky and Celestial Materials category must contain exactly 10 color sources");

            #endregion

            #region 12.Precious Metals and Gems

            InputSource.Add(new ColorSource
            {
                Name = "Gold",
                ShortenedName = "Gold",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#FFD700").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Silver",
                ShortenedName = "Silver",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#C0C0C0").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Copper",
                ShortenedName = "Copper",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#B87333").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Bronze",
                ShortenedName = "Bronze",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#CD7F32").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Platinum",
                ShortenedName = "Platinum",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#E5E4E2").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Diamond",
                ShortenedName = "Diamond",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#B9F2FF").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Ruby",
                ShortenedName = "Ruby",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#E0115F").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Sapphire",
                ShortenedName = "Sapphire",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#0F52BA").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Emerald",
                ShortenedName = "Emerald",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#50C878").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            InputSource.Add(new ColorSource
            {
                Name = "Amethyst",
                ShortenedName = "Amethyst",
                Category = ColorScheme.MaterialCategory.PreciousMetalsAndGems,
                Color = TinyColor.ParseFromHex("#9966CC").ToColor(),
                Step = 0.2f,
                GenerateTint = 6,
                GenerateShade = 6,
                GenerateSaturate = 6
            });

            Assert.IsTrue(InputSource.Count(x => x.Category == ColorScheme.MaterialCategory.PreciousMetalsAndGems) == 10,
                "Precious Metals and Gems category must contain exactly 10 color sources");

            #endregion
        }


        [Button]
        public void CreateColorScheme()
        {
            // Create an instance of the ScriptableObject
            string path = $"Assets/{OutputDirectory}/{ColorSchemeScriptableObjectName}.asset";

            // create or reuse existing
            var reusedAsset = true;
            ColorScheme colorScheme = UnityEditor.AssetDatabase.LoadAssetAtPath<ColorScheme>(path);
            if (colorScheme == null)
            {
                Debug.Log($"Creating new asset ColorScheme");
                colorScheme = ScriptableObject.CreateInstance<ColorScheme>();
                reusedAsset = false;
            }
            else
                Debug.Log($"Reusing existing asset {path}");


            colorScheme.Name = ColorSchemeName;
            colorScheme.Data = new List<ColorScheme.ColorItem>();


            foreach (var source in InputSource)
            {
                var rootName = source.Name;
                var shortName = source.ShortenedName;
                var baseColor = source.Color;
                var step = source.Step;
                var category = source.Category;
                var tinyColor = new TinyColor(baseColor);


                Debug.Log(JsonUtility.ToJson(tinyColor.GetColorInfo()));


                // BRIGHTEN
                if (source.GenerateBrighten > 0)
                {
                    var colorSchemeItem = new ColorScheme.ColorItem();
                    colorSchemeItem.Name = ShortNames ? $"{shortName}-brt" : $"{rootName}-brighten";
                    colorSchemeItem.Palette = new Color[source.GenerateBrighten];
                    colorSchemeItem.MaterialCategory = category;

                    for (int i = 0; i < source.GenerateBrighten; ++i)
                        colorSchemeItem.Palette[i] = tinyColor.Brighten(i * step).ToColor();

                    colorScheme.Data.Add(colorSchemeItem);
                }

                // LIGHTEN
                if (source.GenerateLighten > 0)
                {
                    var colorSchemeItem = new ColorScheme.ColorItem();
                    colorSchemeItem.Name = ShortNames ? $"{shortName}-lgt" : $"{rootName}-lighten";
                    colorSchemeItem.Palette = new Color[source.GenerateLighten];
                    colorSchemeItem.MaterialCategory = category;

                    for (int i = 0; i < source.GenerateLighten; ++i)
                        colorSchemeItem.Palette[i] = tinyColor.Lighten(i * step).ToColor();

                    colorScheme.Data.Add(colorSchemeItem);
                }

                // DARKEN
                if (source.GenerateDarken > 0)
                {
                    var colorSchemeItem = new ColorScheme.ColorItem();
                    colorSchemeItem.Name = ShortNames ? $"{shortName}-drk" : $"{rootName}-darken";
                    colorSchemeItem.Palette = new Color[source.GenerateDarken];
                    colorSchemeItem.MaterialCategory = category;

                    for (int i = 0; i < source.GenerateDarken; ++i)
                        colorSchemeItem.Palette[i] = tinyColor.Darken(i * step).ToColor();

                    colorScheme.Data.Add(colorSchemeItem);
                }

                // TINT
                if (source.GenerateTint > 0)
                {
                    var colorSchemeItem = new ColorScheme.ColorItem();
                    colorSchemeItem.Name = ShortNames ? $"{shortName}-tnt" : $"{rootName}-tinted";
                    colorSchemeItem.Palette = new Color[source.GenerateTint];
                    colorSchemeItem.MaterialCategory = category;

                    for (int i = 0; i < source.GenerateTint; ++i)
                        colorSchemeItem.Palette[i] = tinyColor.Tint(i * step).ToColor();

                    colorScheme.Data.Add(colorSchemeItem);
                }

                // SHADE
                if (source.GenerateShade > 0)
                {
                    var colorSchemeItem = new ColorScheme.ColorItem();
                    colorSchemeItem.Name = ShortNames ? $"{shortName}-shd" : $"{rootName}-shaded";
                    colorSchemeItem.Palette = new Color[source.GenerateShade];
                    colorSchemeItem.MaterialCategory = category;

                    for (int i = 0; i < source.GenerateShade; ++i)
                        colorSchemeItem.Palette[i] = tinyColor.Shade(i * step).ToColor();

                    colorScheme.Data.Add(colorSchemeItem);
                }

                // SATURATE
                if (source.GenerateSaturate > 0)
                {
                    var colorSchemeItem = new ColorScheme.ColorItem();
                    colorSchemeItem.Name = ShortNames ? $"{shortName}-str" : $"{rootName}-saturated";
                    colorSchemeItem.Palette = new Color[source.GenerateSaturate];
                    colorSchemeItem.MaterialCategory = category;

                    for (int i = 0; i < source.GenerateSaturate; ++i)
                        colorSchemeItem.Palette[i] = tinyColor.Saturate(i * step).ToColor();

                    colorScheme.Data.Add(colorSchemeItem);
                }

                // DESATURATE
                if (source.GenerateDesaturate > 0)
                {
                    var colorSchemeItem = new ColorScheme.ColorItem();
                    colorSchemeItem.Name = ShortNames ? $"{shortName}-dst" : $"{rootName}-desaturated";
                    colorSchemeItem.Palette = new Color[source.GenerateDesaturate];
                    colorSchemeItem.MaterialCategory = category;

                    for (int i = 0; i < source.GenerateDesaturate; ++i)
                        colorSchemeItem.Palette[i] = tinyColor.Desaturate(i * step).ToColor();

                    colorScheme.Data.Add(colorSchemeItem);
                }

                // MONOCHROMATIC
                if (source.GenerateMonochromatic > 0)
                {
                    var colorSchemeItem = new ColorScheme.ColorItem();
                    colorSchemeItem.Name = ShortNames ? $"{shortName}-mnc" : $"{rootName}-monochromatic";
                    colorSchemeItem.Palette = new Color[source.GenerateMonochromatic];
                    colorSchemeItem.MaterialCategory = category;

                    var mData = tinyColor.Monochromatic(source.GenerateMonochromatic);
                    for (int i = 0; i < source.GenerateMonochromatic; ++i)
                        colorSchemeItem.Palette[i] = mData[i].ToColor();

                    colorScheme.Data.Add(colorSchemeItem);
                }

                // ANALOGOUS
                if (source.GenerateAnalogous > 0)
                {
                    var colorSchemeItem = new ColorScheme.ColorItem();
                    colorSchemeItem.Name = ShortNames ? $"{shortName}-ang" : $"{rootName}-analogous";
                    colorSchemeItem.Palette = new Color[source.GenerateAnalogous];
                    colorSchemeItem.MaterialCategory = category;

                    var aData = tinyColor.Analogous(source.GenerateAnalogous);
                    for (int i = 0; i < source.GenerateAnalogous; ++i)
                        colorSchemeItem.Palette[i] = aData[i].ToColor();

                    colorScheme.Data.Add(colorSchemeItem);
                }

                // POLYAD
                if (source.GeneratePolyad > 0)
                {
                    var colorSchemeItem = new ColorScheme.ColorItem();
                    colorSchemeItem.Name = ShortNames ? $"{shortName}-{source.GeneratePolyad}pd" : $"{rootName}-{source.GeneratePolyad}polyad";
                    colorSchemeItem.Palette = new Color[source.GeneratePolyad];
                    colorSchemeItem.MaterialCategory = category;

                    var pData = tinyColor.Polyad(source.GeneratePolyad);
                    for (int i = 0; i < source.GeneratePolyad; ++i)
                        colorSchemeItem.Palette[i] = pData[i].ToColor();

                    colorScheme.Data.Add(colorSchemeItem);
                }
            }

            // Save scriptable object
            if (!reusedAsset)
                UnityEditor.AssetDatabase.CreateAsset(colorScheme, path);
            UnityEditor.AssetDatabase.SaveAssets();
            UnityEditor.AssetDatabase.Refresh();

            Debug.Log($"ColorScheme saved at: {path}");
        }
    }
#endif
}