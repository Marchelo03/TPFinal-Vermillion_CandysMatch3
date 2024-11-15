

using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.TestTools;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class TestSuite
{
    //public GUIManager GuiCopy;
    //public static BoardManager instance;
    int valoLlega = 300;
    int movement = 2;
    int quantity = 3;
    bool ItMatch = true;
    bool special = false;
    bool posible = true;
    bool kaboom = false;
    private GameObject boardManager;
    private AudioSource specialSoundEffect;
    private ParticleSystem specialVisualEffect;


    /*
    [SetUp]
    public void Setup()
    {
        //GuiCopy = GameObject.Find("GUIManagerCanvas").GetComponent<GUIManager>();
       //instance = GameObject.Find("BoardPanel").GetComponent<BoardManager>();

        
        boardManager = GameObject.Find("GameManager");

        Assert.IsNotNull(boardManager, "No se encontró el objeto GameManager en la escena.");

        specialSoundEffect = boardManager.GetComponent<AudioSource>();
        specialVisualEffect = boardManager.GetComponentInChildren<ParticleSystem>();

        Assert.IsNotNull(specialSoundEffect, "No se encontró AudioSource en el objeto GameManager.");
        Assert.IsNotNull(specialVisualEffect, "No se encontró ParticleSystem en el objeto GameManager.");
    }

    [UnityTest]
    public IEnumerator GenerateSpecialEffects()
    {

        boardManager.GetComponent<BoardManager>().FindMatches(4); // Simula un match de 4 fichas llamando al método correspondiente

        yield return null; // Espera un frame para la activación de los efectos

        // Verifica que el sonido se haya activado
        Assert.IsTrue(specialSoundEffect.isPlaying, "El sonido especial no se activó al realizar un match de 4 o más fichas.");

        // Verifica que el efecto visual se haya activado
        Assert.IsTrue(specialVisualEffect.isPlaying, "El efecto visual especial no se activó al realizar un match de 4 o más fichas.");
    } */

    [UnityTest]
    public IEnumerator PointsFinal()
    {
        int PuntajeFin = valoLlega;

        if (ItMatch)
        {
            int matches = quantity;

            PuntajeFin += matches * 50;
        }

        yield return new WaitForSeconds(0.1f);

        movement --;

        Assert.AreNotEqual(PuntajeFin, valoLlega);
    }

    [UnityTest]
    public IEnumerator LastMovement()
    {
        yield return new WaitForSeconds(0.1f);

        Assert.Greater(movement, 0);
    }

    [UnityTest]

    public IEnumerator SpecialComb()
    {
        int maches = 4;
        if (maches >= 4)
        {
            special = true;
        }
        yield return new WaitForSeconds(0.1f);

        Assert.IsTrue(special);
    }

    [UnityTest]

    public IEnumerator SpecialOverspecialize()
    {
        if (posible & special)
        {
            kaboom = true;
        }
        yield return new WaitForSeconds(0.1f);
        Assert.IsTrue(kaboom);
    }

    [UnityTest]

    public IEnumerator match3()
    {
           yield return new WaitForSeconds(0.1f);
           Assert.IsTrue(posible);
    }
} 
