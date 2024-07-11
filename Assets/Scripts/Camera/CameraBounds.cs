using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

namespace WorkWithCamera
{
    public class CameraBounds : MonoBehaviour
    {
        [SerializeField] private BoxCollider _trigger = null;
        [SerializeField] private float _triggerSize = 1.0f;
        private const int _RaycustDistance = 100;

        private void Start()
        {
            CheckObjectsInView();
        }

        private void Update()
        {
            CheckObjectsInView();
        }

        private void CheckObjectsInView()
        {
            Vector3 cameraPosition = transform.position;
            List<RaycastHit> raycastHits = new List<RaycastHit>();
            Vector3 direction = transform.forward * _RaycustDistance;
            foreach (RaycastHit hit in Physics.RaycastAll(cameraPosition, direction))
            {
                if (hit.collider.gameObject.layer == 6)
                {
                    raycastHits.Add(hit);
                }
            }
            float scale = Vector3.Distance(cameraPosition, raycastHits[0].point);

            RaycastHit[] hitsArray = raycastHits.ToArray();



            float distanceLastToFirst = Vector3.Distance(raycastHits[0].point, raycastHits[hitsArray.Length - 1].point);

            if (distanceLastToFirst < 1)
            {
                distanceLastToFirst = 1;
            }

            _trigger.center = new Vector3(0, 0, hitsArray[0].distance + (distanceLastToFirst / 2));
            _trigger.size = new Vector3(1 * scale * _triggerSize, 1 * scale * _triggerSize, distanceLastToFirst + 1);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.name);
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
        }

        private void OnTriggerExit(Collider other)
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}