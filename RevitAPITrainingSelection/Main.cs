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


            //Reference selectedElementRef = uidoc.Selection.PickObject(ObjectType.Edge, "Выберите элемент по ребру");
            IList<Reference> selectedElementRefList = uidoc.Selection.PickObjects(ObjectType.Element,new WallFilter(), "Выберите стены");

            var wallList = new List<Wall>();
            string info = string.Empty;
            foreach (var selectedElement in selectedElementRefList)
            {
                Wall oWall = doc.GetElement(selectedElement) as Wall;
                wallList.Add(oWall);
                var width = UnitUtils.ConvertFromInternalUnits(oWall.Width, UnitTypeId.Millimeters);
                info +=$"Name: {oWall.Name}, width:{width}\n";

            }
            info += $"\nколичество: {wallList.Count}";


            //Element element=doc.GetElement(selectedElementRef);
            TaskDialog.Show("Selection", info);

            return Result.Succeeded;

        }
    }
}
