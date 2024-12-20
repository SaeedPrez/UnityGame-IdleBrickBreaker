using UnityEngine;
using UnityEngine.Scripting;

namespace ES3Types
{
    [Preserve]
    [ES3PropertiesAttribute("enabled", "separateAxes", "strength", "strengthMultiplier", "strengthX", "strengthXMultiplier", "strengthY", "strengthYMultiplier",
        "strengthZ", "strengthZMultiplier", "frequency", "damping", "octaveCount", "octaveMultiplier", "octaveScale", "quality", "scrollSpeed", "scrollSpeedMultiplier",
        "remapEnabled", "remap", "remapMultiplier", "remapX", "remapXMultiplier", "remapY", "remapYMultiplier", "remapZ", "remapZMultiplier")]
    public class ES3Type_NoiseModule : ES3Type
    {
        public static ES3Type Instance;

        public ES3Type_NoiseModule() : base(typeof(ParticleSystem.NoiseModule))
        {
            Instance = this;
        }

        public override void Write(object obj, ES3Writer writer)
        {
            var instance = (ParticleSystem.NoiseModule)obj;

            writer.WriteProperty("enabled", instance.enabled, ES3Type_bool.Instance);
            writer.WriteProperty("separateAxes", instance.separateAxes, ES3Type_bool.Instance);
            writer.WriteProperty("strength", instance.strength, ES3Type_MinMaxCurve.Instance);
            writer.WriteProperty("strengthMultiplier", instance.strengthMultiplier, ES3Type_float.Instance);
            writer.WriteProperty("strengthX", instance.strengthX, ES3Type_MinMaxCurve.Instance);
            writer.WriteProperty("strengthXMultiplier", instance.strengthXMultiplier, ES3Type_float.Instance);
            writer.WriteProperty("strengthY", instance.strengthY, ES3Type_MinMaxCurve.Instance);
            writer.WriteProperty("strengthYMultiplier", instance.strengthYMultiplier, ES3Type_float.Instance);
            writer.WriteProperty("strengthZ", instance.strengthZ, ES3Type_MinMaxCurve.Instance);
            writer.WriteProperty("strengthZMultiplier", instance.strengthZMultiplier, ES3Type_float.Instance);
            writer.WriteProperty("frequency", instance.frequency, ES3Type_float.Instance);
            writer.WriteProperty("damping", instance.damping, ES3Type_bool.Instance);
            writer.WriteProperty("octaveCount", instance.octaveCount, ES3Type_int.Instance);
            writer.WriteProperty("octaveMultiplier", instance.octaveMultiplier, ES3Type_float.Instance);
            writer.WriteProperty("octaveScale", instance.octaveScale, ES3Type_float.Instance);
            writer.WriteProperty("quality", instance.quality);
            writer.WriteProperty("scrollSpeed", instance.scrollSpeed, ES3Type_MinMaxCurve.Instance);
            writer.WriteProperty("scrollSpeedMultiplier", instance.scrollSpeedMultiplier, ES3Type_float.Instance);
            writer.WriteProperty("remapEnabled", instance.remapEnabled, ES3Type_bool.Instance);
            writer.WriteProperty("remap", instance.remap, ES3Type_MinMaxCurve.Instance);
            writer.WriteProperty("remapMultiplier", instance.remapMultiplier, ES3Type_float.Instance);
            writer.WriteProperty("remapX", instance.remapX, ES3Type_MinMaxCurve.Instance);
            writer.WriteProperty("remapXMultiplier", instance.remapXMultiplier, ES3Type_float.Instance);
            writer.WriteProperty("remapY", instance.remapY, ES3Type_MinMaxCurve.Instance);
            writer.WriteProperty("remapYMultiplier", instance.remapYMultiplier, ES3Type_float.Instance);
            writer.WriteProperty("remapZ", instance.remapZ, ES3Type_MinMaxCurve.Instance);
            writer.WriteProperty("remapZMultiplier", instance.remapZMultiplier, ES3Type_float.Instance);
        }

        public override object Read<T>(ES3Reader reader)
        {
            var instance = new ParticleSystem.NoiseModule();
            ReadInto<T>(reader, instance);
            return instance;
        }

        public override void ReadInto<T>(ES3Reader reader, object obj)
        {
            var instance = (ParticleSystem.NoiseModule)obj;
            string propertyName;
            while ((propertyName = reader.ReadPropertyName()) != null)
                switch (propertyName)
                {
                    case "enabled":
                        instance.enabled = reader.Read<bool>(ES3Type_bool.Instance);
                        break;
                    case "separateAxes":
                        instance.separateAxes = reader.Read<bool>(ES3Type_bool.Instance);
                        break;
                    case "strength":
                        instance.strength = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
                        break;
                    case "strengthMultiplier":
                        instance.strengthMultiplier = reader.Read<float>(ES3Type_float.Instance);
                        break;
                    case "strengthX":
                        instance.strengthX = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
                        break;
                    case "strengthXMultiplier":
                        instance.strengthXMultiplier = reader.Read<float>(ES3Type_float.Instance);
                        break;
                    case "strengthY":
                        instance.strengthY = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
                        break;
                    case "strengthYMultiplier":
                        instance.strengthYMultiplier = reader.Read<float>(ES3Type_float.Instance);
                        break;
                    case "strengthZ":
                        instance.strengthZ = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
                        break;
                    case "strengthZMultiplier":
                        instance.strengthZMultiplier = reader.Read<float>(ES3Type_float.Instance);
                        break;
                    case "frequency":
                        instance.frequency = reader.Read<float>(ES3Type_float.Instance);
                        break;
                    case "damping":
                        instance.damping = reader.Read<bool>(ES3Type_bool.Instance);
                        break;
                    case "octaveCount":
                        instance.octaveCount = reader.Read<int>(ES3Type_int.Instance);
                        break;
                    case "octaveMultiplier":
                        instance.octaveMultiplier = reader.Read<float>(ES3Type_float.Instance);
                        break;
                    case "octaveScale":
                        instance.octaveScale = reader.Read<float>(ES3Type_float.Instance);
                        break;
                    case "quality":
                        instance.quality = reader.Read<ParticleSystemNoiseQuality>();
                        break;
                    case "scrollSpeed":
                        instance.scrollSpeed = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
                        break;
                    case "scrollSpeedMultiplier":
                        instance.scrollSpeedMultiplier = reader.Read<float>(ES3Type_float.Instance);
                        break;
                    case "remapEnabled":
                        instance.remapEnabled = reader.Read<bool>(ES3Type_bool.Instance);
                        break;
                    case "remap":
                        instance.remap = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
                        break;
                    case "remapMultiplier":
                        instance.remapMultiplier = reader.Read<float>(ES3Type_float.Instance);
                        break;
                    case "remapX":
                        instance.remapX = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
                        break;
                    case "remapXMultiplier":
                        instance.remapXMultiplier = reader.Read<float>(ES3Type_float.Instance);
                        break;
                    case "remapY":
                        instance.remapY = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
                        break;
                    case "remapYMultiplier":
                        instance.remapYMultiplier = reader.Read<float>(ES3Type_float.Instance);
                        break;
                    case "remapZ":
                        instance.remapZ = reader.Read<ParticleSystem.MinMaxCurve>(ES3Type_MinMaxCurve.Instance);
                        break;
                    case "remapZMultiplier":
                        instance.remapZMultiplier = reader.Read<float>(ES3Type_float.Instance);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
        }
    }
}