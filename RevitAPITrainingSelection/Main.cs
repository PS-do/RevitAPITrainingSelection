﻿using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPITrainingSelection
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            XYZ pickedPoint = null;
            try
            {
                pickedPoint = uidoc.Selection.PickPoint(ObjectSnapTypes.Endpoints, "выберите точку");
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            { }

            if (pickedPoint == null)
                return Result.Cancelled;
            TaskDialog.Show("PointInfo:\n", $"X: { pickedPoint.X}\n" +
                                         $"Y: {pickedPoint.Y}\n" +
                                         $"Z: {pickedPoint.Z}");

            return Result.Succeeded;

        }
    }
}
