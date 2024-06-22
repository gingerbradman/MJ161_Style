using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void LoadSceneByIndex(int x)
    {
        SceneManager.LoadScene(x);
    }
}
