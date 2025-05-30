using System;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace UnityEngine.XR.Interaction.Toolkit
{
    /// <summary>
    /// Add this attribute to an XR Interaction component to control whether to allow or disallow multiple selection mode.
    /// </summary>
    /// <seealso cref="InteractableSelectMode.Multiple"/>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class CanSelectMultipleAttribute : Attribute
    {
        /// <summary>
        /// Whether to allow multiple selection mode. The default value is <see langword="true"/> to allow.
        /// </summary>
        public bool allowMultiple { get; }

        /// <summary>
        /// Initializes the attribute specifying whether to allow or disallow multiple selection mode.
        /// </summary>
        /// <param name="allowMultiple">Specifies whether to allow the mode to enable multiple objects to be selected.</param>
        public CanSelectMultipleAttribute(bool allowMultiple = true)
        {
            this.allowMultiple = allowMultiple;
        }
    }
}
