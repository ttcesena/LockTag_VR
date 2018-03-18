using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LockTag
{
    public class IF_Prototype : MonoBehaviour
    {
        // displacement vs. distance
        // displacement is the magnitude between the final position and the starting position
        // distance is the sum of the magnitudes between the starting position and the final position

        // speed vs velocity
        // speed is distance over time
        // velocity is displacement over time with respects to direction

        public Transform transformToTrack;
        [HideInInspector]
        public float transformationDisplacementMagnitude = 0;
        [HideInInspector]
        public float transformationDistanceMagnitude = 0;
        private Vector3 transformationDisplacement;
        private Vector3 transformationDistance;

        private Vector3 rotationDisplacement;
        private Vector3 rotationDistance;

        private Vector3 previousPosition;

        private Vector3 firstPosition;
        private Vector3 currentPosition;

        private Quaternion firstRotation;
        private Quaternion currentRotation;

        [HideInInspector]
        public float totalTime = 0;
        private float startTime = 0;

        [HideInInspector]
        public float speed;
        [HideInInspector]
        public Velocity velocity;
        public struct Velocity
        {
            public float magnitude;
            public float direction;
        }

        private bool isOn;

        public void OnStart()
        {
            Start();

            startTime = Time.time;
            firstPosition = transformToTrack.position;
            firstRotation = transformToTrack.rotation;

            currentPosition = firstPosition;

            isOn = true;
        }

        public void OnStop()
        {
            Stop();
            isOn = false;
        }

        private void FixedUpdate()
        {
            if (isOn) Tick();
        }

        private void Start()
        {
            totalTime = 0;
            startTime = 0;

            transformationDisplacementMagnitude = 0;
            transformationDistanceMagnitude = 0;

            transformationDistance = Vector3.zero;
            transformationDisplacement = Vector3.zero;
        }

        private void Tick()
        {
            previousPosition = currentPosition;
            currentPosition = transformToTrack.localPosition;

            // Transformation Distance
            transformationDistance.x += Mathf.Abs(currentPosition.x - previousPosition.x);
            transformationDistance.y += Mathf.Abs(currentPosition.x - previousPosition.y);
            transformationDistance.z += Mathf.Abs(currentPosition.x - previousPosition.z);

            transformationDistanceMagnitude += Vector3.Distance(previousPosition, currentPosition);

            // Rotation Distance
            //rotationDistance
        }

        private void Stop()
        {
            // Current
            currentPosition = transformToTrack.position;
            currentRotation = transformToTrack.rotation;

            // Time
            totalTime = Time.time - startTime;

            // Transformation Displacement
            transformationDisplacementMagnitude = Vector3.Distance(currentPosition, firstPosition);

            transformationDisplacement.x = Mathf.Abs(currentPosition.x - firstPosition.x);
            transformationDisplacement.y = Mathf.Abs(currentPosition.y - firstPosition.y);
            transformationDisplacement.z = Mathf.Abs(currentPosition.z - firstPosition.z);

            // Rotation Displacement
            velocity.direction = Mathf.Acos(Quaternion.Dot(firstRotation, currentRotation));

            // Speed
            speed = transformationDistanceMagnitude / totalTime;

            // Velocity
            velocity.magnitude = transformationDisplacementMagnitude / totalTime;


        }
    }
}
