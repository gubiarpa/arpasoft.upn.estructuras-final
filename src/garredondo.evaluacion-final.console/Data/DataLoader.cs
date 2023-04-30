namespace garredondo.evaluacion_t2.console.Data
{
    public class DataLoader
    {
        /// <summary>
        /// Para el ejemplo, retorna una matriz de 8x8 con el ejemplo del enunciado del examen
        /// </summary>
        /// <returns>Devuelve una matriz de booleanos</returns>
        public bool[,] GetMap8x8()
        {
            var map8x8 = new bool[,] {
                /* 0 */ {  true , true , true , true , true , false, false, false },
                /* 1 */ {  true , false, true , true , true , true , true , true  },
                /* 2 */ {  true , false, true , false, false, false, true , false },
                /* 3 */ {  true , false, true , true , true , true , true , false },
                /* 4 */ {  true , true , true , true , false, true , true , false },
                /* 5 */ {  false, true , false, true , false, true , true , false },
                /* 6 */ {  false, true , false, true , false, true , true , false },
                /* 7 */ {  false, true , false, true , false, true , true , true  },
            };

            return map8x8;
        }
    }
}
