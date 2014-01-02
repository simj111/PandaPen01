using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interfaces
{
	interface ISelector
	{
        IList<string> getAvailableModels();
        void setModel(string modelName);


	}
}
