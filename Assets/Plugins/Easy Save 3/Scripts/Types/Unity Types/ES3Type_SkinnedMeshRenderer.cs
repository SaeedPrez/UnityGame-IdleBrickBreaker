using ES3Internal;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Scripting;

namespace ES3Types
{
    [Preserve]
    [ES3PropertiesAttribute("bones", "rootBone", "quality", "sharedMesh", "updateWhenOffscreen", "skinnedMotionVectors", "localBounds", "enabled", "shadowCastingMode",
        "receiveShadows", "sharedMaterials", "lightmapIndex", "realtimeLightmapIndex", "lightmapScaleOffset", "motionVectorGenerationMode", "realtimeLightmapScaleOffset",
        "lightProbeUsage", "lightProbeProxyVolumeOverride", "probeAnchor", "reflectionProbeUsage", "sortingLayerName", "sortingLayerID", "sortingOrder")]
    public class ES3Type_SkinnedMeshRenderer : ES3ComponentType
    {
        public static ES3Type Instance;

        public ES3Type_SkinnedMeshRenderer() : base(typeof(SkinnedMeshRenderer))
        {
            Instance = this;
        }

        protected override void WriteComponent(object obj, ES3Writer writer)
        {
            var instance = (SkinnedMeshRenderer)obj;

            writer.WriteProperty("bones", instance.bones);
            writer.WriteProperty("rootBone", instance.rootBone);
            writer.WriteProperty("quality", instance.quality);
            writer.WriteProperty("sharedMesh", instance.sharedMesh);
            writer.WriteProperty("updateWhenOffscreen", instance.updateWhenOffscreen, ES3Type_bool.Instance);
            writer.WriteProperty("skinnedMotionVectors", instance.skinnedMotionVectors, ES3Type_bool.Instance);
            writer.WriteProperty("localBounds", instance.localBounds, ES3Type_Bounds.Instance);
            writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
            writer.WriteProperty("shadowCastingMode", instance.shadowCastingMode);
            writer.WriteProperty("receiveShadows", instance.receiveShadows, ES3Type_bool.Instance);
            writer.WriteProperty("sharedMaterials", instance.sharedMaterials);
            writer.WriteProperty("lightmapIndex", instance.lightmapIndex, ES3Type_int.Instance);
            writer.WriteProperty("realtimeLightmapIndex", instance.realtimeLightmapIndex, ES3Type_int.Instance);
            writer.WriteProperty("lightmapScaleOffset", instance.lightmapScaleOffset, ES3Type_Vector4.Instance);
            writer.WriteProperty("motionVectorGenerationMode", instance.motionVectorGenerationMode);
            writer.WriteProperty("realtimeLightmapScaleOffset", instance.realtimeLightmapScaleOffset, ES3Type_Vector4.Instance);
            writer.WriteProperty("lightProbeUsage", instance.lightProbeUsage);
            writer.WriteProperty("lightProbeProxyVolumeOverride", instance.lightProbeProxyVolumeOverride);
            writer.WriteProperty("probeAnchor", instance.probeAnchor);
            writer.WriteProperty("reflectionProbeUsage", instance.reflectionProbeUsage);
            writer.WriteProperty("sortingLayerName", instance.sortingLayerName, ES3Type_string.Instance);
            writer.WriteProperty("sortingLayerID", instance.sortingLayerID, ES3Type_int.Instance);
            writer.WriteProperty("sortingOrder", instance.sortingOrder, ES3Type_int.Instance);

            // Get BlendShapeWeights
            if (instance.sharedMesh != null)
            {
                var blendShapeWeights = new float[instance.sharedMesh.blendShapeCount];
                for (var i = 0; i < blendShapeWeights.Length; i++)
                    blendShapeWeights[i] = instance.GetBlendShapeWeight(i);
                writer.WriteProperty("blendShapeWeights", blendShapeWeights, ES3Type_floatArray.Instance);
            }
        }

