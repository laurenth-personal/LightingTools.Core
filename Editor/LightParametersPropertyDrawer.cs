using LightUtilities;
using UnityEditor;
using UnityEngine;

namespace EditorLightUtilities
{
    [CustomPropertyDrawer (typeof (LightParameters))]
    public class LightParametersPropertyDrawer : PropertyDrawer {


	    // Draw the property inside the given rect
	    public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) 
	    {
		    // Using BeginProperty / EndProperty on the parent property means that
		    // prefab override logic works on the entire property.
		    EditorGUI.BeginProperty (position, label, property);

            EditorGUI.indentLevel--;
            LightUIUtilities.DrawSplitter();
            LightUIUtilities.DrawHeader("Light");
            EditorGUI.indentLevel++;

		    EditorGUILayout.PropertyField(property.FindPropertyRelative("intensity"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("colorFilter"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("shape"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("mode"), new GUIContent("Light mode"));
		    EditorGUILayout.PropertyField(property.FindPropertyRelative("range"));
		    EditorGUILayout.PropertyField(property.FindPropertyRelative("indirectIntensity"));
		    EditorGUILayout.PropertyField(property.FindPropertyRelative("lightCookie"));
		
		    if (property.FindPropertyRelative("lightCookie").objectReferenceValue != null)
		    {
			    EditorGUILayout.PropertyField(property.FindPropertyRelative("cookieSize"));	
		    }

            DrawShapeSection(property);

            EditorGUILayout.Space();
            EditorGUI.indentLevel--;
            LightUIUtilities.DrawSplitter();
            property.FindPropertyRelative("useVolumetric").boolValue = LightUIUtilities.DrawHeader("Volumetric", property.FindPropertyRelative("useVolumetric").boolValue);
            EditorGUI.indentLevel++;
            EditorGUI.BeginDisabledGroup(!property.FindPropertyRelative("useVolumetric").boolValue);
            EditorGUILayout.PropertyField(property.FindPropertyRelative("volumetricDimmer"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("volumetricShadowDimmer"));
            EditorGUI.EndDisabledGroup();

            // Draw label
            EditorGUILayout.Space();
            EditorGUI.indentLevel--;
            LightUIUtilities.DrawSplitter();
            property.FindPropertyRelative("shadows").boolValue = LightUIUtilities.DrawHeader("Shadows", property.FindPropertyRelative("shadows").boolValue);
            EditorGUI.indentLevel++;

            EditorGUI.BeginDisabledGroup(!property.FindPropertyRelative("shadows").boolValue);
            EditorGUILayout.PropertyField(property.FindPropertyRelative("shadowResolution"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("ShadowNearClip"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("shadowStrength"), new GUIContent("Shadow Dimmer"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("viewBiasMin"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("viewBiasScale"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("normalBias"));
            EditorGUILayout.LabelField("PCSS", EditorStyles.boldLabel);
            EditorGUILayout.PropertyField(property.FindPropertyRelative("shadowSoftness"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("blockerSampleCount"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("filterSampleCount"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("minFilterSize"));
            EditorGUI.EndDisabledGroup();


            // Draw label
            EditorGUILayout.Space();
            EditorGUI.indentLevel--;
            LightUIUtilities.DrawSplitter();
            LightUIUtilities.DrawHeader("Additional settings");
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(property.FindPropertyRelative("affectDiffuse"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("affectSpecular"));
            EditorGUILayout.PropertyField(property.FindPropertyRelative("cullingMask"));
            EditorGUI.EndProperty();
        }

        private void DrawShapeSection(SerializedProperty property)
        {
            // Draw label
            EditorGUILayout.Space();
            EditorGUI.indentLevel--;
            LightUIUtilities.DrawSplitter();
            LightUIUtilities.DrawHeader("Shape");
            EditorGUI.indentLevel++;

            switch(property.FindPropertyRelative("shape").enumValueIndex)
            {
                //PointLight
                case 0:
                    EditorGUILayout.PropertyField(property.FindPropertyRelative("maxSmoothness"));
                    EditorGUILayout.PropertyField(property.FindPropertyRelative("emissionRadius"));
                    break;
                //Spotlight Cone
                case 1:
                    EditorGUILayout.PropertyField(property.FindPropertyRelative("lightAngle"));
                    EditorGUILayout.PropertyField(property.FindPropertyRelative("innerSpotPercent"));
                    EditorGUILayout.PropertyField(property.FindPropertyRelative("maxSmoothness"));
                    EditorGUILayout.PropertyField(property.FindPropertyRelative("emissionRadius"));
                    break;
                //Directional
                case 2:
                    EditorGUILayout.PropertyField(property.FindPropertyRelative("maxSmoothness"));
                    break;
                //Rectangle
                case 3:
                    EditorGUILayout.PropertyField(property.FindPropertyRelative("width"));
                    EditorGUILayout.PropertyField(property.FindPropertyRelative("length"));
                    break;
                //Tube
                case 5:
                    EditorGUILayout.PropertyField(property.FindPropertyRelative("length"));
                    break;
                //Spot Pyramid
                case 7:
                    EditorGUILayout.PropertyField(property.FindPropertyRelative("lightAngle"));
                    break;
                //Spot Box
                case 8:
                    EditorGUILayout.PropertyField(property.FindPropertyRelative("width"));
                    EditorGUILayout.PropertyField(property.FindPropertyRelative("length"));
                    break;
            }
        }
    }
}