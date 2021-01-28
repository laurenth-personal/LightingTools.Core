using UnityEngine;
using UnityEngine.Rendering;
#if HDRP
using UnityEngine.Rendering.HighDefinition;
#endif

namespace LightUtilities
{
    [System.Serializable]
    public enum LightmapPresetBakeType
    {
        //Simplify serialization
        Baked = 0,
        Mixed = 1,
        Realtime = 2
    }

    public enum ShadowQuality
    {
        FromQualitySettings = 0,
        Low = 1,
        Medium = 2,
        High = 3,
        VeryHigh = 4
    }

    [System.Serializable]
    public enum LightShape
    {
        Point = 0,
        Spot = 1,
        Directional = 2,
        Rectangle = 3,
        Sphere = 4,
        Line = 5,
        Disc = 6,
        SpotPyramid = 7,
        SpotBox = 8
    }

    [System.Serializable]
    public class CascadeParameters
    {
        [Range(1, 4)]
        public int count = 4;
        [Range(0, 1)]
        public float split0 = 0.05f;
        [Range(0, 1)]
        public float split1 = 0.1f;
        [Range(0, 1)]
        public float split2 = 0.2f;
    }

    [System.Serializable]
    public class LightParameters
    {
        public LightParameters() { }

        public LightParameters(LightType specificType, LightmapPresetBakeType specificBakeMode)
        {
            type = specificType;
            mode = specificBakeMode;
        }

        public LightParameters(LightShape specificShape, LightmapPresetBakeType specificBakeMode)
        {
            shape = specificShape;
            mode = specificBakeMode;
        }

        public LightParameters(LightType specificType, LightmapPresetBakeType specificBakeMode, bool isNeutral)
        {
            if (isNeutral)
            {
                range = 0;
                intensity = 0;
                colorFilter = Color.black;
                indirectIntensity = 0;
                lightAngle = 0;
                innerSpotPercent = 0;
                cookieSize = 0;
                ShadowNearClip = 0;
                shadowStrength = 0;
                viewBiasMin = 0;
                viewBiasScale = 0;
                normalBias = 0;
                maxSmoothness = 0;
                fadeDistance = 0;
                shadowFadeDistance = 0;
                shadowResolution = 0;
                shadowTint = Color.black;
                penumbraTint = Color.white;
            }
            type = specificType;
            mode = specificBakeMode;
        }

        public LightParameters(LightShape specificShape, LightmapPresetBakeType specificBakeMode, bool isNeutral)
        {
            if (isNeutral)
            {
                range = 0;
                intensity = 0;
                colorFilter = Color.black;
                indirectIntensity = 0;
                lightAngle = 0;
                innerSpotPercent = 0;
                cookieSize = 0;
                ShadowNearClip = 0;
                shadowStrength = 0;
                viewBiasMin = 0;
                viewBiasScale = 0;
                normalBias = 0;
                maxSmoothness = 0;
                fadeDistance = 0;
                shadowFadeDistance = 0;
                shadowResolution = 0;
                shadowTint = Color.black;
                penumbraTint = Color.white;
            }
            shape = specificShape;
            mode = specificBakeMode;
        }

