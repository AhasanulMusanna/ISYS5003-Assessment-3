using System;
using System.Collections.Generic;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Management;

namespace UnityEngine.XR.ARKit
{
    /// <summary>
    /// Manages the lifecycle of ARKit subsystems.
    /// </summary>
    public class ARKitLoader : XRLoaderHelper
    {
        static List<XRSessionSubsystemDescriptor> s_SessionSubsystemDescriptors = new List<XRSessionSubsystemDescriptor>();
        static List<XRCameraSubsystemDescriptor> s_CameraSubsystemDescriptors = new List<XRCameraSubsystemDescriptor>();
        static List<XRPointCloudSubsystemDescriptor> s_PointCloudSubsystemDescriptors = new List<XRPointCloudSubsystemDescriptor>();
        static List<XRPlaneSubsystemDescriptor> s_PlaneSubsystemDescriptors = new List<XRPlaneSubsystemDescriptor>();
        static List<XRAnchorSubsystemDescriptor> s_AnchorSubsystemDescriptors = new List<XRAnchorSubsystemDescriptor>();
        static List<XRRaycastSubsystemDescriptor> s_RaycastSubsystemDescriptors = new List<XRRaycastSubsystemDescriptor>();
        static List<XRHumanBodySubsystemDescriptor> s_HumanBodySubsystemDescriptors = new List<XRHumanBodySubsystemDescriptor>();
        static List<XREnvironmentProbeSubsystemDescriptor> s_EnvironmentProbeSubsystemDescriptors = new List<XREnvironmentProbeSubsystemDescriptor>();
        static List<XRInputSubsystemDescriptor> s_InputSubsystemDescriptors = new List<XRInputSubsystemDescriptor>();
        static List<XRImageTrackingSubsystemDescriptor> s_ImageTrackingSubsystemDescriptors = new List<XRImageTrackingSubsystemDescriptor>();
        static List<XRObjectTrackingSubsystemDescriptor> s_ObjectTrackingSubsystemDescriptors = new List<XRObjectTrackingSubsystemDescriptor>();
        static List<XRFaceSubsystemDescriptor> s_FaceSubsystemDescriptors = new List<XRFaceSubsystemDescriptor>();
        static List<XROcclusionSubsystemDescriptor> s_OcclusionSubsystemDescriptors = new List<XROcclusionSubsystemDescriptor>();
        static List<XRParticipantSubsystemDescriptor> s_ParticipantSubsystemDescriptors = new List<XRParticipantSubsystemDescriptor>();
        static List<XRMeshSubsystemDescriptor> s_MeshSubsystemDescriptors = new List<XRMeshSubsystemDescriptor>();
        static List<XRBoundingBoxSubsystemDescriptor> s_BoundingBoxSubsystemDescriptors = new List<XRBoundingBoxSubsystemDescriptor>();

        /// <summary>
        /// The [XRSessionSubsystem](xref:UnityEngine.XR.ARSubsystems.XRSessionSubsystem) whose lifecycle is managed by this loader.
        /// </summary>
        public XRSessionSubsystem sessionSubsystem => GetLoadedSubsystem<XRSessionSubsystem>();

        /// <summary>
        /// The [XRCameraSubsystem](xref:UnityEngine.XR.ARSubsystems.XRCameraSubsystem) whose lifecycle is managed by this loader.
        /// </summary>
        public XRCameraSubsystem cameraSubsystem => GetLoadedSubsystem<XRCameraSubsystem>();

        /// <summary>
        /// The [XRDepthSubsystem](xref:UnityEngine.XR.ARSubsystems.XRDepthSubsystem) whose lifecycle is managed by this loader.
        /// This field is obsolete. Use <see cref="pointCloudSubsystem"/> instead.
        /// </summary>
        [Obsolete("Use pointCloudSubsystem instead. (2022-02-03)")]
        public XRDepthSubsystem depthSubsystem => GetLoadedSubsystem<XRDepthSubsystem>();

        /// <summary>
        /// The [XRPointCloudSubsystem](xref:UnityEngine.XR.ARSubsystems.XRPointCloudSubsystem) whose lifecycle is managed by this loader.
        /// </summary>
        public XRPointCloudSubsystem pointCloudSubsystem => GetLoadedSubsystem<XRPointCloudSubsystem>();

        /// <summary>
        /// The [XRPlaneSubsystem](xref:UnityEngine.XR.ARSubsystems.XRPlaneSubsystem) whose lifecycle is managed by this loader.
        /// </summary>
        public XRPlaneSubsystem planeSubsystem => GetLoadedSubsystem<XRPlaneSubsystem>();

