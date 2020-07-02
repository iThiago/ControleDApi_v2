using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleDApi.ViewModel
{
    public class PaginaDTO<T>
    {
        public int Total { get; set; }
        public List<T> Itens { get; set; }
    }
}