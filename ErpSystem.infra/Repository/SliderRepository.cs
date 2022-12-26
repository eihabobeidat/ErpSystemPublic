using Dapper;
using ErpSystem.core.Common;
using ErpSystem.core.Data;
using ErpSystem.core.DTO;
using ErpSystem.core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ErpSystem.infra.Repository
{
    public class SliderRepository : ISliderRepository
    {
        private readonly IDbContext context;
        public SliderRepository(IDbContext context)
        {
            this.context = context;
        }
        public List<SliderImageDTO> GetImage()
        {
            IEnumerable<SliderImageDTO> result = context.connection.Query<SliderImageDTO>("SliderPkg.RetriveImage", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public string InsertSliderId()
        {
            var result = context.connection.Execute("SliderPkg.NewSliderId", commandType: CommandType.StoredProcedure);

            return "Added";
        }

        public bool newSlider(string[] fill)
        {
            var result = context.connection.Execute("SliderPkg.NewSliderId", commandType: CommandType.StoredProcedure);
            for(int i=0;i<fill.Length;i++)
            {
                var p = new DynamicParameters();
                p.Add("img", fill[i], dbType: DbType.String, direction: ParameterDirection.Input);
                var result1 = context.connection.Execute("SliderPkg.AddNewSlider", p, commandType: CommandType.StoredProcedure);


            }

            return true;
        }
        public List<SliderImageDTO> GetAllImage()
        {
            IEnumerable<SliderImageDTO> result = context.connection.Query<SliderImageDTO>("SliderPkg.GettAllImage", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
