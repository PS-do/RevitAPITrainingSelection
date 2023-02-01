using Autodesk.Revit.Attributes;
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
            //    TaskDialog.Show("Сообщение", "Тест");
            //    return Result.Succeeded;
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            var pickedPoint = uidoc.Selection.PickPoint(ObjectSnapTypes.Endpoints, "выберите точку");


            TaskDialog.Show("PointInfo:\n", $"X: { pickedPoint.X}\n" +
                                         $"Y: {pickedPoint.Y}\n" +
                                         $"Z: {pickedPoint.Z}");

            return Result.Succeeded;

        }
    }
}
