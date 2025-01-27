using System.Collections;
using UnityEngine;

namespace Prototype_3.Scripts
{
    public class DestroyTheParticle : MonoBehaviour
    {
        public float destroyTime = 0.2f;
        void Start()
        {
            StartCoroutine(DestroyWithDelay());
        }

        private IEnumerator DestroyWithDelay()
        {
            yield return new WaitForSeconds(destroyTime);
            Destroy(gameObject);
        }

    }
}