        public static LightParameters DeepCopy(LightParameters c)
        {
            LightParameters temp = new LightParameters();
            temp.type = c.type;
            temp.shape = c.shape;
            temp.mode = c.mode;
            temp.range = c.range;
            temp.intensity = c.intensity;
            temp.colorFilter = c.colorFilter;
            temp.useColorTemperature = c.useColorTemperature;
            temp.colorTemperature = c.colorTemperature;
            temp.indirectIntensity = c.indirectIntensity;
            temp.emissionRadius = c.emissionRadius;
            temp.lightAngle = c.lightAngle;
            temp.shadows = c.shadows;
            temp.shadowQuality = c.shadowQuality;
            temp.ShadowNearClip = c.ShadowNearClip;
            temp.viewBiasMin = c.viewBiasMin;
            temp.viewBiasScale = c.viewBiasScale;
            temp.normalBias = c.normalBias;
            temp.lightCookie = c.lightCookie;
            temp.cookieSize = c.cookieSize;
            temp.innerSpotPercent = c.innerSpotPercent;
            temp.length = c.length;
            temp.width = c.width;
            temp.fadeDistance = c.fadeDistance;
            temp.shadowFadeDistance = c.shadowFadeDistance;
            temp.affectDiffuse = c.affectDiffuse;
            temp.affectSpecular = c.affectSpecular;
            temp.shadowStrength = c.shadowStrength;
            temp.cullingMask = c.cullingMask;
            temp.maxSmoothness = c.maxSmoothness;
            temp.shadowResolution = c.shadowResolution;
            temp.shadowSoftness = c.shadowSoftness;
            temp.blockerSampleCount = c.blockerSampleCount;
            temp.filterSampleCount = c.filterSampleCount;
            temp.minFilterSize = c.minFilterSize;
#if HDRP
            temp.lightLayers = c.lightLayers;
            temp.contactShadows = c.contactShadows;
            temp.useVolumetric = c.useVolumetric;
            temp.volumetricDimmer = c.volumetricDimmer;
            temp.volumetricShadowDimmer = c.volumetricShadowDimmer;
            temp.shadowTint = c.shadowTint;
            temp.penumbraTint = c.penumbraTint;
#endif
            return temp;
        }

        public static LightParameters operator +(LightParameters x, LightParameters y)
        {
            var addition = new LightParameters
            {
                intensity = x.intensity + y.intensity,
                range = x.range + y.range,
                colorFilter = x.colorFilter + y.colorFilter,
                useColorTemperature = x.useColorTemperature || y.useColorTemperature ? true : false,
                colorTemperature = x.colorTemperature + y.colorTemperature,
                indirectIntensity = x.indirectIntensity + y.indirectIntensity,
                emissionRadius = x.emissionRadius + y.emissionRadius,
                lightAngle = x.lightAngle + y.lightAngle,
                innerSpotPercent = x.innerSpotPercent + y.innerSpotPercent,
                maxSmoothness = x.maxSmoothness + y.maxSmoothness,
                shadowStrength = x.shadowStrength + y.shadowStrength,
                shadowResolution = x.shadowResolution + y.shadowResolution,
                shadows = x.shadows || y.shadows ? true : false,
                affectDiffuse = x.affectDiffuse || y.affectDiffuse ? true : false,
                affectSpecular = x.affectSpecular || y.affectSpecular ? true : false,
                contactShadows = x.contactShadows || y.contactShadows ? true : false,
                ShadowNearClip = x.ShadowNearClip + y.ShadowNearClip,
                viewBiasMin = x.viewBiasMin + y.viewBiasMin,
                viewBiasScale = x.viewBiasScale + y.viewBiasScale,
                normalBias = x.normalBias + y.normalBias,
                cookieSize = x.cookieSize + y.cookieSize,
                length = x.length + y.length,
                width = x.width + y.width,
                fadeDistance = x.fadeDistance + y.fadeDistance,
                shadowFadeDistance = x.shadowFadeDistance + y.shadowFadeDistance,
                shadowMaxDistance = x.shadowMaxDistance + y.shadowMaxDistance,
                shadowSoftness = x.shadowSoftness + y.shadowSoftness,
                blockerSampleCount = x.blockerSampleCount + y.blockerSampleCount,
                filterSampleCount = x.filterSampleCount + y.filterSampleCount,
                minFilterSize = x.minFilterSize + y.minFilterSize,
                shadowTint = x.shadowTint + y.shadowTint,
                penumbraTint = x.penumbraTint + y.penumbraTint
            };
            return addition;
        }

