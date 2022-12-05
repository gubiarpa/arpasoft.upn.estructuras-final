using garredondo.evaluacion_final.console.Data;
using garredondo.evaluacion_final.console.Matrix;
using garredondo.evaluacion_final.console.View;
using garredondo.evaluacion_final.core.Entities;
using garredondo.evaluacion_final.core.Services;

#region Main
var matrix = (new DataLoader()).GetMap8x8();
var matrixDrawer = new MatrixDrawer(matrix);
matrixDrawer.DrawMatrix();

ITreeNodeService<Cell> matrixTreeNodeService = new MatrixTreeNodeService(matrix);

Cell cellStart = GetCell(1);
Cell cellEnd = GetCell(2);

var paths = matrixTreeNodeService.GetPaths(cellStart!, cellEnd!);

Console.WriteLine();
if (paths == null || paths.Count() == 0)
{
    Console.WriteLine("No se encontraron rutas");
    return;
}

var minimumPath = paths.OrderBy(path =>
{
    var minimumStepCount = int.MaxValue;

    var stepCount = 0;
    var nodeRun = path;

    while (nodeRun != null)
    {
        stepCount++;
        nodeRun = nodeRun.Parent;
    }

    if (stepCount < minimumStepCount)
    {
        minimumStepCount = stepCount;
    }

    return minimumStepCount;
}).FirstOrDefault();

matrixDrawer.DrawMatrixWithPath(minimumPath);

Console.ReadKey();
#endregion

#region Utils
Cell GetCell(int cellNumber)
{
    bool nextStep = true;
    int x = 0, y = 0;

    while (nextStep)
    {
        Console.WriteLine();
        Console.WriteLine($"Celda {cellNumber}");
        Console.Write("x: "); if (!int.TryParse(Console.ReadLine(), out x)) continue;
        Console.Write("y: "); if (!int.TryParse(Console.ReadLine(), out y)) continue;
        nextStep = false;
    }

    return new Cell(x, y);

}
#endregion