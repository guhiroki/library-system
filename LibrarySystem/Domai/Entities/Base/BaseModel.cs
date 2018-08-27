using System;
using System.Reflection;
using System.Text;

namespace LibrarySystem.Domain.Entities.Base
{
    public abstract class BaseModel
        {
            private PropertyInfo[] _PropertyInfos = null;

            public override string ToString()
            {
                if (_PropertyInfos == null)
                    _PropertyInfos = this.GetType().GetProperties();

                var sb = new StringBuilder();

                sb.AppendLine(this.GetType().Name + " {");
                foreach (var info in _PropertyInfos)
                {
                    var value = info.GetValue(this, null) ?? "(null)";
                    sb.AppendLine(info.Name + ": " + value.ToString());
                }
                sb.AppendLine("}");

                return sb.ToString();
            }
        }
}