        public LightType type = LightType.Point;
        public LightShape shape = LightShape.Point;
        public LightmapPresetBakeType mode = LightmapPresetBakeType.Mixed;
        public float range = 8;
        public bool useColorTemperature;
        public float colorTemperature = 6500;
        public Color colorFilter = Color.white;
        public float intensity = 1;
        public float indirectIntensity = 1;
        public float emissionRadius = 0;
        [Range(0, 180)]
        public float lightAngle = 45;
        public bool shadows = true;
        public ShadowQuality shadowQuality = ShadowQuality.Medium;
        [Range(0.01f, 10f)]
        public float ShadowNearClip = 0.1f;
        public float viewBiasMin = 0.2f;
        public float viewBiasScale = 1.0f;
        public float normalBias = 0.2f;
        public Color shadowTint = Color.black;
        public Color penumbraTint = Color.white;
        public Texture lightCookie;
        public float cookieSize = 5;
        [Range(0f, 100f)]
        public float innerSpotPercent = 40;
        public float length;
        public float width;
        public float fadeDistance = 50;
        public float shadowFadeDistance = 10;
        public bool affectDiffuse = true;
        public bool affectSpecular = true;
        [Range(0, 1)]
        public float shadowStrength = 1;
        public float shadowMaxDistance = 150;
        public LayerMask cullingMask = -1;
#if HDRP
        public LightLayerEnum lightLayers = LightLayerEnum.LightLayerDefault;
#endif
        [Range(0, 1)]
        public float maxSmoothness = 1;
        public int shadowResolution = 128;
        public bool contactShadows = false;
        //PCSS Shadows
        [Range(0, 2)]
        public float shadowSoftness = 0.5f;
        [Range(1, 64)]
        public int blockerSampleCount = 24;
        [Range(1, 64)]
        public int filterSampleCount = 16;
        [Range(0.00001f, 0.001f)]
        public float minFilterSize = 0.0002f;
        //Volumetric
        public bool useVolumetric = true;
        [Range(0, 1)]
        public float volumetricDimmer = 1;
        [Range(0, 1)]
        public float volumetricShadowDimmer = 1;
    }

    public static class LightingUtilities
    {

