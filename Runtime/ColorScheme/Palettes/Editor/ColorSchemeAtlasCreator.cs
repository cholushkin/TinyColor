using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NaughtyAttributes;
using TinyColorLib;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions;
using Color = UnityEngine.Color;

namespace GameLib.ColorScheme
{
#if UNITY_EDITOR
    [CreateAssetMenu(fileName = "ColorSchemeAtlasCreator", menuName = "GameLib/Color/ColorSchemeAtlasCreator", order = 1)]
    public class ColorSchemeAtlasCreator : ScriptableObject
    {
        public enum AtlasLayout
        {
            OneItemPerRow,
            OneItemPerRowWithNames,
            Columns,
            ColumnsWithText,
        }

        [Serializable]
        public class AtlasGenerationParameters
        {
            public ColorScheme ColorScheme;
            public bool AssignAtlasToColorScheme;
            public Color Background;

            [Tooltip("Directory where to generate the output atlas texture (relative to Assets). If empty, uses ColorScheme's folder.")]
            public string OutputDirectory;

            public Vector2Int TextureAspects;
            public Vector2Int CellSize;
            public Vector2Int CellMargin;
            public AtlasLayout Layout;
            public string TextureNameSuffix;
        }

        public AtlasGenerationParameters AtlasForUnity;
        public AtlasGenerationParameters AtlasForBlender;

        [Button]
        public void GenerateAtlas()
        {
            AssertAtlasParameters(AtlasForUnity);
            GenerateAtlasImpl(AtlasForUnity);
        }

        [Button]
        public void GenerateAtlasBlender()
        {
            AssertAtlasParameters(AtlasForBlender);
            GenerateAtlasImpl(AtlasForBlender);
        }


        private void AssertAtlasParameters(AtlasGenerationParameters parameters)
        {
            Assert.IsNotNull(parameters.ColorScheme, "ColorScheme cannot be null");
            Assert.IsTrue(parameters.TextureAspects.x > 0 && parameters.TextureAspects.y > 0, "TextureAspects must be > 0");
            Assert.IsTrue(parameters.CellSize.x > 0 && parameters.CellSize.y > 0, "CellSize must be > 0");
        }

        private void GenerateAtlasImpl(AtlasGenerationParameters parameters)
        {
            Texture2D texture = new Texture2D(parameters.TextureAspects.x, parameters.TextureAspects.y);
            texture.wrapMode = TextureWrapMode.Clamp;
            texture.filterMode = FilterMode.Point;

            ClearTexture(texture, parameters.Background);

            string colorSchemePath = AssetDatabase.GetAssetPath(parameters.ColorScheme);
            string directory = Path.GetDirectoryName(colorSchemePath);

            string textureName = parameters.ColorScheme.name;
            if (!string.IsNullOrEmpty(parameters.TextureNameSuffix))
                textureName += "_" + parameters.TextureNameSuffix;

            string path = Path.Combine(directory, textureName + ".png");
            if (!string.IsNullOrEmpty(parameters.OutputDirectory))
                path = $"Assets/{parameters.OutputDirectory}/{textureName}.png";

            if (texture.height % parameters.CellSize.y != 0f)
                Debug.LogWarning("Texture height is not a multiple of cell height");

            int row = texture.height / parameters.CellSize.y - 1;

            if (parameters.Layout == AtlasLayout.OneItemPerRow || parameters.Layout == AtlasLayout.OneItemPerRowWithNames)
            {
                foreach (var item in parameters.ColorScheme.Data)
                {
                    if (row < 0)
                    {
                        Debug.LogWarning($"Drawing out of bounds, negative row: {row}");
                        continue;
                    }

                    for (int i = 0; i < item.Palette.Length; ++i)
                        DrawCell(texture, i, row, item.Palette[i], parameters.Background, parameters.CellSize, parameters.CellMargin);

                    if (parameters.Layout == AtlasLayout.OneItemPerRowWithNames)
                        RenderTextToTexture(texture, item.Palette.Length * parameters.CellSize.x, row * parameters.CellSize.y, item.Name, null);

                    row--;
                }
            }
            else
            {
                int xOffset = 0;
                int maxOnCurrentRow = 0;

                foreach (var item in parameters.ColorScheme.Data)
                {
                    if (row < 0)
                    {
                        Debug.LogWarning($"Drawing out of bounds, negative row: {row}");
                        continue;
                    }

                    for (int i = 0; i < item.Palette.Length; ++i)
                        DrawCell(texture, xOffset + i, row, item.Palette[i], parameters.Background, parameters.CellSize, parameters.CellMargin);

                    if (item.Palette.Length > maxOnCurrentRow)
                        maxOnCurrentRow = item.Palette.Length;

                    if (parameters.Layout == AtlasLayout.ColumnsWithText)
                        RenderTextToTexture(texture, xOffset * parameters.CellSize.x, row * parameters.CellSize.y, item.Name, null);

                    row--;
                    if (row < 0)
                    {
                        row = parameters.TextureAspects.y / parameters.CellSize.y - 1;
                        xOffset += maxOnCurrentRow + 1;
                        maxOnCurrentRow = 0;
                    }
                }
            }

            byte[] bytes = texture.EncodeToPNG();
            File.WriteAllBytes(path, bytes);

            // Force Unity to import the new PNG
            if (parameters.AssignAtlasToColorScheme)
            {
                AssetDatabase.ImportAsset(path, ImportAssetOptions.ForceUpdate);

                // Assign the loaded texture to the color scheme
                parameters.ColorScheme.Atlas = AssetDatabase.LoadAssetAtPath<Texture2D>(path);
                EditorUtility.SetDirty(parameters.ColorScheme);
            }


            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Debug.Log($"Texture generated at: {path}");
            Debug.Log($"Texture assigned to {parameters.ColorScheme.name}.Atlas");


            SetTextureImportSettings(path);
        }

