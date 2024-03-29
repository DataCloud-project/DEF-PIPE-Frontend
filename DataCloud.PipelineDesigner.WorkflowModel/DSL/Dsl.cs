﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataCloud.PipelineDesigner.WorkflowModel.DSL
{
    public class Dsl
    {
        public string Name { get; set; }
        public Step[] Steps { get; set; }

    }

    public class Step
    {
        public string Name { get; set; }
        public string Implementation { get; set; }

        public string Image { get; set; }

        public  Dictionary<string, string> EnvParams { get; set; }

        public ExecutionRequirements[] ExecRequirements { get; set; }

        public string ResourceProvider { get; set; }
        public string Previous { get; set; }
    }

    public class ExecutionRequirements
    {
        public string Type { get; set; }
        public string SubType { get; set; }

        public Dictionary<string, string> Requirements { get; set; }
    }
}
