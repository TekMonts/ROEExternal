using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace TekMonts.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [CompilerGenerated]
  [DebuggerNonUserCode]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (TekMonts.Properties.Resources.resourceMan == null)
          TekMonts.Properties.Resources.resourceMan = new ResourceManager("ROEExternalCheat.Properties.Resources", typeof (TekMonts.Properties.Resources).Assembly);
        return TekMonts.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return TekMonts.Properties.Resources.resourceCulture;
      }
      set
      {
        TekMonts.Properties.Resources.resourceCulture = value;
      }
    }

    internal Resources()
    {
    }
  }
}