        protected override void ReadComponent<T>(ES3Reader reader, object obj)
        {
            var instance = (SkinnedMeshRenderer)obj;
            foreach (string propertyName in reader.Properties)
                switch (propertyName)
                {
                    case "bones":
                        instance.bones = reader.Read<Transform[]>();
                        break;
                    case "rootBone":
                        instance.rootBone = reader.Read<Transform>(ES3Type_Transform.Instance);
                        break;
                    case "quality":
                        instance.quality = reader.Read<SkinQuality>();
                        break;
                    case "sharedMesh":
                        instance.sharedMesh = reader.Read<Mesh>(ES3Type_Mesh.Instance);
                        break;
                    case "updateWhenOffscreen":
                        instance.updateWhenOffscreen = reader.Read<bool>(ES3Type_bool.Instance);
                        break;
                    case "skinnedMotionVectors":
                        instance.skinnedMotionVectors = reader.Read<bool>(ES3Type_bool.Instance);
                        break;
                    case "localBounds":
                        instance.localBounds = reader.Read<Bounds>(ES3Type_Bounds.Instance);
                        break;
                    case "enabled":
                        instance.enabled = reader.Read<bool>(ES3Type_bool.Instance);
                        break;
                    case "shadowCastingMode":
                        instance.shadowCastingMode = reader.Read<ShadowCastingMode>();
                        break;
                    case "receiveShadows":
                        instance.receiveShadows = reader.Read<bool>(ES3Type_bool.Instance);
                        break;
                    case "sharedMaterials":
                        instance.sharedMaterials = reader.Read<Material[]>();
                        break;
                    case "lightmapIndex":
                        instance.lightmapIndex = reader.Read<int>(ES3Type_int.Instance);
                        break;
                    case "realtimeLightmapIndex":
                        instance.realtimeLightmapIndex = reader.Read<int>(ES3Type_int.Instance);
                        break;
                    case "lightmapScaleOffset":
                        instance.lightmapScaleOffset = reader.Read<Vector4>(ES3Type_Vector4.Instance);
                        break;
                    case "motionVectorGenerationMode":
                        instance.motionVectorGenerationMode = reader.Read<MotionVectorGenerationMode>();
                        break;
                    case "realtimeLightmapScaleOffset":
                        instance.realtimeLightmapScaleOffset = reader.Read<Vector4>(ES3Type_Vector4.Instance);
                        break;
                    case "lightProbeUsage":
                        instance.lightProbeUsage = reader.Read<LightProbeUsage>();
                        break;
                    case "lightProbeProxyVolumeOverride":
                        instance.lightProbeProxyVolumeOverride = reader.Read<GameObject>(ES3Type_GameObject.Instance);
                        break;
                    case "probeAnchor":
                        instance.probeAnchor = reader.Read<Transform>(ES3Type_Transform.Instance);
                        break;
                    case "reflectionProbeUsage":
                        instance.reflectionProbeUsage = reader.Read<ReflectionProbeUsage>();
                        break;
                    case "sortingLayerName":
                        instance.sortingLayerName = reader.Read<string>(ES3Type_string.Instance);
                        break;
                    case "sortingLayerID":
                        instance.sortingLayerID = reader.Read<int>(ES3Type_int.Instance);
                        break;
                    case "sortingOrder":
                        instance.sortingOrder = reader.Read<int>(ES3Type_int.Instance);
                        break;
                    case "blendShapeWeights":
                        var blendShapeWeights = reader.Read<float[]>(ES3Type_floatArray.Instance);
                        if (instance.sharedMesh == null) break;
                        if (blendShapeWeights.Length != instance.sharedMesh.blendShapeCount)
                            ES3Debug.LogError(
                                "The number of blend shape weights we are loading does not match the number of blend shapes in this SkinnedMeshRenderer's Mesh");
                        for (var i = 0; i < blendShapeWeights.Length; i++)
                            instance.SetBlendShapeWeight(i, blendShapeWeights[i]);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
        }
    }

    public class ES3Type_SkinnedMeshRendererArray : ES3ArrayType
    {
        public static ES3Type Instance;

        public ES3Type_SkinnedMeshRendererArray() : base(typeof(SkinnedMeshRenderer[]), ES3Type_SkinnedMeshRenderer.Instance)
        {
            Instance = this;
        }
    }
}