using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour

{
    [SerializeField] int invokespeed;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem crashParticles;


    private void OnCollisionEnter(Collision other)
    {
        
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This thing is friendly");
                break;
            case "Finish":
                Debug.Log("Succesfully landed! ");
                NewLevelSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
     void NewLevelSequence()
        {
            GetComponent<Movement>().enabled = false;
            Invoke("NextLevel", invokespeed);
            successParticles.Play();
        }
     void StartCrashSequence()
        {
            GetComponent<Movement>().enabled = false;
            Invoke("ReloadLevel", invokespeed);
            crashParticles.Play();
        }
    }void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void NextLevel()
    {
        int currentSceneIndex=SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex==SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        
        SceneManager.LoadScene(nextSceneIndex);
    }

}
