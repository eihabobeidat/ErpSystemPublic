using ErpSystem.core.Data;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErpSystem.infra.Services
{
    public class CellService : ICellService
    {
        private readonly ICellRepository cellRepository;
        public CellService(ICellRepository cellRepository)
        {
            this.cellRepository = cellRepository;

        }

        public Cell GetImg()
        {
            return cellRepository.GetImg();
        }
        public bool Update(Cell cell)
        {
            return cellRepository.Update(cell);

        }
    }
}