        public static void ApplyLightParameters(Light light, LightParameters lightParameters)
        {
#if HDRP
            var additionalLightData = light.gameObject.GetComponent<HDAdditionalLightData>();
#endif

            //HD
            switch (lightParameters.shape)
            {
                case LightShape.Point:
                    light.type = LightType.Point;
#if HDRP
                    additionalLightData.type = HDLightType.Point;
#endif
                    break;
                case LightShape.Spot:
                    light.type = LightType.Spot;
#if HDRP
                    additionalLightData.type = HDLightType.Spot;
                    additionalLightData.spotLightShape = SpotLightShape.Cone;
#endif
                    break;
                case LightShape.Directional:
                    light.type = LightType.Directional;
#if HDRP
                    additionalLightData.type = HDLightType.Directional;
#endif
                    break;
                case LightShape.SpotBox:
                    light.type = LightType.Spot;
#if HDRP
                    additionalLightData.type = HDLightType.Spot;
                    additionalLightData.spotLightShape = SpotLightShape.Box;
#endif
                    break;
                case LightShape.SpotPyramid:
                    light.type = LightType.Spot;
#if HDRP
                    additionalLightData.type = HDLightType.Spot;
                    additionalLightData.spotLightShape = SpotLightShape.Pyramid;
#endif
                    break;
                case LightShape.Rectangle:
                    light.type = LightType.Point;
#if HDRP
                    additionalLightData.type = HDLightType.Area;
                    additionalLightData.areaLightShape = AreaLightShape.Rectangle;
#endif
                    break;
                case LightShape.Line:
                    light.type = LightType.Point;
#if HDRP
                    additionalLightData.type = HDLightType.Area;
                    additionalLightData.areaLightShape = AreaLightShape.Tube;
#endif
                    break;
            }
            

#if UNITY_EDITOR
            switch (lightParameters.mode)
            {
                case LightmapPresetBakeType.Realtime: light.lightmapBakeType = LightmapBakeType.Realtime; break;
                case LightmapPresetBakeType.Baked: light.lightmapBakeType = LightmapBakeType.Baked; break;
                case LightmapPresetBakeType.Mixed: light.lightmapBakeType = LightmapBakeType.Mixed; break;
            }
#endif
            if (lightParameters.shadows)
                light.shadows = LightShadows.Soft;
            else
                light.shadows = LightShadows.None;
            light.shadowStrength = 1;
            light.shadowNearPlane = lightParameters.ShadowNearClip;
            light.color = lightParameters.colorFilter;
            light.range = lightParameters.range;
            light.spotAngle = lightParameters.lightAngle;
            light.cookie = lightParameters.lightCookie;
            light.cullingMask = lightParameters.cullingMask;
#if HDRP
            light.renderingLayerMask = (int)lightParameters.lightLayers;
#endif
            light.colorTemperature = lightParameters.colorTemperature;

#if HDRP
            additionalLightData.intensity = lightParameters.intensity;
            additionalLightData.shapeRadius = lightParameters.emissionRadius;
            additionalLightData.affectDiffuse = lightParameters.affectDiffuse;
            additionalLightData.affectSpecular = lightParameters.affectSpecular;
            additionalLightData.maxSmoothness = lightParameters.maxSmoothness;
            additionalLightData.fadeDistance = lightParameters.fadeDistance;
            additionalLightData.innerSpotPercent = lightParameters.innerSpotPercent;
            //additionalLightData.shadowSoftness = lightParameters.shadowSoftness;
            additionalLightData.blockerSampleCount = lightParameters.blockerSampleCount;
            additionalLightData.filterSampleCount = lightParameters.filterSampleCount;
            additionalLightData.minFilterSize = lightParameters.minFilterSize;
            additionalLightData.shapeWidth = Mathf.Max(lightParameters.width,0.01f);
            additionalLightData.shapeHeight = Mathf.Max(lightParameters.length,0.01f);
            additionalLightData.areaLightCookie = lightParameters.lightCookie;
            additionalLightData.lightlayersMask = lightParameters.lightLayers;
            additionalLightData.shadowNearPlane = lightParameters.ShadowNearClip;
            additionalLightData.volumetricDimmer = lightParameters.volumetricDimmer;

            additionalLightData.shadowFadeDistance = lightParameters.shadowMaxDistance;
            //additionalLightData.shadowResolution = lightParameters.shadowResolution;
            additionalLightData.shadowDimmer = lightParameters.shadowStrength;
            //additionalLightData.viewBiasMin = lightParameters.viewBiasMin;
            //additionalLightData.viewBiasScale = lightParameters.viewBiasScale;
            additionalLightData.normalBias = lightParameters.normalBias;
            additionalLightData.shadowDimmer = lightParameters.shadowStrength;
            //additionalLightData.useContactShadow = lightParameters.contactShadows;
            additionalLightData.volumetricShadowDimmer = lightParameters.volumetricShadowDimmer;
            additionalLightData.shadowTint = lightParameters.shadowTint;
            
            //TODO : fix penumbra mode
            //additionalLightData.penumbraTint = lightParameters.penumbraTint;
#endif
        }

