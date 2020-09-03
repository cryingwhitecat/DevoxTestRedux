using System;
using System.Collections.Generic;
using System.Text;

namespace DevoxTestRedux.Domain.Entities
{
    /// <summary>
    /// Entity model used for O/RM
    /// </summary>
    public class Project
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
    }
}