        /// <summary>
        /// The [XRAnchorSubsystem](xref:UnityEngine.XR.ARSubsystems.XRAnchorSubsystem) whose lifecycle is managed by this loader.
        /// </summary>
        public XRAnchorSubsystem anchorSubsystem => GetLoadedSubsystem<XRAnchorSubsystem>();

        /// <summary>
        /// The [XRRaycastSubsystem](xref:UnityEngine.XR.ARSubsystems.XRRaycastSubsystem) whose lifecycle is managed by this loader.
        /// </summary>
        public XRRaycastSubsystem raycastSubsystem => GetLoadedSubsystem<XRRaycastSubsystem>();

        /// <summary>
        /// The [XRHumanBodySubsystem](xref:UnityEngine.XR.ARSubsystems.XRHumanBodySubsystem) whose lifecycle is managed by this loader.
        /// </summary>
        public XRHumanBodySubsystem humanBodySubsystem => GetLoadedSubsystem<XRHumanBodySubsystem>();

        /// <summary>
        /// The [XREnvironmentProbeSubsystem](xref:UnityEngine.XR.ARSubsystems.XREnvironmentProbeSubsystem) whose lifecycle is managed by this loader.
        /// </summary>
        public XREnvironmentProbeSubsystem environmentProbeSubsystem => GetLoadedSubsystem<XREnvironmentProbeSubsystem>();

        /// <summary>
        /// The [XRInputSubsystem](xref:UnityEngine.XR.XRInputSubsystem) whose lifecycle is managed by this loader.
        /// </summary>
        public XRInputSubsystem inputSubsystem => GetLoadedSubsystem<XRInputSubsystem>();

        /// <summary>
        /// The [XRImageTrackingSubsystem](xref:UnityEngine.XR.ARSubsystems.XRImageTrackingSubsystem) whose lifecycle is managed by this loader.
        /// </summary>
        public XRImageTrackingSubsystem imageTrackingSubsystem => GetLoadedSubsystem<XRImageTrackingSubsystem>();

        /// <summary>
        /// The [XRObjectTrackingSubsystem](xref:UnityEngine.XR.ARSubsystems.XRObjectTrackingSubsystem) whose lifecycle is managed by this loader.
        /// </summary>
        public XRObjectTrackingSubsystem objectTrackingSubsystem => GetLoadedSubsystem<XRObjectTrackingSubsystem>();

        /// <summary>
        /// The [XRFaceSubsystem](xref:UnityEngine.XR.ARSubsystems.XRFaceSubsystem) whose lifecycle is managed by this loader.
        /// </summary>
        public XRFaceSubsystem faceSubsystem => GetLoadedSubsystem<XRFaceSubsystem>();

        /// <summary>
        /// The [XROcclusionSubsystem](xref:UnityEngine.XR.ARSubsystems.XROcclusionSubsystem) whose lifecycle is managed by this loader.
        /// </summary>
        public XROcclusionSubsystem occlusionSubsystem => GetLoadedSubsystem<XROcclusionSubsystem>();

        /// <summary>
        /// The [XRParticipantSubsystem](xref:UnityEngine.XR.ARSubsystems.XRParticipantSubsystem) whose lifecycle is managed by this loader.
        /// </summary>
        public XRParticipantSubsystem participantSubsystem => GetLoadedSubsystem<XRParticipantSubsystem>();

        /// <summary>
        /// The [XRMeshSubsystem](xref:UnityEngine.XR.XRMeshSubsystem) whose lifecycle is
        /// managed by this loader.
        /// </summary>
        public XRMeshSubsystem meshSubsystem => GetLoadedSubsystem<XRMeshSubsystem>();

        /// <summary>
        /// The [XRBoundingBoxSubsystem](xref:UnityEngine.XR.ARSubsystems.XRBoundingBoxSubsystem) whose lifecycle is managed by this loader.
        /// </summary>
        public XRBoundingBoxSubsystem boundingBoxSubsystem => GetLoadedSubsystem<XRBoundingBoxSubsystem>();

