using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace WorkWithCamera
{
    public class CameraBounds : MonoBehaviour
    {
        /*private Camera _camera = null;
        private Plane[] _cameraFrustum = null;
        private Collider _collider;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            var bounds = _collider.bounds;
            _cameraFrustum = GeometryUtility.CalculateFrustumPlanes(_camera);
            if (GeometryUtility.TestPlanesAABB(_cameraFrustum, bounds))
            {
                gameObject.active = false;
            }
            else
            {
                gameObject.active = true;
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log(other.gameObject.name);
            if (other.gameObject.name == "Camera")
            {
                gameObject.SetActive(true);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            Debug.Log(collision.gameObject.name);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name);
        }

        private void OnTriggerExit(Collider other)
        {
            Debug.Log(other.gameObject.name);
        }

        private void OnCollisionExit(Collision other)
        {
            Debug.Log(other.gameObject.name);
            if (other.gameObject.name == "Camera")
            {
                gameObject.SetActive(false);
            }
        }*/
    }
}