using ErpSystem.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.Services
{
    public interface ICellService
    {
        public Cell GetImg();
        public bool Update(Cell cell);

    }
}
