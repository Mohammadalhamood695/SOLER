var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// Dependency Injection for Repositories
builder.Services.AddScoped<IBudgetRepository<BudgetDTO>, BudgetData>();

//HRManagementSystem
builder.Services.AddScoped<ICustomerRepository<CustomerDTO>, CustomerData>();
builder.Services.AddScoped<IEmployeeAttendanceRepository<EmployeeAttendanceDTO>, EmployeeAttendanceData>();
builder.Services.AddScoped<IEmployeeRepository<EmployeeDTO>, EmployeeData>();

builder.Services.AddScoped<IPayrollRepository<PayrollDTO>, PayrollData>();
builder.Services.AddScoped<ISupplierRepository<SupplierDTO>, SupplierData>();

//InvoiceManagementSystem
builder.Services.AddScoped<IInvoicesRepository<InvoicesDTO>, InvoicesData>();

//MaintenanceManagementSystem
builder.Services.AddScoped<IMaintenanceOperationRepository<MaintenanceOperationDTO>, MaintenanceOperationData>();

//ProcurementManagementSystem
builder.Services.AddScoped<IProcurementProductsRepository<ProcurementProductsDTO>, ProcurementProductsData>();
builder.Services.AddScoped<IProcurementsRepository<ProcurementsDTO>, ProcurementsData>();


//ProductManagementSystem
builder.Services.AddScoped<ICategoriesRepository<CategoriesDTO>, CategoriesData>();
builder.Services.AddScoped<IProductsRepository<ProductsDTO>, ProductsData>();

//SalesManagementSystem
builder.Services.AddScoped<ISalesProductsRepository<SalesProductsDTO>, SalesProductsData>();
builder.Services.AddScoped<ISalesRepository<SalesDTO>, SalesData>();

//WorkshopManagementSystem
builder.Services.AddScoped<IWorkshopEmployeeScheduleRepository<WorkshopEmployeeScheduleDTO>, WorkshopEmployeeScheduleData>();
builder.Services.AddScoped<IWorkshopRepository<WorkshopDTO>, WorkshopData>();
builder.Services.AddScoped<IWorkshopRepository<WorkshopDTO>, WorkshopData>();







// Dependency Injection for Services


//FinancialManagementSystem

builder.Services.AddScoped<IBudgetService, BudgetService>();


//HRManagementSystem

builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IEmployeeAttendanceService, EmployeeAttendanceService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddScoped<IPayrollService, PayrollService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();

//InvoiceManagementSystem
builder.Services.AddScoped<IInvoicesService, InvoicesService>();

//MaintenanceManagementSystem
builder.Services.AddScoped<IMaintenanceOperationService, MaintenanceOperationService>();

//ProcurementManagementSystem
builder.Services.AddScoped<IProcurementProductsService, ProcurementProductsService>();
builder.Services.AddScoped<IProcurementsService, ProcurementsService>();


//ProductManagementSystem
builder.Services.AddScoped<ICategoriesService, CategoriesService>();
builder.Services.AddScoped<IProductsService, ProductsService>();

//SalesManagementSystem
builder.Services.AddScoped<ISalesProductsService, SalesProductsService>();
builder.Services.AddScoped<ISalesService, SalesService>();



//WorkshopManagementSystem
builder.Services.AddScoped<IWorkshopEmployeeScheduleService, WorkshopEmployeeScheduleService>();
builder.Services.AddScoped<IWorkshopService, WorkshopService>();





// Configure AutoMapper here
builder.Services.AddAutoMapper(typeof(MappingConfig));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
