using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utility : MonoBehaviour
{
    [SerializeField] private AudioClip sfxClip;

    public void PlaySFX()
    {
        AudioSource.PlayClipAtPoint(sfxClip, Vector3.zero);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
