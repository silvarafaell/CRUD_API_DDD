using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Application.Extensions
{
    public static class ErrorMessages
    {
        public static string IdNotFoundError() => @$"Id não encontrado";

        public static string MatriculaNotFoundError() => @$"Matricula não encontrada";
    }
}
