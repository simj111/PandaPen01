using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Interfaces;
using System.Diagnostics;

namespace Selector
{   [ExportMetadata("description", "Selector")]
    [Export(typeof(ISelector))]
    public class Selectors : ISelector

{
     
     [ImportMany]
     private IEnumerable<Lazy<ICalculate, IInformationTypeMetadata>> Cals;
     

    public IList<string> getAvailableModels()
    {
        List<string> retval = new List<string>();
        Trace.WriteLine("Available Models are: ");
        foreach (Lazy<ICalculate, IInformationTypeMetadata> item in Cals)
        {
            retval.Add(item.Metadata.description);
            Trace.WriteLine(item.Metadata.description);
        }
        return retval;
    }

    public void setModel(string modelName)
    {
        throw new NotImplementedException();
    }
}
}
