using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
namespace ProjManAPI
{
    public interface IDBModelContext 
    {
          IDbSet<parent_task> parent_task { get; set; }
          IDbSet<project> projects { get; set; }
          IDbSet<task> tasks { get; set; }
          IDbSet<user> users { get; set; }

    }
}