using System.Collections;
using UnityEngine;

namespace Prototype_3.Scripts
{
    public class GameOverScreenHandler : MonoBehaviour
    {
        public GameObject restartReminderer;

        private void Start()
        {
            StartCoroutine(StartRestartRemindererWithDelay());
        }

        private IEnumerator StartRestartRemindererWithDelay()
        {
            yield return new WaitForSeconds(2f);
            restartReminderer.SetActive(true);
        }
    }
}