        private void SetTextureImportSettings(string path)
        {
            TextureImporter textureImporter = AssetImporter.GetAtPath(path) as TextureImporter;
            if (textureImporter != null)
            {
                textureImporter.textureType = TextureImporterType.Sprite;
                textureImporter.spriteImportMode = SpriteImportMode.Single;
                AssetDatabase.ImportAsset(path);
            }
        }

        private bool DrawCell(Texture2D texture, int cellX, int cellY, Color color, Color bg, Vector2Int cellSize, Vector2Int cellMargin)
        {
            int startX = cellX * cellSize.x;
            int startY = cellY * cellSize.y;

            for (int x = startX; x < Mathf.Min(startX + cellSize.x, texture.width); x++)
            for (int y = startY; y < Mathf.Min(startY + cellSize.y, texture.height); y++)
            {
                if (x >= startX + cellSize.x - cellMargin.x || y < startY + cellMargin.y)
                    texture.SetPixel(x, y, bg);
                else
                    texture.SetPixel(x, y, color);
            }

            return !(startX < 0 || startY < 0 || startX + cellSize.x > texture.width || startY + cellSize.y > texture.height);
        }

        private void ClearTexture(Texture2D texture, Color clearColor)
        {
            Color[] clearPixels = new Color[texture.width * texture.height];
            for (int i = 0; i < clearPixels.Length; i++)
                clearPixels[i] = clearColor;

            texture.SetPixels(clearPixels);
        }

        Texture2D RenderTextToTexture(Texture2D texture, int x, int y, string text, Color? textColor)
        {
            const int charHeight = 5; // Height based on the pixel size and number of rows in the font
            List<TinyColor> textColors = new List<TinyColor> { new TinyColor(Color.white), new TinyColor(Color.black) };

            text = text.ToUpper();
            int caret = 0;
            int spacing = 1; // Additional space between characters

            for (int i = 0; i < text.Length; i++)
            {
                int[,] pixels;
                if (MiniPixelFontDictionary.Chars.TryGetValue(text[i], out pixels))
                {
                    var curCharColor = textColor;
                    if (!textColor.HasValue) // autocolor
                    {
                        var bgColors = Enumerable.Range(0, pixels.GetLength(0))
                            .SelectMany(cy => Enumerable.Range(0, pixels.GetLength(1))
                                .Select(cx => texture.GetPixel(caret + x + cx, y + charHeight - cy)))
                            .ToList();

                        Color dominantColor = bgColors
                            .GroupBy(color => color)
                            .OrderByDescending(group => group.Count())
                            .First()
                            .Key;

                        curCharColor = ReadabilityHelpers.MostReadable(new TinyColor(dominantColor), textColors).ToColor();
                    }

                    for (int cy = 0; cy < pixels.GetLength(0); ++cy)
                    {
                        for (int cx = 0; cx < pixels.GetLength(1); ++cx)
                        {
                            int pixel = pixels[cy, cx];
                            var bgColor = texture.GetPixel(caret + x + cx, y + charHeight - cy);
                            Color color = (pixel == 1) ? curCharColor.Value : bgColor;
                            texture.SetPixel(caret + x + cx, y + charHeight - cy, color);
                        }
                    }

                    int charWidth = pixels.GetLength(1);

                    // Add a column of empty pixels
                    for (int extraY = 0; extraY < charHeight; ++extraY)
                    {
                        var bgColor = texture.GetPixel(caret + charWidth + x, y + charHeight - extraY);
                        texture.SetPixel(caret + x + charWidth, y + charHeight - extraY, bgColor);
                    }

                    caret += charWidth + spacing;
                }
            }

            return texture;
        }
    }
#endif
}