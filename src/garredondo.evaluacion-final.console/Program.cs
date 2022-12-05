using garredondo.evaluacion_final.console.Data;
using garredondo.evaluacion_final.console.Matrix;
using garredondo.evaluacion_final.core.Entities;

var matrix = (new DataLoader()).GetMap8x8();

var matrixTreeNodeService = new MatrixTreeNodeService(matrix);

var cellStart = new Cell(1, 2);
var cellEnd = new Cell(7, 7);

var paths = matrixTreeNodeService.GetPaths(cellStart, cellEnd);