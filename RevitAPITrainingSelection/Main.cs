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
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            ElementCategoryFilter windowsCategoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_Windows);
            ElementClassFilter windowInstancesFilter = new ElementClassFilter(typeof(FamilyInstance));  // выберет только те, которые являются экземплярами симейств(без типов)
            LogicalAndFilter windowsFilter = new LogicalAndFilter(windowsCategoryFilter, windowInstancesFilter);

            var windows = new FilteredElementCollector(doc)
                .WherePasses(windowsFilter)
                .Cast<FamilyInstance>()
                .ToList();

            
            TaskDialog.Show("Windows info", windows.Count.ToString());
            return Result.Succeeded;

        }
    }
}