        public static LightParameters LerpLightParameters(LightParameters from, LightParameters to, float weight)
        {
            var lerpLightParameters = new LightParameters();

            lerpLightParameters.intensity = Mathf.Lerp(from.intensity, to.intensity, weight);
            lerpLightParameters.indirectIntensity = Mathf.Lerp(from.indirectIntensity, to.indirectIntensity, weight);
            lerpLightParameters.emissionRadius = Mathf.Lerp(from.emissionRadius, to.emissionRadius, weight);
            lerpLightParameters.range = Mathf.Lerp(from.range, to.range, weight);
            lerpLightParameters.lightAngle = Mathf.Lerp(from.lightAngle, to.lightAngle, weight);
            lerpLightParameters.width = Mathf.Lerp(from.width, to.width, weight);
            lerpLightParameters.length = Mathf.Lerp(from.length, to.length, weight);
            lerpLightParameters.cookieSize = Mathf.Lerp(from.cookieSize, to.cookieSize, weight);
            lerpLightParameters.colorFilter = Color.Lerp(from.colorFilter, to.colorFilter, weight);
            lerpLightParameters.colorTemperature = Mathf.Lerp(from.colorTemperature, to.colorTemperature, weight);
            lerpLightParameters.maxSmoothness = Mathf.Lerp(from.maxSmoothness, to.maxSmoothness, weight);
            lerpLightParameters.innerSpotPercent = Mathf.Lerp(from.innerSpotPercent, to.innerSpotPercent, weight);

            if (from.shadows == false && to.shadows == false)
            {
                lerpLightParameters.shadows = false;
            }
            else
            {
                lerpLightParameters.shadows = true;
            }
#if HDRP
            lerpLightParameters.lightLayers = weight > 0.5f ? to.lightLayers : from.lightLayers;
#endif
            lerpLightParameters.useColorTemperature = weight > 0.5f ? to.useColorTemperature : from.useColorTemperature;
            lerpLightParameters.shape = weight > 0.5f ? to.shape : from.shape;
            lerpLightParameters.lightCookie = weight > 0.5f ? to.lightCookie : from.lightCookie;
            lerpLightParameters.shadowStrength = Mathf.Lerp(from.shadowStrength, to.shadowStrength, weight);
            lerpLightParameters.viewBiasMin = Mathf.Lerp(from.viewBiasMin, to.viewBiasMin, weight);
            lerpLightParameters.viewBiasScale = Mathf.Lerp(from.viewBiasScale, to.viewBiasScale, weight);
            lerpLightParameters.normalBias = Mathf.Lerp(from.normalBias, to.normalBias, weight);
            lerpLightParameters.ShadowNearClip = Mathf.Lerp(from.ShadowNearClip, to.ShadowNearClip, weight);
            lerpLightParameters.shadowResolution = (int)Mathf.Lerp(from.shadowResolution, to.shadowResolution, weight);

            lerpLightParameters.affectDiffuse = weight > 0.5f ? to.affectDiffuse : from.affectDiffuse;
            lerpLightParameters.affectSpecular = weight > 0.5f ? to.affectSpecular : from.affectSpecular;

            lerpLightParameters.useVolumetric = weight > 0.5f ? to.useVolumetric : from.useVolumetric;
            lerpLightParameters.volumetricDimmer = Mathf.Lerp(from.volumetricDimmer, to.volumetricDimmer, weight);
            lerpLightParameters.volumetricShadowDimmer = Mathf.Lerp(from.volumetricShadowDimmer, to.volumetricShadowDimmer, weight);

            lerpLightParameters.shadowSoftness = Mathf.Lerp(from.shadowSoftness, to.shadowSoftness, weight);
            lerpLightParameters.blockerSampleCount = (int)Mathf.Lerp(from.blockerSampleCount, to.blockerSampleCount, weight);
            lerpLightParameters.filterSampleCount = (int)Mathf.Lerp(from.filterSampleCount, to.filterSampleCount, weight);
            lerpLightParameters.minFilterSize = Mathf.Lerp(from.minFilterSize, to.minFilterSize, weight);
            lerpLightParameters.contactShadows = weight > 0.5f ? to.contactShadows : from.contactShadows;

            lerpLightParameters.cullingMask = weight > 0.5f ? to.cullingMask : from.cullingMask;
            lerpLightParameters.shadowQuality = weight > 0.5f ? to.shadowQuality : from.shadowQuality;

            lerpLightParameters.shadowTint.r = Mathf.Lerp(from.shadowTint.r, to.shadowTint.r, weight);
            lerpLightParameters.shadowTint.g = Mathf.Lerp(from.shadowTint.g, to.shadowTint.g, weight);
            lerpLightParameters.shadowTint.b = Mathf.Lerp(from.shadowTint.b, to.shadowTint.b, weight);
            lerpLightParameters.penumbraTint.r = Mathf.Lerp(from.penumbraTint.r, to.penumbraTint.r, weight);
            lerpLightParameters.penumbraTint.g = Mathf.Lerp(from.penumbraTint.g, to.penumbraTint.g, weight);
            lerpLightParameters.penumbraTint.b = Mathf.Lerp(from.penumbraTint.b, to.penumbraTint.b, weight);

            return lerpLightParameters;
        }
    }
}
