using UnityEngine;

namespace Prototype_1.Scripts
{
    public class RestartBehaviour : MonoBehaviour
    {
        void Update()
        {
            if (Input.anyKeyDown)
            {
                GameManager.instance.StartGame();
                UIManager.instance.DeactivateEndGameUI();
            }
        }
    }
}
