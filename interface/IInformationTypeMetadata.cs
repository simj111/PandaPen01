using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
    /// <summary>
    /// This interface is used to gather the metadata of the exported animal.
    /// </summary>
  public interface IInformationTypeMetadata
    {
      /// <summary>
      /// This would be the name of the animal e.g. Lion
      /// </summary>
      string description { get; }
    }
}
