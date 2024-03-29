﻿using DataCloud.PipelineDesigner.CanvasModel;
using DataCloud.PipelineDesigner.Repositories.Models;
using DataCloud.PipelineDesigner.WorkflowModel.DSL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataCloud.PipelineDesigner.Services.Constants;

namespace DataCloud.PipelineDesigner.Services
{
    public class CanvasService
    {
         public static CanvasShapeTemplate TransformDslToCanvas(Dsl dsl)
        {
            CanvasShapeTemplate template = new CanvasShapeTemplate(dsl.Name, "", "Imported");
            template.Properties = new List<CanvasElementProperty>();
            var startGUID = Guid.NewGuid().ToString();
            var endGUID = Guid.NewGuid().ToString();

            var start = new CanvasShape
            {
                ID = startGUID,
                TemplateId = BuiltInTemplateIDs.Start.ToString(),
                Name = "Start",

                Shape = BuiltyInCanvasShape.Rectangle,

                ConnectionPoints = new List<CanvasShapeConnectionPoint>() {
                    new CanvasShapeConnectionPoint { Id = "2", Position = new CanvasPosition { X = 25, Y = 50 }, Type = CanvasConnectionPointType.Output }
                },
                Position = new CanvasPosition { X = 25, Y = 100 },
                Type = CanvasElementType.Shape,
                Width = 50,
                Height = 50,
            };

            template.Elements.Add(start);


            var lastShape = start;


            foreach (Step step in dsl.Steps)
            {

               

                var guid = Guid.NewGuid().ToString();

                var shape = new CanvasShape
                {
                    ID = guid,
                    Name = step.Name,
                    Shape = BuiltyInCanvasShape.Rectangle,
                    ConnectionPoints = new List<CanvasShapeConnectionPoint>() {
                        new CanvasShapeConnectionPoint { Id = "1", Position = new CanvasPosition { X = 0, Y = 100 }, Type= CanvasConnectionPointType.Input },
                        new CanvasShapeConnectionPoint { Id = "2", Position = new CanvasPosition { X = 300, Y = 100 }, Type = CanvasConnectionPointType.Output }
                    },
                    Position = NextPositon(lastShape),
                    Type = CanvasElementType.Shape,
                    Width = 300,
                    Height = 200,
                    Parameters = new CanvasParameters { 
                        Implementation = step.Implementation,
                        Image = step.Image,
                        ResourceProvider = step.ResourceProvider,
                        EnvironmentParameters = step.EnvParams.Select(e => new EnvironmentParameter { Key = e.Key, Value = e.Value }).ToList()                        }
                };

                template.Elements.Add(shape);

                template.Elements.Add(
                    new CanvasConnector
                    {
                        ID = Guid.NewGuid().ToString(),
                        SourceShapeId = lastShape.ID,
                        SourceConnectionPointId = "2",
                        DestShapeId = guid,
                        DestConnectionPointId = "1",
                        Type = CanvasElementType.Connector,
                    });

                lastShape = shape;
            }

            

            var end = new CanvasShape
            {
                ID = endGUID,
                TemplateId = BuiltInTemplateIDs.End.ToString(),
                Name = "End",
                Shape = BuiltyInCanvasShape.Rectangle,
                ConnectionPoints = new List<CanvasShapeConnectionPoint>() {
                    new CanvasShapeConnectionPoint { Id = "1", Position = new CanvasPosition { X = 25, Y = 50 }, Type= CanvasConnectionPointType.Input }
                },

                Position = NextPositon(lastShape),
                Type = CanvasElementType.Shape,
                Width = 50,
                Height = 50
            };

            template.Elements.Add(end);

            template.Elements.Add(
                new CanvasConnector
                {
                    ID = Guid.NewGuid().ToString(),
                    SourceShapeId = lastShape.ID,
                    SourceConnectionPointId = "2",
                    DestShapeId = endGUID,
                    DestConnectionPointId = "1",
                    Type = CanvasElementType.Connector,
                });

            return template;
        }

        private static CanvasPosition NextPositon(CanvasShape cs)
        {
            var x = cs.Position.X + cs.Width + 30;
            var y = cs.Position.Y;

            CanvasPosition nextPositon = new CanvasPosition { X = x, Y = y};

            return nextPositon;
        }

    }
}
