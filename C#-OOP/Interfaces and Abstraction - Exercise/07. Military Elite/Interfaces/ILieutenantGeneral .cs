using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MilitaryElite.Interface
{
   public interface ILieutenantGeneral:IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get; }
    }
}
