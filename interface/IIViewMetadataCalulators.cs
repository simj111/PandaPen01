using System;

namespace Interfaces.Events
{
    /// <summary>
    /// This interface is used to gather the metadata of the exported calculators
    /// </summary>
    public interface IIViewMetadataCalulators
    {
        /// <summary>
        /// This would be the name of the animal that will be associated with the calculator e.g. Lion 
        /// </summary>
        string AnimalType { get; }
        /// <summary>
        /// This would be the description of the calculator type. It needs to contain what animal it is associated with, at the start e.g. Lion_Easy
        /// </summary>
        string CalDescription { get; }
    }
}
