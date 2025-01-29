using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Player : MonoBehaviour
    {
        public Transform stick;
        private bool m_isDown = false;
        public float range = 40f;
        public float speed = 500f;

        private void Update()
        {
            m_isDown = Input.GetMouseButton(0);

            Quaternion rot = stick.localRotation;
            Quaternion toRot = Quaternion.Euler(0, 0, m_isDown ? range : -range);
            rot = Quaternion.RotateTowards(rot, toRot, speed * Time.deltaTime);
            stick.localRotation = rot;
        }

        public void OnCollisionStick(Collider collider)
        {
            Debug.Log(collider, this);
        }
    }
}