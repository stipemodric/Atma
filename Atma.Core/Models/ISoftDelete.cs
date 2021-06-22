using System;
using System.Collections.Generic;
using System.Text;

namespace Atma.Core.Models
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
