using ErpSystem.core.Common;
using ErpSystem.core.Repository;
using ErpSystem.core.Services;
using ErpSystem.infra.Common;
using ErpSystem.infra.Repository;
using ErpSystem.infra.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpSystem.api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //domain
            services.AddScoped<IDbContext,DbContext>();
            //repository
            services.AddScoped<IVacationRepository,VacationRepository>();
            services.AddScoped<IVacationCountRepository, VacationCountRepository>();
            services.AddScoped<IVacationTypesRepository, VacationTypesRepository>();
            services.AddScoped<IFormalLeaveRepository, FormalLeaveRepository>();
            //service
            services.AddScoped<IVacationService, VacationService>();
            services.AddScoped<IVacationCountService, VacationCountService>();
            services.AddScoped<IVacationTypesService, VacationTypesService>();
            services.AddScoped<IFormalLeaveService, FormalLeaveService>();
            //controller
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(y => {
                y.RequireHttpsMetadata = false;
                y.SaveToken = true;
                y.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET USED TO SIGN AND VERIFY JWT TOKENS, IT CAN BE ANY STRING]")),

                    ValidateIssuer = false,
                    ValidateAudience = false

                };

            });

            services.AddScoped<IDbContext, DbContext>();
            services.AddScoped<IContactUsRepository, ContactUsRepository>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped<IPagesRepository, PagesRepository>();
            services.AddScoped<IPagesService, PagesService>();
            services.AddScoped<ITestimonialRepository, TestimonialRepository>();
            services.AddScoped<ITestimonialService, TestimonialService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();      
            services.AddScoped<IJwtRepository, JwtRepository>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IQualificationRepository, QualificationRepository>();
            services.AddScoped<IQualificationService, QualificationService>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ICellRepository, CellRepository>();
            services.AddScoped<ICellService, CellService>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddScoped<ISliderService, SliderService>();




            services.AddControllers();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<ISalaryRepository, SalaryRepository>();
            services.AddScoped<ISalaryService, SalaryService>();
            services.AddScoped<ISalaryChangesRepository, SalaryChangesRepository>();
            services.AddScoped<ISalaryChangesService, SalaryChangesService>();
            services.AddScoped<IAboutServiceRepository, AboutServiceRepository>();
            services.AddScoped<IAboutServiceService, AboutServiceService>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IPermissionService, PermissionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.WithOrigins("*")
            .AllowAnyMethod()
            .AllowAnyHeader());

           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
