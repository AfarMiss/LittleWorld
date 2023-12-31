﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class ApplyCharacterCustomisation : MonoBehaviour
{
    [Header("Base Textures")]
    [SerializeField] private Texture2D maleFarmerBaseTexture = null;
    [SerializeField] private Texture2D femaleFarmerBaseTexture = null;
    [SerializeField] private Texture2D shirtsBaseTexture = null;
    [SerializeField] private Texture2D hatBaseTexture = null;
    [SerializeField]
    [Range(0, 1)]
    private int hairStyleNo;

    /// <summary>
    /// 确定性别后的玩家Texture
    /// </summary>
    private Texture2D farmerBaseTexture;
    [SerializeField]
    private Texture2D farmerHairTexture;

    [Header("OutputBase Texture To Be Used For Animation")]
    [SerializeField]
    private Texture2D farmBaseCustomised = null;
    [SerializeField]
    private Texture2D farmHairCustomised = null;
    [SerializeField]
    private Texture2D farmHatCustomised = null;
    [SerializeField]
    private Color trousersColor;
    [SerializeField]
    private Color hairColor;
    private Texture2D farmerBaseShirtsUpdated;
    private Texture2D selectedShirt;

    [Header("Select Shirt Style")]
    [Range(0f, 1f)]
    [SerializeField] private int inputShirtStyleNo = 0;

    [Header("Select Hat Style")]
    [Range(0f, 1f)]
    [SerializeField] private int inputHatStyleNo = 0;

    [Header("Select Sex:0-Male,1-Female")]
    [Range(0f, 1f)]
    [SerializeField] private int inputSex = 0;

    private Facing[,] bodyFacingArray;
    private Vector2Int[,] bodyShirtOffsetArray;

    private int bodyRows = 21;
    private int bodyColumns = 6;

    private int farmerSpriteWidth = 16;
    private int farmerSpriteHight = 32;

    private int shirtTextureWidth = 9;
    private int shirtTextureHeight = 36;
    private int shirtSpriteWidth = 9;
    private int shirtSpriteHeight = 9;
    private int shirtStylesInSpriteWidth = 16;

    private List<ColorSwap> colorSwapList;

    private void Awake()
    {

        ProcessCustomisation();
    }

    private void ProcessCustomisation()
    {
        ProcessGender();
        ProcessShirt();
        ProcessArms();
        ProcessHairStyle();
        ProcessHatStyle();
        MergeCustomisations();
    }

    private void ProcessHatStyle()
    {
        int x = inputHatStyleNo * 20;
        int height = 20 * 4;
        Color[] hats = hatBaseTexture.GetPixels(x, 0, 20, height);
        farmHatCustomised.SetPixels(0, 0, 20, height, hats);
        farmHatCustomised.Apply();
    }

    private void ProcessHairStyle()
    {
        int x = hairStyleNo * 16;
        int height = farmerSpriteHight * 3;
        Color[] hairs = farmerHairTexture.GetPixels(x, 0, 16, height);
        for (int i = 0; i < hairs.Length; i++)
        {
            hairs[i] *= hairColor;
        }
        farmHairCustomised.SetPixels(0, 0, 16, height, hairs);
        farmHairCustomised.Apply();
    }

    private void MergeCustomisations()
    {
        Color[] farmerShirtPixels = farmerBaseShirtsUpdated.GetPixels(0, 0, bodyColumns * farmerSpriteWidth, farmerBaseTexture.height);
        Color[] farmerTrouserPixelsSelection = farmerBaseTexture.GetPixels(farmerSpriteWidth * 18, 0, bodyColumns * farmerSpriteWidth, farmerBaseTexture.height);
        for (int i = 0; i < farmerTrouserPixelsSelection.Length; i++)
        {
            farmerTrouserPixelsSelection[i] *= trousersColor;
        }

        Color[] farmerBodyPixels = farmBaseCustomised.GetPixels(0, 0, bodyColumns * farmerSpriteWidth, farmerBaseTexture.height);

        MergeColourArray(farmerBodyPixels, farmerTrouserPixelsSelection);
        MergeColourArray(farmerBodyPixels, farmerShirtPixels);

        farmBaseCustomised.SetPixels(0, 0, bodyColumns * farmerSpriteWidth, farmerBaseTexture.height, farmerBodyPixels);

        farmBaseCustomised.Apply();

    }

    private void MergeColourArray(Color[] baseArray, Color[] mergeArray)
    {
        for (int i = 0; i < baseArray.Length; i++)
        {
            if (mergeArray[i].a > 0)
            {
                if (mergeArray[i].a >= 1)
                {
                    baseArray[i] = mergeArray[i];
                }
                else
                {
                    float alpha = mergeArray[i].a;

                    baseArray[i].r += (mergeArray[i].r - baseArray[i].r) * alpha;
                    baseArray[i].g += (mergeArray[i].g - baseArray[i].g) * alpha;
                    baseArray[i].b += (mergeArray[i].b - baseArray[i].b) * alpha;
                    baseArray[i].a += alpha;
                }
            }
        }
    }

    private void ProcessArms()
    {
        Color[] farmerPixelsToRecolour = farmerBaseTexture.GetPixels(0, 0, 288, farmerBaseTexture.height);

        PopulateArmColorSwapList();

        ChangePixelColors(farmerPixelsToRecolour, colorSwapList);

        farmBaseCustomised.SetPixels(0, 0, 18 * farmerSpriteWidth, farmerBaseTexture.height, farmerPixelsToRecolour);

        farmBaseCustomised.Apply();
    }

    private void ChangePixelColors(Color[] farmerPixelsToRecolour, List<ColorSwap> colorSwapList)
    {
        for (int i = 0; i < farmerPixelsToRecolour.Length; i++)
        {
            if (colorSwapList.Count > 0)
            {
                for (int j = 0; j < colorSwapList.Count; j++)
                {
                    if (isSameColor(farmerPixelsToRecolour[i], colorSwapList[j].fromColor))
                    {
                        farmerPixelsToRecolour[i] = colorSwapList[j].toColor;
                    }
                }
            }
        }
    }

    private bool isSameColor(Color color1, Color color2)
    {
        //比较浮点数会因为有微小误差导致并不完全相等
        //return ((color1.r == color2.r && color1.g == color2.g && color1.b == color2.b && color1.a == color2.a));

        return (UnityEngine.ColorUtility.ToHtmlStringRGBA(color1)
            == UnityEngine.ColorUtility.ToHtmlStringRGBA(color2));
    }

    private void PopulateArmColorSwapList()
    {
        colorSwapList = new List<ColorSwap>();
        colorSwapList.Clear();

        //使用红色衣服颜色间接获取手臂原色
        var originalShirt = new Texture2D(shirtTextureWidth, shirtTextureHeight);
        originalShirt.filterMode = FilterMode.Point;
        Color[] shirtPixels = shirtsBaseTexture.GetPixels(0, 0, shirtTextureWidth, shirtTextureHeight);
        originalShirt.SetPixels(shirtPixels);
        originalShirt.Apply();

        var armOriginalColor1 = originalShirt.GetPixel(0, 7);
        var armOriginalColor2 = originalShirt.GetPixel(0, 6);
        var armOriginalColor3 = originalShirt.GetPixel(0, 5);

        colorSwapList.Add(new ColorSwap(armOriginalColor1, selectedShirt.GetPixel(0, 7)));
        colorSwapList.Add(new ColorSwap(armOriginalColor2, selectedShirt.GetPixel(0, 6)));
        colorSwapList.Add(new ColorSwap(armOriginalColor3, selectedShirt.GetPixel(0, 5)));
    }

    private void ProcessGender()
    {
        if (inputSex == 0)
        {
            farmerBaseTexture = maleFarmerBaseTexture;
        }
        else
        {
            farmerBaseTexture = femaleFarmerBaseTexture;
        }

        Color[] farmerBasePixels = farmerBaseTexture.GetPixels();

        farmBaseCustomised.SetPixels(farmerBasePixels);
        farmBaseCustomised.Apply();
    }

    private void ProcessShirt()
    {
        PopulateBodyFacingArray();
        PopulateBodyShirtOffsetArray();
        AddShirtToTexture(inputShirtStyleNo);
        ApplyShirtTextureToBase();
    }

    private void ApplyShirtTextureToBase()
    {
        farmerBaseShirtsUpdated = new Texture2D(farmerBaseTexture.width, farmerBaseTexture.height);
        farmerBaseShirtsUpdated.filterMode = FilterMode.Point;

        //清理先前Texture内容
        SetTextureToTransparent(farmerBaseShirtsUpdated);

        Color[] frontShirtPixels;
        Color[] backShirtPixels;
        Color[] rightShirtPixels;

        frontShirtPixels = selectedShirt.GetPixels(0, shirtSpriteHeight * 3, shirtSpriteWidth, shirtSpriteHeight);
        backShirtPixels = selectedShirt.GetPixels(0, shirtSpriteHeight * 0, shirtSpriteWidth, shirtSpriteHeight);
        rightShirtPixels = selectedShirt.GetPixels(0, shirtSpriteHeight * 2, shirtSpriteWidth, shirtSpriteHeight);

        for (int x = 0; x < bodyColumns; x++)
        {
            for (int y = 0; y < bodyRows; y++)
            {
                int pixelX = x * farmerSpriteWidth;
                int pixelY = y * farmerSpriteHight;

                if (bodyShirtOffsetArray[x, y] != null)
                {
                    if (bodyShirtOffsetArray[x, y].x == 99 && bodyShirtOffsetArray[x, y].y == 99)
                    {
                        continue;
                    }

                    pixelX += bodyShirtOffsetArray[x, y].x;
                    pixelY += bodyShirtOffsetArray[x, y].y;
                }

                switch (bodyFacingArray[x, y])
                {
                    case Facing.none:
                        break;
                    case Facing.front:
                        farmerBaseShirtsUpdated.SetPixels(pixelX, pixelY, shirtSpriteWidth, shirtSpriteHeight, frontShirtPixels);
                        break;
                    case Facing.back:
                        farmerBaseShirtsUpdated.SetPixels(pixelX, pixelY, shirtSpriteWidth, shirtSpriteHeight, backShirtPixels);
                        break;
                    case Facing.right:
                        farmerBaseShirtsUpdated.SetPixels(pixelX, pixelY, shirtSpriteWidth, shirtSpriteHeight, rightShirtPixels);
                        break;
                    default:
                        break;
                }
            }
        }

        farmerBaseShirtsUpdated.Apply();
    }

    private void SetTextureToTransparent(Texture2D farmerBaseShirtsUpdated)
    {
        Color[] fill = new Color[farmerBaseShirtsUpdated.height * farmerBaseShirtsUpdated.width];
        for (int i = 0; i < fill.Length; i++)
        {
            fill[i] = Color.clear;
        }
        farmerBaseShirtsUpdated.SetPixels(fill);
    }

    private void AddShirtToTexture(int inputShirtStyleNo)
    {
        selectedShirt = new Texture2D(shirtTextureWidth, shirtTextureHeight);
        selectedShirt.filterMode = FilterMode.Point;

        int y = 0;
        int x = inputShirtStyleNo * shirtSpriteWidth;

        Color[] shirtPixels = shirtsBaseTexture.GetPixels(x, y, shirtTextureWidth, shirtTextureHeight);

        selectedShirt.SetPixels(shirtPixels);
        selectedShirt.Apply();
    }

    private void PopulateBodyShirtOffsetArray()
    {
        bodyShirtOffsetArray = new Vector2Int[bodyColumns, bodyRows];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                bodyShirtOffsetArray[j, i] = new Vector2Int(99, 99);
            }
        }

        bodyShirtOffsetArray[0, 10] = new Vector2Int(4, 11);
        bodyShirtOffsetArray[1, 10] = new Vector2Int(4, 10);
        bodyShirtOffsetArray[2, 10] = new Vector2Int(4, 11);
        bodyShirtOffsetArray[3, 10] = new Vector2Int(4, 12);
        bodyShirtOffsetArray[4, 10] = new Vector2Int(4, 11);
        bodyShirtOffsetArray[5, 10] = new Vector2Int(4, 10);

        bodyShirtOffsetArray[0, 11] = new Vector2Int(4, 11);
        bodyShirtOffsetArray[1, 11] = new Vector2Int(4, 12);
        bodyShirtOffsetArray[2, 11] = new Vector2Int(4, 11);
        bodyShirtOffsetArray[3, 11] = new Vector2Int(4, 10);
        bodyShirtOffsetArray[4, 11] = new Vector2Int(4, 11);
        bodyShirtOffsetArray[5, 11] = new Vector2Int(4, 12);

        bodyShirtOffsetArray[0, 12] = new Vector2Int(3, 9);
        bodyShirtOffsetArray[1, 12] = new Vector2Int(3, 9);
        bodyShirtOffsetArray[2, 12] = new Vector2Int(4, 10);
        bodyShirtOffsetArray[3, 12] = new Vector2Int(4, 9);
        bodyShirtOffsetArray[4, 12] = new Vector2Int(4, 9);
        bodyShirtOffsetArray[5, 12] = new Vector2Int(4, 9);

        bodyShirtOffsetArray[0, 13] = new Vector2Int(4, 10);
        bodyShirtOffsetArray[1, 13] = new Vector2Int(4, 9);
        bodyShirtOffsetArray[2, 13] = new Vector2Int(5, 9);
        bodyShirtOffsetArray[3, 13] = new Vector2Int(5, 9);
        bodyShirtOffsetArray[4, 13] = new Vector2Int(4, 10);
        bodyShirtOffsetArray[5, 13] = new Vector2Int(4, 9);

        bodyShirtOffsetArray[0, 14] = new Vector2Int(4, 9);
        bodyShirtOffsetArray[1, 14] = new Vector2Int(4, 12);
        bodyShirtOffsetArray[2, 14] = new Vector2Int(4, 7);
        bodyShirtOffsetArray[3, 14] = new Vector2Int(4, 5);
        bodyShirtOffsetArray[4, 14] = new Vector2Int(4, 9);
        bodyShirtOffsetArray[5, 14] = new Vector2Int(4, 12);

        bodyShirtOffsetArray[0, 15] = new Vector2Int(4, 8);
        bodyShirtOffsetArray[1, 15] = new Vector2Int(4, 5);
        bodyShirtOffsetArray[2, 15] = new Vector2Int(4, 9);
        bodyShirtOffsetArray[3, 15] = new Vector2Int(4, 12);
        bodyShirtOffsetArray[4, 15] = new Vector2Int(4, 8);
        bodyShirtOffsetArray[5, 15] = new Vector2Int(4, 5);

        bodyShirtOffsetArray[0, 16] = new Vector2Int(4, 9);
        bodyShirtOffsetArray[1, 16] = new Vector2Int(4, 10);
        bodyShirtOffsetArray[2, 16] = new Vector2Int(4, 7);
        bodyShirtOffsetArray[3, 16] = new Vector2Int(4, 8);
        bodyShirtOffsetArray[4, 16] = new Vector2Int(4, 9);
        bodyShirtOffsetArray[5, 16] = new Vector2Int(4, 10);

        bodyShirtOffsetArray[0, 17] = new Vector2Int(4, 7);
        bodyShirtOffsetArray[1, 17] = new Vector2Int(4, 8);
        bodyShirtOffsetArray[2, 17] = new Vector2Int(4, 9);
        bodyShirtOffsetArray[3, 17] = new Vector2Int(4, 10);
        bodyShirtOffsetArray[4, 17] = new Vector2Int(4, 7);
        bodyShirtOffsetArray[5, 17] = new Vector2Int(4, 8);

        bodyShirtOffsetArray[0, 18] = new Vector2Int(4, 10);
        bodyShirtOffsetArray[1, 18] = new Vector2Int(4, 9);
        bodyShirtOffsetArray[2, 18] = new Vector2Int(4, 9);
        bodyShirtOffsetArray[3, 18] = new Vector2Int(4, 10);
        bodyShirtOffsetArray[4, 18] = new Vector2Int(4, 9);
        bodyShirtOffsetArray[5, 18] = new Vector2Int(4, 9);

        bodyShirtOffsetArray[0, 19] = new Vector2Int(4, 10);
        bodyShirtOffsetArray[1, 19] = new Vector2Int(4, 9);
        bodyShirtOffsetArray[2, 19] = new Vector2Int(4, 9);
        bodyShirtOffsetArray[3, 19] = new Vector2Int(4, 10);
        bodyShirtOffsetArray[4, 19] = new Vector2Int(4, 9);
        bodyShirtOffsetArray[5, 19] = new Vector2Int(4, 9);

        bodyShirtOffsetArray[0, 20] = new Vector2Int(4, 10);
        bodyShirtOffsetArray[1, 20] = new Vector2Int(4, 9);
        bodyShirtOffsetArray[2, 20] = new Vector2Int(4, 9);
        bodyShirtOffsetArray[3, 20] = new Vector2Int(4, 10);
        bodyShirtOffsetArray[4, 20] = new Vector2Int(4, 9);
        bodyShirtOffsetArray[5, 20] = new Vector2Int(4, 9);

    }

    private void PopulateBodyFacingArray()
    {
        bodyFacingArray = new Facing[bodyColumns, bodyRows];
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                bodyFacingArray[j, i] = Facing.none;
            }
        }

        bodyFacingArray[0, 10] = Facing.back;
        bodyFacingArray[1, 10] = Facing.back;
        bodyFacingArray[2, 10] = Facing.right;
        bodyFacingArray[3, 10] = Facing.right;
        bodyFacingArray[4, 10] = Facing.right;
        bodyFacingArray[5, 10] = Facing.right;

        bodyFacingArray[0, 11] = Facing.front;
        bodyFacingArray[1, 11] = Facing.front;
        bodyFacingArray[2, 11] = Facing.front;
        bodyFacingArray[3, 11] = Facing.front;
        bodyFacingArray[4, 11] = Facing.back;
        bodyFacingArray[5, 11] = Facing.back;

        bodyFacingArray[0, 12] = Facing.back;
        bodyFacingArray[1, 12] = Facing.back;
        bodyFacingArray[2, 12] = Facing.right;
        bodyFacingArray[3, 12] = Facing.right;
        bodyFacingArray[4, 12] = Facing.right;
        bodyFacingArray[5, 12] = Facing.right;

        bodyFacingArray[0, 13] = Facing.front;
        bodyFacingArray[1, 13] = Facing.front;
        bodyFacingArray[2, 13] = Facing.front;
        bodyFacingArray[3, 13] = Facing.front;
        bodyFacingArray[4, 13] = Facing.back;
        bodyFacingArray[5, 13] = Facing.back;

        bodyFacingArray[0, 14] = Facing.back;
        bodyFacingArray[1, 14] = Facing.back;
        bodyFacingArray[2, 14] = Facing.right;
        bodyFacingArray[3, 14] = Facing.right;
        bodyFacingArray[4, 14] = Facing.right;
        bodyFacingArray[5, 14] = Facing.right;

        bodyFacingArray[0, 15] = Facing.front;
        bodyFacingArray[1, 15] = Facing.front;
        bodyFacingArray[2, 15] = Facing.front;
        bodyFacingArray[3, 15] = Facing.front;
        bodyFacingArray[4, 15] = Facing.back;
        bodyFacingArray[5, 15] = Facing.back;

        bodyFacingArray[0, 16] = Facing.back;
        bodyFacingArray[1, 16] = Facing.back;
        bodyFacingArray[2, 16] = Facing.right;
        bodyFacingArray[3, 16] = Facing.right;
        bodyFacingArray[4, 16] = Facing.right;
        bodyFacingArray[5, 16] = Facing.right;

        bodyFacingArray[0, 17] = Facing.front;
        bodyFacingArray[1, 17] = Facing.front;
        bodyFacingArray[2, 17] = Facing.front;
        bodyFacingArray[3, 17] = Facing.front;
        bodyFacingArray[4, 17] = Facing.back;
        bodyFacingArray[5, 17] = Facing.back;

        bodyFacingArray[0, 18] = Facing.back;
        bodyFacingArray[1, 18] = Facing.back;
        bodyFacingArray[2, 18] = Facing.back;
        bodyFacingArray[3, 18] = Facing.right;
        bodyFacingArray[4, 18] = Facing.right;
        bodyFacingArray[5, 18] = Facing.right;

        bodyFacingArray[0, 19] = Facing.right;
        bodyFacingArray[1, 19] = Facing.right;
        bodyFacingArray[2, 19] = Facing.right;
        bodyFacingArray[3, 19] = Facing.front;
        bodyFacingArray[4, 19] = Facing.front;
        bodyFacingArray[5, 19] = Facing.front;

        bodyFacingArray[0, 20] = Facing.front;
        bodyFacingArray[1, 20] = Facing.front;
        bodyFacingArray[2, 20] = Facing.front;
        bodyFacingArray[3, 20] = Facing.back;
        bodyFacingArray[4, 20] = Facing.back;
        bodyFacingArray[5, 20] = Facing.back;

    }
}
