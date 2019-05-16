using UnityEngine;
using UnityEditor;
using UnityEngine.Experimental.Rendering.HDPipeline;

namespace EditorLightUtilities
{
    public static class LightingGizmos
    {
        public static void DrawSpotlightGizmo(Light spotlight)
        {
            var nearDiscDistance = Mathf.Cos(Mathf.Deg2Rad * spotlight.spotAngle / 2) * spotlight.shadowNearPlane;
            var nearDiscRadius = spotlight.shadowNearPlane * Mathf.Sin(spotlight.spotAngle * Mathf.Deg2Rad * 0.5f);

            //Draw Near Plane Disc
            if (spotlight.shadows != LightShadows.None) Handles.Disc(spotlight.gameObject.transform.rotation, spotlight.gameObject.transform.position + spotlight.gameObject.transform.forward * nearDiscDistance, spotlight.gameObject.transform.forward, nearDiscRadius, false, 1);

            //Draw Range Arcs
            var flatRadiusAtRange = spotlight.range * Mathf.Tan(spotlight.spotAngle * Mathf.Deg2Rad * 0.5f);
            var vectorLineUp = Vector3.Normalize(spotlight.gameObject.transform.position + spotlight.gameObject.transform.forward * spotlight.range + spotlight.gameObject.transform.up * flatRadiusAtRange - spotlight.gameObject.transform.position);
            var vectorLineLeft = Vector3.Normalize(spotlight.gameObject.transform.position + spotlight.gameObject.transform.forward * spotlight.range + spotlight.gameObject.transform.right * -flatRadiusAtRange - spotlight.gameObject.transform.position);
            Handles.DrawWireArc(spotlight.gameObject.transform.position, spotlight.gameObject.transform.right, vectorLineUp, spotlight.spotAngle, spotlight.range);
            Handles.DrawWireArc(spotlight.gameObject.transform.position, spotlight.gameObject.transform.up, vectorLineLeft, spotlight.spotAngle, spotlight.range);

            DrawCone(spotlight.spotAngle, spotlight.range, spotlight.transform);

            var additionalLight = spotlight.GetComponent<HDAdditionalLightData>();
            if(additionalLight)
                DrawCone(additionalLight.m_InnerSpotPercent* 0.01f * spotlight.spotAngle, spotlight.range, spotlight.transform);
        }

        public static void DrawCone(float angle, float range, Transform transform)
        {
            var flatRadiusAtRange = range * Mathf.Tan(angle * Mathf.Deg2Rad * 0.5f);

            var vectorLineUp = Vector3.Normalize(transform.position + transform.forward * range + transform.up * flatRadiusAtRange - transform.position);
            var vectorLineDown = Vector3.Normalize(transform.position + transform.forward * range + transform.up * -flatRadiusAtRange - transform.position);
            var vectorLineRight = Vector3.Normalize(transform.position + transform.forward * range + transform.right * flatRadiusAtRange - transform.position);
            var vectorLineLeft = Vector3.Normalize(transform.position + transform.forward * range + transform.right * -flatRadiusAtRange - transform.position);

            var rangeDiscDistance = Mathf.Cos(Mathf.Deg2Rad * angle / 2) * range;
            var rangeDiscRadius = range * Mathf.Sin(angle * Mathf.Deg2Rad * 0.5f);

            //Draw Range disc
            Handles.Disc(transform.rotation, transform.position + transform.forward * rangeDiscDistance, transform.forward, rangeDiscRadius, false, 1);
            //Draw Lines
            Gizmos.DrawLine(transform.position, transform.position + vectorLineUp * range);
            Gizmos.DrawLine(transform.position, transform.position + vectorLineDown * range);
            Gizmos.DrawLine(transform.position, transform.position + vectorLineRight * range);
            Gizmos.DrawLine(transform.position, transform.position + vectorLineLeft * range);
        }

        public static void DrawDirectionalLightGizmo(Transform directionalLightTransform)
        {
            var gizmoSize = 0.2f;
            Handles.Disc(directionalLightTransform.rotation, directionalLightTransform.position, directionalLightTransform.gameObject.transform.forward, gizmoSize, false, 1);
            Gizmos.DrawLine(directionalLightTransform.position, directionalLightTransform.position + directionalLightTransform.forward);
            Gizmos.DrawLine(directionalLightTransform.position + directionalLightTransform.up * gizmoSize, directionalLightTransform.position + directionalLightTransform.up * gizmoSize + directionalLightTransform.forward);
            Gizmos.DrawLine(directionalLightTransform.position + directionalLightTransform.up * -gizmoSize, directionalLightTransform.position + directionalLightTransform.up * -gizmoSize + directionalLightTransform.forward);
            Gizmos.DrawLine(directionalLightTransform.position + directionalLightTransform.right * gizmoSize, directionalLightTransform.position + directionalLightTransform.right * gizmoSize + directionalLightTransform.forward);
            Gizmos.DrawLine(directionalLightTransform.position + directionalLightTransform.right * -gizmoSize, directionalLightTransform.position + directionalLightTransform.right * -gizmoSize + directionalLightTransform.forward);
        }

        public static void DrawCross(Transform m_transform)
        {
            var gizmoSize = 0.25f;
            Gizmos.DrawLine(m_transform.position, m_transform.position + m_transform.TransformVector(m_transform.root.forward * gizmoSize / m_transform.localScale.z));
            Gizmos.DrawLine(m_transform.position, m_transform.position + m_transform.TransformVector(m_transform.root.forward * -gizmoSize / m_transform.localScale.z));
            Gizmos.DrawLine(m_transform.position, m_transform.position + m_transform.TransformVector(m_transform.root.up * gizmoSize / m_transform.localScale.y));
            Gizmos.DrawLine(m_transform.position, m_transform.position + m_transform.TransformVector(m_transform.root.up * -gizmoSize / m_transform.localScale.y));
            Gizmos.DrawLine(m_transform.position, m_transform.position + m_transform.TransformVector(m_transform.root.right * gizmoSize / m_transform.localScale.x));
            Gizmos.DrawLine(m_transform.position, m_transform.position + m_transform.TransformVector(m_transform.root.right * -gizmoSize / m_transform.localScale.x));
        }

        public static void DrawRectangleGizmo(GameObject go, float width, float length)
        {
            Gizmos.matrix = go.transform.localToWorldMatrix;
            Gizmos.DrawWireCube(Vector3.zero, new Vector3(width, length, 0));
            Gizmos.matrix = Matrix4x4.zero;
        }
    }
}
