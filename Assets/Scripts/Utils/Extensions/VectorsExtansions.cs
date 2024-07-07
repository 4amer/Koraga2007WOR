using Cinemachine.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utils.Extentions
{
    public static class VectorsExtensions
    {
        public static float HighestValue(this Vector2 vec2)
        {
            float value = vec2.x > vec2.y ? vec2.x : vec2.y;
            return value;
        }
        public static float HighestAbsValue(this Vector2 vec2)
        {
            vec2 = vec2.Abs();
            float value = vec2.x > vec2.y ? vec2.x : vec2.y;
            return value;
        }
        public static float LeastValue(this Vector2 vec2)
        {
            float value = vec2.x > vec2.y ? vec2.y : vec2.x;
            return value;
        }
        public static float LeastAbsValue(this Vector2 vec2)
        {
            vec2 = vec2.Abs();
            float value = vec2.x > vec2.y ? vec2.y : vec2.x;
            return value;
        }
    }
}