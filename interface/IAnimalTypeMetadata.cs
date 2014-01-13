using System;


namespace Interfaces
{
    /// <summary>
    /// This interface is used to gather the metadata of the exported animal.
    /// </summary>
  public interface IAnimalTypeMetadata
    {
      /// <summary>
      /// This would be the name of the animal e.g. Lion
      /// </summary>
      string AnimalType { get; }
    }
}
