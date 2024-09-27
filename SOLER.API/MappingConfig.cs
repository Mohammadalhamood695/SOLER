namespace SOLER.API
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            //FinancialManagementSystem
            CreateMap<CreateBudgetDTO, BudgetDTO>().ReverseMap();
            CreateMap<UpdateBudgetDTO, BudgetDTO>().ReverseMap();


            //HRManagementSystem
            CreateMap<CreateCustomerDTO, CustomerDTO>().ReverseMap();
            CreateMap<UpdateCustomerDTO, CustomerDTO>().ReverseMap();

            CreateMap<CreateEmployeeAttendanceDTO, EmployeeAttendanceDTO>().ReverseMap();
            CreateMap<UpdateEmployeeAttendanceDTO, EmployeeAttendanceDTO>().ReverseMap();

            CreateMap<CreateEmployeeDTO, EmployeeDTO>().ReverseMap();
            CreateMap<UpdateEmployeeDTO, EmployeeDTO>().ReverseMap();

            CreateMap<CreatePersonDTO, PersonDTO>().ReverseMap();
            CreateMap<UpdatePersonDTO, PersonDTO>().ReverseMap();

            CreateMap<CreatePayrollDTO, PayrollDTO>().ReverseMap();
            CreateMap<UpdatePayrollDTO, PayrollDTO>().ReverseMap();

            CreateMap<CreateSupplierDTO, SupplierDTO>().ReverseMap();
            CreateMap<UpdateSupplierDTO, SupplierDTO>().ReverseMap();


            //InvoiceManagementSystem
            CreateMap<CreateInvoicesDTO, InvoicesDTO>().ReverseMap();
            CreateMap<UpdateInvoicesDTO, InvoicesDTO>().ReverseMap();

            //MaintenanceManagementSystem
            CreateMap<CreateMaintenanceOperationDTO, MaintenanceOperationDTO>().ReverseMap();
            CreateMap<UpdateMaintenanceOperationDTO, MaintenanceOperationDTO>().ReverseMap();
   
            //ProcurementManagementSystem
            CreateMap<CreateProcurementsDTO, ProcurementsDTO>().ReverseMap();
            CreateMap<UpdateProcurementsDTO, ProcurementsDTO>().ReverseMap();

            CreateMap<CreateProcurementProductsDTO, ProcurementProductsDTO>().ReverseMap();
            CreateMap<UpdateProcurementProductsDTO, ProcurementProductsDTO>().ReverseMap();


            //ProductManagementSystem
            CreateMap<CreateCategoriesDTO, CategoriesDTO>().ReverseMap();
            CreateMap<UpdateCategoriesDTO, CategoriesDTO>().ReverseMap();

            CreateMap<CreateProductsDTO, ProductsDTO>().ReverseMap();
            CreateMap<UpdateProductsDTO, ProductsDTO>().ReverseMap();
    
            
            //SalesManagementSystem
            CreateMap<CreateSalesDTO, SalesDTO>().ReverseMap();
            CreateMap<UpdateSalesDTO, SalesDTO>().ReverseMap();

            CreateMap<CreateSalesProductsDTO, SalesProductsDTO>().ReverseMap();
            CreateMap<UpdateSalesProductsDTO, SalesProductsDTO>().ReverseMap();

            //WorkshopManagementSystem
            CreateMap<CreateWorkshopDTO, WorkshopDTO>().ReverseMap();
            CreateMap<UpdateWorkshopDTO, WorkshopDTO>().ReverseMap();

            CreateMap<CreateWorkshopEmployeeScheduleDTO, WorkshopEmployeeScheduleDTO>().ReverseMap();
            CreateMap<UpdateWorkshopEmployeeScheduleDTO, WorkshopEmployeeScheduleDTO>().ReverseMap();
        }
    }
}
