using System.Collections.Generic;
using UnityEngine.Assertions;

namespace Unity.Tutorials.Core
{
    /// <summary>
    /// Manages SceneObjectGuids.
    /// </summary>
    /// <seealso cref="SceneObjectGuid"/>
    public class SceneObjectGuidManager
    {
        static SceneObjectGuidManager m_Instance;
        Dictionary<string, SceneObjectGuid> m_Components = new Dictionary<string, SceneObjectGuid>();

        /// <summary>
        /// Returns the singleton instance.
        /// </summary>
        public static SceneObjectGuidManager Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new SceneObjectGuidManager();
                }
                return m_Instance;
            }
            private set { m_Instance = value; }
        }

        /// <summary>
        /// Registers a GUID component.
        /// </summary>
        /// <param name="component">The Component to register</param>
        public void Register(SceneObjectGuid component)
        {
            Assert.IsFalse(string.IsNullOrEmpty(component.Id));
            //Add will trow an exception if the id is already registered
            m_Components.Add(component.Id, component);
        }

        /// <summary>
        /// Does the manager contain a Component for specific GUID.
        /// </summary>
        /// <param name="id">The GUID to check </param>
        /// <returns>True if the given GUID is present in the component lists, false otherwise</returns>
        public bool Contains(string id)
        {
            return m_Components.ContainsKey(id);
        }

        /// <summary>
        /// Unregisters a GUID Component.
        /// </summary>
        /// <param name="component">The component to remove</param>
        /// <returns>True if the Component was found and unregistered, false otherwise.</returns>
        public bool Unregister(SceneObjectGuid component)
        {
            return m_Components.Remove(component.Id);
        }

        /// <summary>
        /// Returns the GUID Component for a specific GUID, if found.
        /// </summary>
        /// <param name="id">The GUID of the component to retrieve</param>
        /// <returns>The SceneObjectGuid of the given GUID if found, null otherwise</returns>
        public SceneObjectGuid GetComponent(string id)
        {
            if (m_Components.TryGetValue(id, out SceneObjectGuid value))
            {
                return value;
            }
            return null;
        }
    }
}
