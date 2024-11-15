using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;


public class SpecialMatchTest : MonoBehaviour
{
    private GameObject boardManager;
    private AudioSource specialSoundEffect;
    private ParticleSystem specialVisualEffect;
    

    [SetUp]
    public void SetUp()
    {     
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
    }
}
