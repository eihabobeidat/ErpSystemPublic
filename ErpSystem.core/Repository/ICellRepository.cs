using ErpSystem.core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.core.Repository
{
    public interface ICellRepository
    {
        public Cell GetImg();
        public bool Update(Cell cell);
    }
}
