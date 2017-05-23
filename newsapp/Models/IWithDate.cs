using newsapp.Data.Entity;
using System;

namespace newsapp.Models
{
    public interface IWithDate : IEntity
    {
        DateTime GetDateCreated();
        DateTime GetDateLastModified();
    }
}