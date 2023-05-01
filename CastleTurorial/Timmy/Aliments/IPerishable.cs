using System;
using System.Collections.Generic;
namespace Timmy.Aliments
{
    public interface IPerishable : IAliment
    {
        public bool HasExpired { get; }
    }
}
