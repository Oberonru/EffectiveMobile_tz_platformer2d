using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure.Services
{
    [CreateAssetMenu(fileName = "SceneLoaderService", menuName = "Services/SceneLoaderService")]

    public class SceneLoaderService : ScriptableService
    {
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}