using UnityEngine;

namespace Prototype_1.Scripts
{
    public class PlayerCollusion : MonoBehaviour
    {
        
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                gameObject.SetActive(false);
                GameManager.instance.EndGame(other.gameObject.GetComponent<CarMovement>().PlayerID);
            }
        }
    }
}
