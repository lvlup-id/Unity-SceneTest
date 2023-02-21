using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void ChangeScene(int sceneIdx)
    {
        print("oi");
        print(sceneIdx + " " + SceneManager.GetSceneByBuildIndex(sceneIdx).name);
        SceneManager.LoadScene(sceneIdx, LoadSceneMode.Single);

    }

    public void Meow()
    {
        print("meow");
    }
}
