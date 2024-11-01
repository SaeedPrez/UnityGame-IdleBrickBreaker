﻿using System;
using ES3Internal;
using UnityEngine.Scripting;
using Object = UnityEngine.Object;

namespace ES3Types
{
    [Preserve]
    public abstract class ES3UnityObjectType : ES3ObjectType
    {
        public ES3UnityObjectType(Type type) : base(type)
        {
            isValueType = false;
            isES3TypeUnityObject = true;
        }

        protected abstract void WriteUnityObject(object obj, ES3Writer writer);
        protected abstract void ReadUnityObject<T>(ES3Reader reader, object obj);
        protected abstract object ReadUnityObject<T>(ES3Reader reader);

        protected override void WriteObject(object obj, ES3Writer writer)
        {
            WriteObject(obj, writer, ES3.ReferenceMode.ByRefAndValue);
        }

        public virtual void WriteObject(object obj, ES3Writer writer, ES3.ReferenceMode mode)
        {
            if (WriteUsingDerivedType(obj, writer, mode))
                return;
            var instance = obj as Object;
            if (obj != null && instance == null)
                throw new ArgumentException("Only types of UnityEngine.Object can be written with this method, but argument given is type of " + obj.GetType());

            // If this object is in the instance manager, store it's instance ID with it.
            if (mode != ES3.ReferenceMode.ByValue)
            {
                var refMgr = ES3ReferenceMgrBase.Current;
                if (refMgr == null)
                    throw new InvalidOperationException(
                        $"An Easy Save 3 Manager is required to save references. To add one to your scene, exit playmode and go to Tools > Easy Save 3 > Add Manager to Scene. Object being saved by reference is {instance.GetType()} with name {instance.name}.");
                writer.WriteRef(instance);
                if (mode == ES3.ReferenceMode.ByRef)
                    return;
            }

            WriteUnityObject(instance, writer);
        }

        protected override void ReadObject<T>(ES3Reader reader, object obj)
        {
            var refMgr = ES3ReferenceMgrBase.Current;
            if (refMgr != null)
                foreach (string propertyName in reader.Properties)
                    if (propertyName == ES3ReferenceMgrBase.referencePropertyName)
                        // If the object we're loading into isn't registered with the reference manager, register it.
                    {
                        refMgr.Add((Object)obj, reader.Read_ref());
                    }
                    else
                    {
                        reader.overridePropertiesName = propertyName;
                        break;
                    }

            ReadUnityObject<T>(reader, obj);
        }

        protected override object ReadObject<T>(ES3Reader reader)
        {
            var refMgr = ES3ReferenceMgrBase.Current;
            if (refMgr == null)
                return ReadUnityObject<T>(reader);

            long id = -1;
            Object instance = null;

            foreach (string propertyName in reader.Properties)
                if (propertyName == ES3ReferenceMgrBase.referencePropertyName)
                {
                    if (refMgr == null)
                        throw new InvalidOperationException(
                            $"An Easy Save 3 Manager is required to save references. To add one to your scene, exit playmode and go to Tools > Easy Save 3 > Add Manager to Scene. Object being saved by reference is {instance.GetType()} with name {instance.name}.");
                    id = reader.Read_ref();
                    instance = refMgr.Get(id, type);

                    if (instance != null)
                        break;
                }
                else
                {
                    reader.overridePropertiesName = propertyName;
                    if (instance == null)
                    {
                        instance = (Object)ReadUnityObject<T>(reader);
                        refMgr.Add(instance, id);
                    }

                    break;
                }

            ReadUnityObject<T>(reader, instance);
            return instance;
        }

        protected bool WriteUsingDerivedType(object obj, ES3Writer writer, ES3.ReferenceMode mode)
        {
            var objType = obj.GetType();

            if (objType != type)
            {
                writer.WriteType(objType);

                var es3Type = ES3TypeMgr.GetOrCreateES3Type(objType);
                if (es3Type is ES3UnityObjectType)
                    ((ES3UnityObjectType)es3Type).WriteObject(obj, writer, mode);
                else
                    es3Type.Write(obj, writer);

                return true;
            }

            return false;
        }
    }
}