        /// <summary>
        /// Initializes the loader.
        /// </summary>
        /// <returns>`True` if the session subsystem was successfully created, otherwise `false`.</returns>
        public override bool Initialize()
        {
#if UNITY_IOS && !UNITY_EDITOR
            CreateSubsystem<XRSessionSubsystemDescriptor, XRSessionSubsystem>(s_SessionSubsystemDescriptors, "ARKit-Session");
            CreateSubsystem<XRCameraSubsystemDescriptor, XRCameraSubsystem>(s_CameraSubsystemDescriptors, "ARKit-Camera");
            CreateSubsystem<XRPointCloudSubsystemDescriptor, XRPointCloudSubsystem>(s_PointCloudSubsystemDescriptors, "ARKit-PointCloud");
            CreateSubsystem<XRPlaneSubsystemDescriptor, XRPlaneSubsystem>(s_PlaneSubsystemDescriptors, "ARKit-Plane");
            CreateSubsystem<XRAnchorSubsystemDescriptor, XRAnchorSubsystem>(s_AnchorSubsystemDescriptors, "ARKit-Anchor");
            CreateSubsystem<XRRaycastSubsystemDescriptor, XRRaycastSubsystem>(s_RaycastSubsystemDescriptors, "ARKit-Raycast");
            CreateSubsystem<XRHumanBodySubsystemDescriptor, XRHumanBodySubsystem>(s_HumanBodySubsystemDescriptors, "ARKit-HumanBody");
            CreateSubsystem<XREnvironmentProbeSubsystemDescriptor, XREnvironmentProbeSubsystem>(s_EnvironmentProbeSubsystemDescriptors, "ARKit-EnvironmentProbe");
            CreateSubsystem<XRInputSubsystemDescriptor, XRInputSubsystem>(s_InputSubsystemDescriptors, "ARKit-Input");

            // Optional subsystems that might not have been registered, based on the iOS version.
            CreateSubsystem<XRImageTrackingSubsystemDescriptor, XRImageTrackingSubsystem>(s_ImageTrackingSubsystemDescriptors, "ARKit-ImageTracking");
            CreateSubsystem<XRObjectTrackingSubsystemDescriptor, XRObjectTrackingSubsystem>(s_ObjectTrackingSubsystemDescriptors, "ARKit-ObjectTracking");
            CreateSubsystem<XRFaceSubsystemDescriptor, XRFaceSubsystem>(s_FaceSubsystemDescriptors, "ARKit-Face");
            CreateSubsystem<XROcclusionSubsystemDescriptor, XROcclusionSubsystem>(s_OcclusionSubsystemDescriptors, "ARKit-Occlusion");
            CreateSubsystem<XRParticipantSubsystemDescriptor, XRParticipantSubsystem>(s_ParticipantSubsystemDescriptors, "ARKit-Participant");
            CreateSubsystem<XRMeshSubsystemDescriptor, XRMeshSubsystem>(s_MeshSubsystemDescriptors, "ARKit-Meshing");
            CreateSubsystem<XRBoundingBoxSubsystemDescriptor, XRBoundingBoxSubsystem>(s_BoundingBoxSubsystemDescriptors, "ARKit-RoomPlan-BoundingBox");

            if (sessionSubsystem == null)
            {
                Debug.LogError("Failed to load session subsystem.");
            }

            return sessionSubsystem != null;
#else
            return false;
#endif
        }

        /// <summary>
        /// This method does nothing. Subsystems must be started individually.
        /// </summary>
        /// <returns>Returns `true` on iOS. Returns `false` otherwise.</returns>
        public override bool Start()
        {
#if UNITY_IOS && !UNITY_EDITOR
            return true;
#else
            return false;
#endif
        }

        /// <summary>
        /// This method does nothing. Subsystems must be stopped individually.
        /// </summary>
        /// <returns>Returns `true` on iOS. Returns `false` otherwise.</returns>
        public override bool Stop()
        {
#if UNITY_IOS && !UNITY_EDITOR
            return true;
#else
            return false;
#endif
        }

        /// <summary>
        /// Destroys each subsystem.
        /// </summary>
        /// <returns>Always returns `true`.</returns>
        public override bool Deinitialize()
        {
#if UNITY_IOS && !UNITY_EDITOR
            DestroySubsystem<XRCameraSubsystem>();
            DestroySubsystem<XRPointCloudSubsystem>();
            DestroySubsystem<XRPlaneSubsystem>();
            DestroySubsystem<XRAnchorSubsystem>();
            DestroySubsystem<XRRaycastSubsystem>();
            DestroySubsystem<XRHumanBodySubsystem>();
            DestroySubsystem<XREnvironmentProbeSubsystem>();
            DestroySubsystem<XRInputSubsystem>();
            DestroySubsystem<XRImageTrackingSubsystem>();
            DestroySubsystem<XRObjectTrackingSubsystem>();
            DestroySubsystem<XRFaceSubsystem>();
            DestroySubsystem<XROcclusionSubsystem>();
            DestroySubsystem<XRParticipantSubsystem>();
            DestroySubsystem<XRMeshSubsystem>();
            DestroySubsystem<XRSessionSubsystem>();
            DestroySubsystem<XRBoundingBoxSubsystem>();
#endif
            return true;
        }
    }
}
