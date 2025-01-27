using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototype_3.Scripts
{
    public class RestartBehaviour : MonoBehaviour
    {
        void Update()
        {
            if (Input.anyKeyDown)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
