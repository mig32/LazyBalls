using UnityEngine;

namespace LazyBalls.Boosters
{
    public class DirectionalBooster : MonoBehaviour
    {
        [SerializeField] private float boosterForce;
        [SerializeField] private float angleThreshold = 60;

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag(GameTags.Ball))
            {
                return;
            }

            var ballRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (ballRigidbody == null)
            {
                return;
            }

            var collisionVec = collision.transform.position - transform.position;
            var collisionAngle = Vector3.Angle(collisionVec, transform.forward);
            if (collisionAngle > angleThreshold)
            {
                return;
            }
            
            ballRigidbody.AddForce(transform.forward * boosterForce);
        }
    }
}